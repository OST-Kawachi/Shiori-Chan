namespace ShioriChan.Repositories.Users {

	/// <summary>
	/// ユーザRepository
	/// </summary>
	public interface IUserRepository {

		/// <summary>
		/// 登録済みかどうか
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>登録済みかどうか</returns>
		bool IsRegisterd( string userId );

		/// <summary>
		/// ユーザIDのみ承認待ちテーブルに登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>承認待ちテーブル管理番号</returns>
		int RegisterOnlyUserIdInWaitingApproval( string userId );

	}

}
