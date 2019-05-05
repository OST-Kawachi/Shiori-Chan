namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// ビルド＋アイテム追加
	/// </summary>
	public interface IBuildOrAddItemOfQuickReply : IAddOnlyItemOfQuickReply {

		/// <summary>
		/// QuickReplyのBuild
		/// </summary>
		/// <returns>ビルドしかできない</returns>
		IBuildOnlyOfMessageBuilder BuildQuickReply();

	}

}
