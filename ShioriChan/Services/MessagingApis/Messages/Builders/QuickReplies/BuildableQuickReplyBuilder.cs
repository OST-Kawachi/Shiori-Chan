namespace ShioriChan.Services.MessagingApis.Messages.Builders.QuickReplies {

	/// <summary>
	/// ビルド可能なQuickReply用Builder
	/// </summary>
	public class BuildableQuickReplyBuilder : QuickReplyBuilder {

		/// <summary>
		/// QuickReplyのBuild
		/// </summary>
		/// <returns>MessageBuilder</returns>
		public MessageBuilder BuildQuickReply()
			=> new MessageBuilder();

	}

}
