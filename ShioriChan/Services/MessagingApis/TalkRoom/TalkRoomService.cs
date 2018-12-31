using System;
using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.TalkRoom {
	
	/// <summary>
	/// トークルーム用Service
	/// </summary>
	public class TalkRoomService : ITalkRoomService {

		/// <summary>
		/// トークルームメンバーのユーザIDを取得する
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> GetUserIds() => throw new NotImplementedException();

		/// <summary>
		/// トークルームメンバーのプロフィールを取得する
		/// </summary>
		public void GetUserProfile() => throw new NotImplementedException();

		/// <summary>
		/// トークルームから退出する
		/// </summary>
		public void Leave() => throw new NotImplementedException();

	}

}
