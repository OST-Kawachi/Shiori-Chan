using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.OAuthes;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.OAuthes.ChannelAccessTokens;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// メッセージ作成クラス
	/// </summary>
	public class MessageService : IMessageService {

		/// <summary>
		/// ログ作成クラス
		/// </summary>
		private readonly ILoggerFactory loggerFactory;

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// チャンネルアクセストークン発行クラス
		/// </summary>
		private readonly IChannelAccessTokenService channelAccessTokenService;

		/// <summary>
		/// 認証用Repository
		/// </summary>
		private readonly IOAuthRepository oAuthRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="loggerFactory">ログ作成クラス</param>
        public MessageService( 
			ILoggerFactory loggerFactory , 
			IChannelAccessTokenService channelAccessTokenService ,
			IOAuthRepository oAuthRepository
		) {
			this.loggerFactory = loggerFactory;
			this.logger = this.loggerFactory.CreateLogger<MessageService>();
			this.oAuthRepository = oAuthRepository;
			this.channelAccessTokenService = channelAccessTokenService;
		}

		/// <summary>
		/// メッセージBuilder作成
		/// </summary>
		/// <returns>メッセージBuilder</returns>
		public IAddOnlyMessageOfMessageBuilder CreateMessageBuilder() {
			string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
			this.logger.LogTrace( $"Channel Access Token is {channelAccessToken}" );
			if( string.IsNullOrEmpty( channelAccessToken ) ) {
				ChannelAccessToken cat = this.channelAccessTokenService.Issue();
				channelAccessToken = cat.AccessToken;
				this.oAuthRepository.RegisterChannelAccessToken( channelAccessToken );
			}
			return MessageBuilderFactory.CreateMessageBuilder( channelAccessToken , this.loggerFactory );
		}
		
		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		public async Task<byte[]> GetContent( string channelAccessToken , string messageId ) {

            JObject parameter = new JObject{
                    { "messageId" , messageId }
                };
            this.logger.LogTrace($"Parameter is {parameter}");

            StringContent content = new StringContent(parameter.ToString());
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.logger.LogTrace("Content is {content}", content);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] result = null;

            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.GetAsync("https://api.line.me/v2/bot/message/" + messageId + "/content").ConfigureAwait(false);
                this.logger.LogTrace("End Post Async");
                result = await response?.Content.ReadAsByteArrayAsync();
                this.logger.LogTrace("Post Async Result is {result}", result.Length);
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return null;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return null;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return null;
            }

            return result;
        }

	}
	
}
