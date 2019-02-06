namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {
	public interface ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder : IBuildOnlyDefaultActionCarouselTemplateMessageBuilder {
		ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder SetDefaultInitial( string initial );
		ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder SetDefaultMax( string max );
		ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder SetDefaultMin( string min );
	}

}
