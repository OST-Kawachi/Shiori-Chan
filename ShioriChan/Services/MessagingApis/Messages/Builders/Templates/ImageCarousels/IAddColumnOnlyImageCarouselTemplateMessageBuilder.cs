namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	public interface IAddColumnOnlyImageCarouselTemplateMessageBuilder {

		/// <summary>
		/// カラム追加
		/// </summary>
		/// <param name="imageUrl">画像URL</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		IImageCarouselTemplateMessageBuilder AddColumn( string imageUrl );

	}

}
