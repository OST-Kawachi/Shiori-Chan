using Microsoft.Extensions.Logging;

namespace ShioriChan.Repositories.RollCalls {

	/// <summary>
	/// 点呼Repository
	/// </summary>
	public class RollCallRepository : IRollCallRepository {

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
		)
		{
			this.logger = logger;
			this.model = model;
		}

	}

}