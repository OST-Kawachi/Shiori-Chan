using Newtonsoft.Json;

namespace ShioriChan.Services.MessagingApis.OAuthes.ChannelAccessTokens {

	public class ChannelAccessToken {

		[JsonProperty( "access_token" )]
		public string AccessToken { set; get; }

		[JsonProperty( "expires_in" )]
		public int ExpiresIn { set; get; }

		[JsonProperty( "token_type" )]
		public string TokenType { set; get; }

	}

}
