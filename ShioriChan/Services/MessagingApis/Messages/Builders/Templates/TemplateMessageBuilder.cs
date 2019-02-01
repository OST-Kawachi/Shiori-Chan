namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates {
	/// <summary>
	/// テンプレート用Builder 
	/// </summary>
	public class TemplateMessageBuilder {

		/// <summary>
		/// ボタンテンプレートを使用する
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>ボタンテンプレートBuilder</returns>
		public ButtonTemplateMessageBuilder UseButtonTemplate( string text )
			=> new ButtonTemplateMessageBuilder();

		/// <summary>
		/// 確認テンプレートを使用する
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>確認テンプレートBuilder</returns>
		public ConfirmTemplateMessageBuilder UseConfirmTemplate( string text )
			=> new ConfirmTemplateMessageBuilder();

		/// <summary>
		/// カルーセルテンプレートを使用する
		/// </summary>
		/// <returns>カルーセルテンプレートBuilder </returns>
		public CarouselTemplateMessageBuilder UseCarouselTemplateMessageBuilder()
			=> new CarouselTemplateMessageBuilder();

		/// <summary>
		/// 画像カルーセルテンプレートを使用する
		/// </summary>
		/// <returns>画像カルーセルテンプレートBuilder</returns>
		public ImageCarouselTemplateMessageBuilder UseImageCarouselTemplateMessageBuilder()
			=> new ImageCarouselTemplateMessageBuilder();

	}

}
