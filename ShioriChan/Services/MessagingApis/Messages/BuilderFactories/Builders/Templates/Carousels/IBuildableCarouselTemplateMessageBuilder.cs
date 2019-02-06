namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {
	public interface IBuildableCarouselTemplateMessageBuilder : IColumnSettingOnlyCarouselTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageBuilder BuildTemplate();

	}

}
	