namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Templates.Carousels {

	/// <summary>
	/// カルーセルテンプレートBuilder
	/// </summary>
	public interface ICarouselTemplateMessageBuilder : IAddAndSetOnlyCarouselTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageFactory BuildTemplate();

	}

}
