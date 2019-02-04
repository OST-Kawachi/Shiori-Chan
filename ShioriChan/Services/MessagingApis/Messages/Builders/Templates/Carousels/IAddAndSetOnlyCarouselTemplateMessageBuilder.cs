namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates.Carousels {

	public interface IAddAndSetOnlyCarouselTemplateMessageBuilder : IAddColumnTemplateMessageBuilder {

		/// <summary>
		/// 画像のアスペクト比設定
		/// </summary>
		/// <param name="imageAspectRatio">画像のアスペクト比</param>
		/// <returns>自身のBuilderクラス</returns>
		IAddAndSetOnlyCarouselTemplateMessageBuilder SetImageAspectRatio( string imageAspectRatio );

		/// <summary>
		/// 画像の表示形式設定
		/// </summary>
		/// <param name="imageSize">画像の表示形式</param>
		/// <returns>自身のBuilderクラス</returns>
		IAddAndSetOnlyCarouselTemplateMessageBuilder SetImageSize( string imageSize );
		
	}

}
