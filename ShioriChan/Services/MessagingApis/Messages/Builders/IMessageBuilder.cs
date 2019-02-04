using ShioriChan.Services.MessagingApis.Messages.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// MessageBuilder
	/// </summary>
	public interface IMessageBuilder : IAddOnlyMessageBuilder {

		/// <summary>
		/// クイックリプライ追加
		/// </summary>
		/// <returns>Item追加のみができるQuickReplyBuilder</returns>
		IAddOnlyQuickReplyBuilder AddQuickReply();


		/// <summary>
		/// メッセージのBuild
		/// </summary>
		/// <returns>メッセージ送信クラス</returns>
		IMessageSender BuildMessage();

	}

}
