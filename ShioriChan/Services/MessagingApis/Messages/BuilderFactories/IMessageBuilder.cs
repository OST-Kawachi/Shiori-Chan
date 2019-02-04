using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.QuickReplies;
using ShioriChan.Services.MessagingApis.Messages.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {

	/// <summary>
	/// MessageBuilder
	/// </summary>
	public interface IMessageFactory : IAddOnlyMessageBuilder {

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
