namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// カルーセルテンプレートBuilder
	/// </summary>
	public interface ICarouselTemplateMessageBuilder : IAddAndSetOnlyCarouselTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageBuilder BuildTemplate();

	}

}
