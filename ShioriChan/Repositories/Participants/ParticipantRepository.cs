using Microsoft.Extensions.Logging;

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
		)
		{
			this.logger = logger;
			this.model = model;
		}

	}

}
