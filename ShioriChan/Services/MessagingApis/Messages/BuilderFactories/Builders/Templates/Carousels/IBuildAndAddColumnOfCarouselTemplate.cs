namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// ビルド＋カラムの追加
	/// </summary>
	public interface IBuildAndAddColumnOfCarouselTemplate : IAddOnlyColumnOfCarouselTemplate {

		/// <summary>
		/// ビルド
		/// </summary>
		/// <returns>メッセージの追加＋ビルド</returns>
		IMessageBuilder BuildTemplate();

	}

}
	