using Microsoft.Extensions.Logging;

namespace ShioriChan.Repositories.Users {

	/// <summary>
	/// ユーザRepository
	/// </summary>
	public class UserRepository : IUserRepository {

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
		public UserRepository(
			ILogger<UserRepository> logger ,
			ModelCreator model
		)
		{
			this.logger = logger;
			this.model = model;
		}

	}

}
