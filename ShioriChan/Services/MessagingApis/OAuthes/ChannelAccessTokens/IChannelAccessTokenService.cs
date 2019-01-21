using System;

namespace ShioriChan.Services.MessagingApis.OAuthes.ChannelAccessTokens {

	/// <summary>
	/// チャンネルアクセストークン発行インタフェース
	/// </summary>
	public interface IChannelAccessTokenService {

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="clientId">チャネルID</param>
		/// <param name="clientSecret">チャネルシークレット</param>
		[Obsolete( "未完成です" , true )]
		void Issue( string clientId , string clientSecret );

		/// <summary>
		/// 取り消し
		/// </summary>
		/// <param name="accessToken">チャンネルアクセストークン</param>
		[Obsolete( "未完成です" , true )]
		void Revoke( string accessToken );

	}

}
