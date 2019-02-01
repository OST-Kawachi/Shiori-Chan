namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates {

	/// <summary>
	/// ボタンテンプレートBuilder 
	/// </summary>
	public class ButtonTemplateMessageBuilder {

		/// <summary>
		/// 画像URL設定
		/// </summary>
		/// <param name="thmbnailImageUrl">画像URL</param>
		/// <returns>自身のBuilderクラス</returns>
		public ButtonTemplateMessageBuilder SetThumbnailImageUrl( string thmbnailImageUrl ) => this;

		/// <summary>
		/// 画像のアスペクト比設定
		/// </summary>
		/// <param name="imageAspectRatio">画像のアスペクト比</param>
		/// <returns>自身のBuilderクラス</returns>
		public ButtonTemplateMessageBuilder SetImageAspectRatio( string imageAspectRatio ) => this;

		/// <summary>
		/// 画像の表示形式設定
		/// </summary>
		/// <param name="imageSize">画像の表示形式</param>
		/// <returns>自身のBuilderクラス</returns>
		public ButtonTemplateMessageBuilder SetImageSize( string imageSize ) => this;

		/// <summary>
		/// 画像の背景色設定
		/// </summary>
		/// <param name="imageBackGroundColor">画像の背景色</param>
		/// <returns>自身のBuilderクラス</returns>
		public ButtonTemplateMessageBuilder SetImageBackgroundColor( string imageBackGroundColor ) => this;

		/// <summary>
		/// タイトル
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <returns>自身のBuilderクラス</returns>
		public ButtonTemplateMessageBuilder SetTitle( string title ) => this;

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		public BuildableMessageBuilder BuildTemplate()
			=> new BuildableMessageBuilder();

	}

}
