namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのOKボタンのアクション選択インタフェース
	/// </summary>
	public interface ISelectPositiveActionConfirmTemplateMessageBuilder {
		ISettablePositivePostbackActionConfirmTemplateMessageBuilder UsePostbackPositiveAction( string label , string data );
		IBuildOnlyPositiveActionConfirmTemplateMessageBuilder UseMessagePositiveAction( string label , string text );
		IBuildOnlyPositiveActionConfirmTemplateMessageBuilder UseUriPositiveAction( string label , string uri );
		ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder UseDatetimePickerPositiveAction( string label , string data , string mode );
	}

}
