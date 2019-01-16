using System;
using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.Group {

	/// <summary>
	/// グループ用インタフェース
	/// </summary>
	public interface IGroupService {

		/// <summary>
		/// グループメンバーのユーザID一覧を取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="groupId">グループID</param>
		/// <returns>メンバーID一覧</returns>
		[Obsolete( "未完成です" , true )]
		IEnumerable<string> GetMemberIds( string channelAccessToken , string groupId );

		/// <summary>
		/// グループメンバーのプロフィールを取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="groupId">グループID</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		GroupMemberProfile GetProfile( string channelAccessToken , string groupId , string userId );

		/// <summary>
		/// グループから退出する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="groupId">グループID</param>
		[Obsolete( "未完成です" , true )]
		void Leave( string channelAccessToken , string groupId );

	}

}
