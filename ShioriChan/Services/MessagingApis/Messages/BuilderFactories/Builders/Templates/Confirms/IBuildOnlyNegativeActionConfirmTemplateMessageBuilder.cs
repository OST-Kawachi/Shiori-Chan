namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのNGボタンのアクションビルドインタフェース
	/// </summary>
	public interface IBuildOnlyNegativeActionConfirmTemplateMessageBuilder {
		IMessageBuilder BuildNegativeAction();
	}

}
