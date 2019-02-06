namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {
	public interface ISelectOnlyColumnActionCarouselTemplateMessageBuilder {
		ISettablePostbackColumnActionCarouselTemplateMessageBuilder UsePostbackColumnAction( string label , string data );
		IBuildOnlyColumnActionCarouselTemplateMessageBuilder UseMessageColumnAction( string label , string text );
		IBuildOnlyColumnActionCarouselTemplateMessageBuilder UseUriColumnAction( string label , string uri );
		ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder UseDatetimePickerAction( string label , string data , string mode );
	}

}
	