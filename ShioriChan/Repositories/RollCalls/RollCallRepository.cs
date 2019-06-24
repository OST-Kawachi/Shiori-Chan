using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using static ShioriChan.Controllers.RollCalls.RollCallsController;

namespace ShioriChan.Repositories.RollCalls
{

	/// <summary>
	/// 点呼Repository
	/// </summary>
	public class RollCallRepository : IRollCallRepository
	{

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
		)
		{
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 点呼に返事をする
		/// </summary>
		/// <param name="userId">ユーザID</param>
		public void TellIAmThere(string userId)
		{
			this.logger.LogInformation("Start");
			this.logger.LogDebug($"User Id is {userId}");

			UserInfo userInfo = this.model.UserInfos
				.SingleOrDefault(u => userId.Equals(u.Id));
			if( userInfo is null) {
				this.logger.LogWarning("User Info is NULL");
				return;
			}

			Participant participant = this.model.Participants
				.SingleOrDefault(p => userInfo.Seq == p.UserSeq && p.EventSeq == 0);
			if( participant is null) {
				this.logger.LogWarning("Participant is NULL");
				return;
			}

			participant.RollCall = true;
			this.model.SaveChanges();

			this.logger.LogInformation("End");
		}


		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		public List<Status> GetStatuses() {
			this.logger.LogInformation("Call Get Statuses");
			return this.model.Participants
				.Where(p => p.EventSeq == 0)
				.Select(p => new Status {
					UserSeq = p.UserSeq,
					RollCall = this.model.UserInfos
						.Where(u => u.Seq == p.UserSeq)
						.Select(u => string.IsNullOrEmpty(u.Id))
						.FirstOrDefault() ?
						None :
						p.RollCall.HasValue ? p.RollCall.Value ? Ok : Ng : None,
					Name = this.model.UserInfos
					   .Single(u => u.Seq == p.UserSeq)
					   .Name
				})
			.ToList();
		}

		/// <summary>
		/// 点呼リセット
		/// </summary>
		public void Reset()
		{
			this.logger.LogInformation("Start");
			this.model.Participants
				.Where(p => p.EventSeq == 0)
				.ToList()
				.ForEach(p => {
					if (p.RollCall.HasValue)
					{
						p.RollCall = false;
					}
				});
			this.model.SaveChanges();
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