namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates {
	/// <summary>
	/// ビルド可能な画像カルーセルテンプレート用Builder
	/// </summary>
	public class BuildableImageCarouselTemplateMessageBuilder : ImageCarouselTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		public BuildableMessageBuilder BuildTemplate()
			=> new BuildableMessageBuilder();
		
	}

}
