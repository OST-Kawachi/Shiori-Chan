using ShioriChan.Services.MessagingApis.Messages.BuilderFactories;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {

	public static partial class MessageBuilderFactory {

		/// <summary>
		/// メッセージBuilder生成
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <returns>メッセージの追加のみができるMessageBuilder</returns>
		public static IAddOnlyMessageBuilder CreateMessageBuilder( string channelAccessToken )
			=> new MessageBuilder( new MessageParameter() { channelAccessToken = channelAccessToken } );

	}

}
