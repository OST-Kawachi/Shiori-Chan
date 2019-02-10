namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// QuickReplyBuilder
	/// </summary>
	public interface IBuildOrAddItemOfQuickReply : IAddOnlyItemOfQuickReply {

		/// <summary>
		/// QuickReplyのBuild
		/// </summary>
		/// <returns>ビルドしかできないMessageBuilder</returns>
		IBuildOnlyOfMessageBuilder BuildQuickReply();

	}

}
