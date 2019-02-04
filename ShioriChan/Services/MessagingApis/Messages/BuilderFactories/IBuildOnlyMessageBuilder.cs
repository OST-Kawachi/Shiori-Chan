using ShioriChan.Services.MessagingApis.Messages.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {

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
