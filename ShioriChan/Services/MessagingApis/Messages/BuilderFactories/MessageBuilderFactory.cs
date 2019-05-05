using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {

	/// <summary>
	/// メッセージBuilderの生成クラス
	/// </summary>
	public static partial class MessageBuilderFactory {

		/// <summary>
		/// メッセージBuilder生成
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="loggerFactory">ログ生成クラス</param>
		/// <returns>メッセージの追加</returns>
		public static IAddOnlyMessageOfMessageBuilder CreateMessageBuilder( 
			string channelAccessToken ,
			ILoggerFactory loggerFactory
		)
			=> new MessageBuilder( 
				new MessageParameter() {
					ChannelAccessToken = channelAccessToken ,
					Messages = new JArray(),
					LoggerFactory = loggerFactory
				} 
			);

	}

}
