using System;
using System.Collections.Generic;
using System.Linq;

namespace ShioriChan.Services.MessagingApis.Group {

	/// <summary>
	/// グループ用クラス
	/// </summary>
	public class GroupService : IGroupService {

		/// <summary>
		/// 再帰的にグループメンバーのユーザID一覧を取得する
		/// </summary>
		/// <param name="groupId">グループID</param>
		/// <param name="isFirst">再帰初回かどうか</param>
		/// <param name="nextToken">継続トークン</param>
		/// <returns>グループメンバーのユーザID一覧</returns>
		[Obsolete( "未完成です" , true )]
		private IEnumerable<string> GetMemberIdsRecursively( string groupId , bool isFirst = true , string nextToken = null ) {

			IEnumerable<string> memberIds;
			string start;

			// 再帰初回はnextTokenを見ない
			if( isFirst ) {

			}
			// 再帰2回目以降があればnextTokenをパラメータに含める
			else {

			}

			// グループメンバーのユーザIDを取得
			memberIds = new List<string>();
			start = null;

			// startが存在しない場合に再帰終了
			return start is null ? memberIds : memberIds.Concat( this.GetMemberIdsRecursively( groupId , false , start ) );

		}

		/// <summary>
		/// グループメンバーのユーザID一覧を取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="groupId">グループID</param>
		/// <returns>メンバーID一覧</returns>
		[Obsolete( "未完成です" , true )]
		public IEnumerable<string> GetMemberIds( string channelAccessToken , string groupId )
			=> this.GetMemberIdsRecursively( groupId );

		/// <summary>
		/// グループメンバーのプロフィールを取得する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="groupId">グループID</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		public GroupMemberProfile GetProfile( string channelAccessToken , string groupId , string userId ) => null;

		/// <summary>
		/// グループから退出する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="groupId">グループID</param>
		[Obsolete( "未完成です" , true )]
		public void Leave( string channelAccessToken , string groupId ) { }

	}

}
