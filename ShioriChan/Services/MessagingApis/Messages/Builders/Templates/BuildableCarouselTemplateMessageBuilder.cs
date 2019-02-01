namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates {

	/// <summary>
	/// ビルド可能なカルーセルテンプレート用Builder
	/// </summary>
	public class BuildableCarouselTemplateMessageBuilder : CarouselTemplateMessageBuilder {

		/// <summary>
		/// 画像URL設定
		/// </summary>
		/// <param name="thumbnailImageUrl">画像URL</param>
		/// <returns>自身のクラス</returns>
		public BuildableCarouselTemplateMessageBuilder SetThumbnailImageUrl( string thumbnailImageUrl )
			=> this;

		/// <summary>
		/// 画像の背景色設定
		/// </summary>
		/// <param name="imageBackgroundColor">画像の背景色</param>
		/// <returns>自身のクラス</returns>
		public BuildableCarouselTemplateMessageBuilder SetImageBackgroundColor( string imageBackgroundColor )
			=> this;

		/// <summary>
		/// タイトル設定
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <returns>自身のクラス</returns>
		public BuildableCarouselTemplateMessageBuilder SetTitle( string title )
			=> this;

		/// <summary>
		/// 領域全体のアクションの設定
		/// </summary>
		/// <returns>自身のクラス</returns>
		public BuildableCarouselTemplateMessageBuilder SetDefaultAction()
			=> this;

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		public BuildableMessageBuilder BuildTemplate()
			=> new BuildableMessageBuilder();

	}

}
