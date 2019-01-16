using System;

namespace ShioriChan.Services.MessagingApis.Messages.Content {

	/// <summary>
	/// コンテンツ用クラス
	/// </summary>
	public class ContentService : IContentService {

		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		[Obsolete( "未完成です" , true )]
		public void Get( string channelAccessToken , string messageId ) { }


	}

}
