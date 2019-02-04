using ShioriChan.Services.MessagingApis.Messages.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// ビルドしかできないMessageBuilder
	/// </summary>
	public interface IBuildOnlyMessageBuilder {

		/// <summary>
		/// メッセージのBuild
		/// </summary>
		/// <returns>メッセージ送信クラス</returns>
		IMessageSender BuildMessage();

	}

}
