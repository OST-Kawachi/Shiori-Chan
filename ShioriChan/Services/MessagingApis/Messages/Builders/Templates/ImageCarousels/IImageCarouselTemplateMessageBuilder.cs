namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// 画像カルーセルテンプレートを使用する
	/// </summary>
	public interface IImageCarouselTemplateMessageBuilder : IAddColumnOnlyImageCarouselTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageBuilder BuildTemplate();

	}

}
