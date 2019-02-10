using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders {

	/// <summary>
	/// MessageBuilder
	/// </summary>
	public interface IMessageBuilder : IAddOnlyMessageOfMessageBuilder {

		/// <summary>
		/// クイックリプライ追加
		/// </summary>
		/// <returns>Item追加のみができるQuickReplyBuilder</returns>
		IAddOnlyItemOfQuickReply AddQuickReply();

		/// <summary>
		/// メッセージのBuild
		/// </summary>
		/// <returns>メッセージ送信クラス</returns>
		IMessageSender BuildMessage();

	}

}
