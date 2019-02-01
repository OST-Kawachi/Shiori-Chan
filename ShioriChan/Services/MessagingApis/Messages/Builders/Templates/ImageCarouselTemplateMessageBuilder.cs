namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates {

	/// <summary>
	/// 画像カルーセルテンプレート用Builder
	/// </summary>
	public class ImageCarouselTemplateMessageBuilder {

		/// <summary>
		/// カラム追加
		/// </summary>
		/// <param name="imageUrl">画像URL</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		public BuildableImageCarouselTemplateMessageBuilder AddColumn( string imageUrl )
			=> (BuildableImageCarouselTemplateMessageBuilder)this;

	}

}
