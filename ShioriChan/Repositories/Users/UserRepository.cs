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

		/// <summary>
		/// 登録済みかどうか
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>登録済みかどうか</returns>
		public bool IsRegisterd( string userId )
		{
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"User Id is {userId}." );
			return false;
		}

		/// <summary>
		/// ユーザIDのみ承認待ちテーブルに登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>承認待ちテーブル管理番号</returns>
		public int RegisterOnlyUserIdInWaitingApproval( string userId )
		{
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"User Id is {userId}." );
			return -1;
		}

	}

}
