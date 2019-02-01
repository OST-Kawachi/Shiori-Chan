using ShioriChan.Services.MessagingApis.Messages.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// ビルド可能なメッセージBuilder
	/// </summary>
	public class BuildableMessageBuilder : MessageBuilder {

		/// <summary>
		/// メッセージのBuild
		/// </summary>
		/// <returns>メッセージ送信クラス</returns>
		public MessageSender BuildMessage()
			=> new MessageSender();

	}
	
}
