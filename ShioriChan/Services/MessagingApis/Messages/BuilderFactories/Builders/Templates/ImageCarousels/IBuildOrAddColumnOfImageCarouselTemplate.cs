namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.ImageCarousels {

	/// <summary>
	/// カラムの追加＋ビルド
	/// </summary>
	public interface IBuildOrAddColumnOfImageCarouselTemplate : IAddOnlyColumnOfImageCarouselTemplate {

		/// <summary>
		/// ビルド
		/// </summary>
		/// <returns>メッセージの追加＋ビルド</returns>
		IMessageBuilder BuildTemplate();

	}

}
