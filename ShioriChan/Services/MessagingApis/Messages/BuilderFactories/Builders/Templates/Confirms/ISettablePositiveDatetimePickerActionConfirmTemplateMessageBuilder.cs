namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのOKボタンの日時設定アクションの任意項目設定インタフェース
	/// </summary>
	public interface ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder : IBuildOnlyPositiveActionConfirmTemplateMessageBuilder {
		ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder SetPositiveInitial( string initial );
		ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder SetPositiveMax( string max );
		ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder SetPositiveMin( string min );
	}

}
