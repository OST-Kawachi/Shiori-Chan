namespace ShioriChan.Services.MessagingApis.Messages.Builders {

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
