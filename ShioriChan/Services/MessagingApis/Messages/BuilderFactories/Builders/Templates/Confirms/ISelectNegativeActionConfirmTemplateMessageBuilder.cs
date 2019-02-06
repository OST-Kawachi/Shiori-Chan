namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのNGボタンのアクション選択インタフェース
	/// </summary>
	public interface ISelectNegativeActionConfirmTemplateMessageBuilder {
		ISettableNegativePostbackActionConfirmTemplateMessageBuilder UsePostbackNegativeAction( string label , string data );
		IBuildOnlyNegativeActionConfirmTemplateMessageBuilder UseMessageNegativeAction( string label , string text );
		IBuildOnlyNegativeActionConfirmTemplateMessageBuilder UseUriNegativeAction( string label , string uri );
		ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder UseDatetimePickerNegativeAction( string label , string data , string mode );
	}

}
