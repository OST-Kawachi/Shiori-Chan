namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// QuickReplyBuilder
	/// </summary>
	public interface IQuickReplyBuilder : IAddOnlyQuickReplyBuilder {

		/// <summary>
		/// QuickReplyのBuild
		/// </summary>
		/// <returns>ビルドしかできないMessageBuilder</returns>
		IBuildOnlyMessageBuilder BuildQuickReply();

	}

}
