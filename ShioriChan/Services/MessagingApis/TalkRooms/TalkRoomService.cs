using System;
using System.Collections.Generic;
using System.Linq;

namespace ShioriChan.Services.MessagingApis.TalkRooms {

	/// <summary>
	/// トークルーム用Service
	/// </summary>
	public class TalkRoomService : ITalkRoomService {

		/// <summary>
		/// 再帰的にトークルームメンバーのユーザID一覧を取得する
		/// </summary>
		/// <param name="talkRoomId">トークルームID</param>
		/// <param name="isFirst">再帰初回かどうか</param>
		/// <param name="nextToken">継続トークン</param>
		/// <returns>トークルームメンバーのユーザID一覧</returns>
		[Obsolete( "未完成です" , true )]
		private IEnumerable<string> GetMemberIdsRecursively( string talkRoomId , bool isFirst = true , string nextToken = null ) {

			IEnumerable<string> memberIds;
			string start;

			// 再帰初回はnextTokenを見ない
			if( isFirst ) {

			}
			// 再帰2回目以降があればnextTokenをパラメータに含める
			else {

			}

			// トークルームメンバーのユーザIDを取得
			memberIds = new List<string>();
			start = null;

			// startが存在しない場合に再帰終了
			return start is null ? memberIds : memberIds.Concat( this.GetMemberIdsRecursively( talkRoomId , false , start ) );

		}

		/// <summary>
		/// トークルームメンバーのユーザID一覧を取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="talkRoomId">トークルームID</param>
		/// <returns>メンバーID一覧</returns>
		[Obsolete( "未完成です" , true )]
		public IEnumerable<string> GetMemberIds( string channelAccessToken , string talkRoomId )
			=> this.GetMemberIdsRecursively( talkRoomId );

		/// <summary>
		/// トークルームメンバーのプロフィールを取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="talkRoomId">トークルームID</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		public TalkRoomMemberProfile GetProfile( string channelAccessToken , string talkRoomId , string userId ) => null;

		/// <summary>
		/// トークルームから退出する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="talkRoomId">グループID</param>
		[Obsolete( "未完成です" , true )]
		public void Leave( string channelAccessToken , string talkRoomId ) { }

	}

}
