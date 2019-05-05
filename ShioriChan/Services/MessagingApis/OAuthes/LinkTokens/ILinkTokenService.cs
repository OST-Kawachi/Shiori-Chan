using System;

namespace ShioriChan.Services.MessagingApis.OAuthes.LinkTokens {

	/// <summary>
	/// 連携トークン発行用インタフェース
	/// </summary>
	public interface ILinkTokenService {

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		void Issue( string channelAccessToken , string userId );

	}

}
