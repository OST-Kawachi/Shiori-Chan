using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;

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
		/// コンストラクタ
		/// </summary>
		/// <param name="loggerFactory">ログ作成クラス</param>
		public MessageService( ILoggerFactory loggerFactory ) {
			this.loggerFactory = loggerFactory;
			this.logger = this.loggerFactory.CreateLogger<MessageService>();
		}

		/// <summary>
		/// メッセージBuilder作成
		/// </summary>
		/// <returns>メッセージBuilder</returns>
		public IAddOnlyMessageBuilder CreateMessageBuilder() {
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
