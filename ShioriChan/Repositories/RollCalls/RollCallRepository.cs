using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			ILogger<RollCallRepository> logger ,
			ModelCreator model
		) {
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 点呼に返事をする
		/// </summary>
		/// <param name="userId">ユーザID</param>
		public async Task TellIAmThere( string userId ) {
			Participant participant = this.model.Participants
				.Single( p => this.model.UserInfos
					.Single( u => u.Id == userId )
					.Seq == p.UserSeq
				);
			participant.RollCall = true;
			this.model.SaveChanges();
		}

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		public async Task<List<Status>> GetStatuses()
			=> this.model.Participants
				.Where( p => p.EventSeq == 0 )
				.Select( p => new Status {
					UserSeq = p.UserSeq ,
					RollCall = p.RollCall.HasValue ? p.RollCall.Value ? Ok : Ng : None ,
					Name = this.model.UserInfos
						.Single( u => u.Seq == p.UserSeq )
						.Name
				} )
			.ToList();

		/// <summary>
		/// 点呼リセット
		/// </summary>
		public async Task Reset() {
			this.model.Participants
				.Where( p => p.EventSeq == 0 )
				.ToList()
				.ForEach( p => {
					if( p.RollCall.HasValue ) {
						p.RollCall = false;
					}
				} );
			this.model.SaveChanges();
		}

		/// <summary>
		/// 参加者Id一覧取得
		/// </summary>
		/// <returns>参加者Id一覧</returns>
		public List<string> GetParticipantIds()
			=> this.model.Participants
				.Where( p => p.EventSeq == 0 )
				.Select( p => this.model.UserInfos
					.Single( u => u.Seq == p.UserSeq )
					.Id
				)
				.ToList();
		

	}

}