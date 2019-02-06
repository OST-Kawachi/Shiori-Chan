namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {
	public interface ISelectDefaultActionCarouselTemplateMessageBuilder {
		ISettablePostbackDefaultActionCarouselTemplateMessageBuilder UsePostbackDefaultAction( string label , string data );
		IBuildOnlyDefaultActionCarouselTemplateMessageBuilder UseMessageDefaultAction( string label , string text );
		IBuildOnlyDefaultActionCarouselTemplateMessageBuilder UseUriDefaultAction( string label , string uri );
		ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder UseDatetimePickerDefaultAction( string label , string data , string mode );
	}

}
