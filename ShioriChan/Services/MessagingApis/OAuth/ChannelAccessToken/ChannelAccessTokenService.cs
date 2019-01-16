using System;

namespace ShioriChan.Services.MessagingApis.OAuth {

	/// <summary>
	/// チャンネルアクセストークン発行用クラス
	/// </summary>
	public class ChannelAccessTokenService : IChannelAccessTokenService {

		/// <summary>
		/// 発行
		/// </summary>
		/// <param name="clientId">チャネルID</param>
		/// <param name="clientSecret">チャネルシークレット</param>
		[Obsolete( "未完成です" , true )]
		public void Issue( string clientId , string clientSecret ) { }

		/// <summary>
		/// 取りけし
		/// </summary>
		/// <param name="accessToken">チャンネルアクセストークン</param>
		[Obsolete( "未完成です" , true )]
		public void Revoke( string accessToken ) { }

	}

}
