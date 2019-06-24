using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShioriChan.Entities;

namespace ShioriChan.Repositories.Participants {

	/// <summary>
	/// 参加者Repository
	/// </summary>
	public class ParticipantRepository : IParticipantRepository {

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
		public ParticipantRepository(
			ILogger<ParticipantRepository> logger ,
			ModelCreator model
		) {
			this.logger = logger;
			this.model = model;
		}
		/// <summary>
		/// 参加者一覧取得
		/// </summary>
		/// <returns>参加者一覧</returns>
		public List<UserInfo> GetParticipantNames() {
			this.logger.LogInformation("Start");
			List<Participant> participants = this.model.Participants
				.Where(p => p.EventSeq == 0)
				.ToList();

			List<UserInfo> userInfos = this.model.UserInfos
				.Where(u => participants.Any(p => p.UserSeq == u.Seq))
				.ToList();

			this.logger.LogInformation("End");
			return userInfos;
		}
	}

}
