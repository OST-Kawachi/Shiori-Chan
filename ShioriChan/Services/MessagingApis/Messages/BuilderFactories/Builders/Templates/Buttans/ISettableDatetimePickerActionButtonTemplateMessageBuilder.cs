namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// Datepickerの任意項目を設定するインタフェース
	/// </summary>
	public interface ISettableDatetimePickerActionButtonTemplateMessageBuilder : IBuildOnlyButtonTemplateMessageBuilder {
		ISettableDatetimePickerActionButtonTemplateMessageBuilder SetInitial( string initial );
		ISettableDatetimePickerActionButtonTemplateMessageBuilder SetMax( string max );
		ISettableDatetimePickerActionButtonTemplateMessageBuilder SetMin( string min );
	}

}
