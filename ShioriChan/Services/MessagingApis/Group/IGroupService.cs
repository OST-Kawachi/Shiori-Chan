using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.Group {

	/// <summary>
	/// グループ用インタフェース
	/// </summary>
	public interface IGroupService {

		/// <summary>
		/// グループメンバーのユーザIDを取得する
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetMemberIds();

		/// <summary>
		/// グループメンバーのプロフィールを取得する
		/// </summary>
		void GetProfile();

		/// <summary>
		/// グループから退出する
		/// </summary>
		void Leave();

	}

}
