namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {
	public interface ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder : IBuildOnlyColumnActionCarouselTemplateMessageBuilder {
		ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder SetColumnInitial( string initial );
		ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder SetColumnMax( string max );
		ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder SetColumnMin( string min );
	}

}
	