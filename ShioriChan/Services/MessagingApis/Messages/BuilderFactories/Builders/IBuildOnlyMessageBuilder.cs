using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders {

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
