namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// ポストバックアクションの任意項目を設定できるインタフェース
	/// </summary>
	public interface ISettablePostbackActionButtonTemplateMessageBuilder : IBuildOnlyButtonTemplateMessageBuilder {
		IBuildOnlyButtonTemplateMessageBuilder SetDisplayText( string displayText );
	}

}
