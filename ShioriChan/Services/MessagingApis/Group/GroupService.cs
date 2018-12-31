using System;
using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.Group {

	/// <summary>
	/// グループ用クラス
	/// </summary>
	public class GroupService : IGroupService {

		/// <summary>
		/// グループメンバーのユーザIDを取得する
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> GetMemberIds() => throw new NotImplementedException();

		/// <summary>
		/// グループメンバーのプロフィールを取得する
		/// </summary>
		public void GetProfile() => throw new NotImplementedException();

		/// <summary>
		/// グループから退出する
		/// </summary>
		public void Leave() => throw new NotImplementedException();

	}

}
