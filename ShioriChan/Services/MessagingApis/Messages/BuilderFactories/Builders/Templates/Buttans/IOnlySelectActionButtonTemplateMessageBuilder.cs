namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// アクション選択インタフェース
	/// </summary>
	public interface IOnlySelectActionButtonTemplateMessageBuilder {

		ISettablePostbackActionButtonTemplateMessageBuilder UsePostbackAction( string label , string data );
		IBuildOnlyButtonTemplateMessageBuilder UseMessageAction( string label , string text );
		IBuildOnlyButtonTemplateMessageBuilder UseUriAction( string label , string uri );
		ISettableDatetimePickerActionButtonTemplateMessageBuilder UseDatetimePickerAction( string label , string data , string mode );

	}

}
