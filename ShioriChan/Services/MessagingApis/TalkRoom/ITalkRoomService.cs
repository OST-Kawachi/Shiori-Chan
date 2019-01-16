using System;
using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.TalkRoom {

	/// <summary>
	/// トークルーム用インタフェース
	/// </summary>
	public interface ITalkRoomService {

		/// <summary>
		/// トークルームメンバーのユーザID一覧を取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="talkRoomId">トークルームID</param>
		/// <returns>メンバーID一覧</returns>
		[Obsolete( "未完成です" , true )]
		IEnumerable<string> GetMemberIds( string channelAccessToken , string talkRoomId );

		/// <summary>
		/// トークルームメンバーのプロフィールを取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="talkRoomId">トークルームID</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		TalkRoomMemberProfile GetProfile( string channelAccessToken , string talkRoomId , string userId );

		/// <summary>
		/// トークルームから退出する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセス</param>
		/// <param name="talkRoomId">グループID</param>
		[Obsolete( "未完成です" , true )]
		void Leave( string channelAccessToken , string talkRoomId );

	}

}
