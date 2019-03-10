using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ShioriChan.Settings;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.OAuthes.ChannelAccessTokens {

	/// <summary>
	/// チャンネルアクセストークン発行用クラス
	/// </summary>
	public class ChannelAccessTokenService : IChannelAccessTokenService {

		/// <summary>
		/// チャンネルID
		/// </summary>
		public readonly string ClientId;

		/// <summary>
		/// チャンネルシークレット
		/// </summary>
		public readonly string ClientSecret;

		/// <summary>
		/// ログ
		/// </summary>
		public ILogger logger;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="options">設定ファイル</param>
		/// <param name="logger">ログ</param>
		public ChannelAccessTokenService(
			IOptions<MessagingApiSetting> options ,
			ILogger<ChannelAccessTokenService> logger
		) {
			this.ClientId = options.Value.ChannelId;
			this.ClientSecret = options.Value.ChannelSecret;
			this.logger = logger;
		}

		/// <summary>
		/// 発行
		/// </summary>
		public ChannelAccessToken Issue() {
			this.logger.LogTrace( "Start" );

			WebClient webClient = new WebClient();
			string url = "https://api.line.me/v2/oauth/accessToken";
			webClient.Encoding = Encoding.UTF8;
			webClient.Headers[ HttpRequestHeader.ContentType ] = "application/x-www-form-urlencoded";
			NameValueCollection nameValueCollection = new NameValueCollection {
				[ "grant_type" ] = "client_credentials" ,
				[ "client_id" ] = this.ClientId ,
				[ "client_secret" ] = this.ClientSecret
			};

			try {
				this.logger.LogTrace( "Start Post Async" );
				byte[] bResult = webClient.UploadValues( url , nameValueCollection );
				string result = Encoding.UTF8.GetString( bResult );
				this.logger.LogTrace( "End Post Async" );
				this.logger.LogTrace( "Post Async Result is {result}" , result );
				JToken token = JObject.Parse( result );
				return new ChannelAccessToken() {
					AccessToken = token[ "access_token" ].ToString() ,
					ExpiresIn = int.Parse( token[ "expires_in" ].ToString() ) ,
					TokenType = token[ "token_type" ].ToString()
				};
			}
			catch( ArgumentNullException ) {
				this.logger.LogError( "Argument Null Exception" );
				return null;
			}
			catch( HttpRequestException ) {
				this.logger.LogError( "Http Request Exception" );
				return null;
			}
			catch( Exception ) {
				this.logger.LogError( "Exception" );
				return null;
			}

		}

		/// <summary>
		/// 取りけし
		/// </summary>
		/// <param name="accessToken">チャンネルアクセストークン</param>
		[Obsolete( "未完成です" , true )]
		public void Revoke( string accessToken ) { }

	}

}
