using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
		private IChannelAccessTokenService channelAccessTokenService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="loggerFactory">ログ作成クラス</param>
		public MessageService( ILoggerFactory loggerFactory , IChannelAccessTokenService channelAccessTokenService ) {
			this.loggerFactory = loggerFactory;
			this.logger = this.loggerFactory.CreateLogger<MessageService>();
		}

		/// <summary>
		/// メッセージBuilder作成
		/// </summary>
		/// <returns>メッセージBuilder</returns>
		public IAddOnlyMessageOfMessageBuilder CreateMessageBuilder() {
			string channelAccessToken = "";
			return MessageBuilderFactory.CreateMessageBuilder( channelAccessToken );
		}
		
		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		public async Task GetContent( string channelAccessToken , string messageId ) { }

	}
	
}
