namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Templates.Carousels {

	public interface IColumnSettingOnlyCarouselTemplateMessageBuilder : IAddColumnTemplateMessageBuilder {

		/// <summary>
		/// 画像URL設定
		/// </summary>
		/// <param name="thumbnailImageUrl">画像URL</param>
		/// <returns>自身のクラス</returns>
		IColumnSettingOnlyCarouselTemplateMessageBuilder SetThumbnailImageUrl( string thumbnailImageUrl );

		/// <summary>
		/// 画像の背景色設定
		/// </summary>
		/// <param name="imageBackgroundColor">画像の背景色</param>
		/// <returns>自身のクラス</returns>
		IColumnSettingOnlyCarouselTemplateMessageBuilder SetImageBackgroundColor( string imageBackgroundColor );

		/// <summary>
		/// タイトル設定
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <returns>自身のクラス</returns>
		IColumnSettingOnlyCarouselTemplateMessageBuilder SetTitle( string title );

		/// <summary>
		/// 領域全体のアクションの設定
		/// </summary>
		/// <returns>自身のクラス</returns>
		IColumnSettingOnlyCarouselTemplateMessageBuilder SetDefaultAction();

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageFactory BuildTemplate();

	}

}
