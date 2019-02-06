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
		/// <returns>メッセージの追加のみができるMessageBuilder</returns>
		public static IAddOnlyMessageBuilder CreateMessageBuilder( string channelAccessToken )
			=> new MessageBuilder( new MessageParameter() { channelAccessToken = channelAccessToken } );

	}

}
