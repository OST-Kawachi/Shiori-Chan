using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.TalkRoom {

	/// <summary>
	/// トークルーム用インタフェース
	/// </summary>
	public interface ITalkRoomService {

		/// <summary>
		/// トークルームメンバーのユーザIDを取得する
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetUserIds();

		/// <summary>
		/// トークルームメンバーのプロフィールを取得する
		/// </summary>
		void GetUserProfile();

		/// <summary>
		/// トークルームから退出する
		/// </summary>
		void Leave();

	}

}
