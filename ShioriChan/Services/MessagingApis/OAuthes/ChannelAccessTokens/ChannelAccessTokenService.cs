using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ShioriChan.Settings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
		public async Task<ChannelAccessToken> Issue() {
			this.logger.LogTrace( "Start" );

			JObject request = new JObject {
				{"grant_type","client_credentials" },
				{"client_id",this.ClientId } ,
				{"client_secret",this.ClientSecret }
			};

			StringContent content = new StringContent( request.ToString() );
			content.Headers.ContentType = new MediaTypeHeaderValue( "application/x-www-form-urlencoded" );

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/x-www-form-urlencoded" ) );
			
			try {
				this.logger.LogTrace( "Start Post Async" );
				HttpResponseMessage response = await client.PostAsync( "https://api.line.me/v2/oauth/accessToken" , content ).ConfigureAwait( false );
				this.logger.LogTrace( "End Post Async" );
				ChannelAccessToken result = await response?.Content.ReadAsAsync<ChannelAccessToken>();
				this.logger.LogTrace( "Post Async Result is {result}" , result );
				response.Dispose();
				client.Dispose();
				return result;
			}
			catch( ArgumentNullException ) {
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
				return null;
			}
			catch( HttpRequestException ) {
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
				return null;
			}
			catch( Exception ) {
				this.logger.LogError( "Exception" );
				client.Dispose();
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
