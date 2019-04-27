using System.Collections.Generic;

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

		/// <summary>
		/// メッセージを取得する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>通知メッセージ</returns>
		string GetMessage( string userId );

		/// <summary>
		/// ユーザIDの一覧を取得
		/// </summary>
		/// <returns>ユーザID一覧</returns>
		List<string> GetUserIds();

		/// <summary>
		/// 指定のユーザのステータスを通知済みに変更する
		/// </summary>
		/// <param name="userId">ユーザId</param>
		void UpdateUserStatus( string userId );

	}

}
