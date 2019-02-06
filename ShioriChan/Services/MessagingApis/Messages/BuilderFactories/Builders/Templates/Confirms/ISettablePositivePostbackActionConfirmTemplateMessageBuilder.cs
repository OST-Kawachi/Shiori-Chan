namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのOKボタンのポストバックアクションの任意項目設定インタフェース
	/// </summary>
	public interface ISettablePositivePostbackActionConfirmTemplateMessageBuilder : IBuildOnlyPositiveActionConfirmTemplateMessageBuilder {
		ISettablePositivePostbackActionConfirmTemplateMessageBuilder SetPositiveDisplayText( string displayText );
	}

}
