namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates {

	/// <summary>
	/// カルーセルテンプレート用Builder
	/// </summary>
	public class CarouselTemplateMessageBuilder {

		/// <summary>
		/// 画像のアスペクト比設定
		/// </summary>
		/// <param name="imageAspectRatio">画像のアスペクト比</param>
		/// <returns>自身のBuilderクラス</returns>
		public CarouselTemplateMessageBuilder SetImageAspectRatio( string imageAspectRatio )
			=> this;

		/// <summary>
		/// 画像の表示形式設定
		/// </summary>
		/// <param name="imageSize">画像の表示形式</param>
		/// <returns>自身のBuilderクラス</returns>
		public CarouselTemplateMessageBuilder SetImageSize( string imageSize )
			=> this;

		/// <summary>
		/// カラム追加
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>ビルド可能なカルーセルテンプレート用Builder</returns>
		public BuildableCarouselTemplateMessageBuilder AddColumn( string text )
			=>(BuildableCarouselTemplateMessageBuilder)this;

	}

}
