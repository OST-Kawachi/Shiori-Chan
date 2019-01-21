using System;

namespace ShioriChan.Services.MessagingApis.OAuthes.LinkTokens {

	/// <summary>
	/// 連携トークン発行用クラス
	/// </summary>
	public class LinkTokenService : ILinkTokenService {

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		public void Issue( string channelAccessToken , string userId ) { }

	}

}
