using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using static ShioriChan.Controllers.RollCalls.RollCallsController;

namespace ShioriChan.Repositories.RollCalls {

	/// <summary>
	/// 点呼Repository
	/// </summary>
	public class RollCallRepository : IRollCallRepository {

		private const string None = "－";
		private const string Ng = "×";
		private const string Ok = "〇";

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// DBモデル
		/// </summary>
		private readonly ModelCreator model;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		public RollCallRepository(
			ILogger<RollCallRepository> logger,
			ModelCreator model
		) {
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 点呼に返事をする
		/// </summary>
		/// <param name="userId">ユーザID</param>
		public async Task TellIAmThere(string userId) {
			this.logger.LogInformation("Start");
			this.logger.LogDebug($"User Id is {userId}");

			using (IDbContextTransaction transaction = this.model.Database.BeginTransaction()) {

				UserInfo userInfo = this.model.UserInfos
					.SingleOrDefault(u => userId.Equals(u.Id));
				if (userInfo is null) {
					this.logger.LogWarning("User Info is NULL");
					return;
				}

				Participant participant = this.model.Participants
					.SingleOrDefault(p => userInfo.Seq == p.UserSeq && p.EventSeq == 0);
				if (participant is null) {
					this.logger.LogWarning("Participant is NULL");
					return;
				}
				this.logger.LogDebug($"TellIAmThere p.EventSeq is {participant.EventSeq}");
				this.logger.LogDebug($"TellIAmThere p.UserSeq is {participant.UserSeq}");

				participant.RollCall = true;
				participant.UpdateDatetime = DateTime.Now;
				participant.Version++;
				
				int count = await this.model.SaveChangesAsync();
				this.logger.LogInformation($"Save Change Count is {count}");
				
				transaction.Commit();

			}

			this.logger.LogInformation("End");
		}

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		public List<Status> GetStatuses() {
			this.logger.LogInformation("Call Get Statuses");
			IQueryable<Status> query = from p in this.model.Participants
									   join u in this.model.UserInfos on p.UserSeq equals u.Seq
									   select new Status {
										   UserSeq = p.UserSeq,
										   RollCall = string.IsNullOrEmpty(u.Id) || !p.RollCall.HasValue ? None : p.RollCall.Value ? Ok : Ng,
										   Name = u.Name
									   };
			return query.ToList();

		}

		/// <summary>
		/// 点呼リセット
		/// </summary>
		public async Task Reset() {
			this.logger.LogInformation("Start");

			using (IDbContextTransaction transaction = this.model.Database.BeginTransaction()) {

				this.model.Database.ExecuteSqlCommand("update Participant set RollCall = 0 , Version = Version + 1");
				await this.model.SaveChangesAsync();
				transaction.Commit();

			}
			this.logger.LogInformation("End");
		}

		/// <summary>
		/// 参加者Id一覧取得
		/// </summary>
		/// <returns>参加者Id一覧</returns>
		public List<string> GetParticipantIds() {
			this.logger.LogInformation("Call Get Participant Ids");
			return this.model.UserInfos
				.Where(ui => !string.IsNullOrEmpty(ui.Id))
				.Where(ui => this.model.Participants
				   .Any(p => p.EventSeq == 0 && p.UserSeq == ui.Seq)
				)
				.Select(ui => ui.Id)
				.ToList();
		}

	}

}