namespace ShioriChan.Repositories.Notifications {

	/// <summary>
	/// 通知Repository
	/// </summary>
	public interface INotificationRepository {

		/// <summary>
		/// メッセージを登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <param name="Text">リプライメッセージ</param>
		void Register( string userId , string text );

	}

}
