namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// ビルド＋アクションの追加
	/// </summary>
	public interface IBuildAndAddColumnActionOfCarouselTemplate : IAddColumnActionOfCarouselTemplate {

		/// <summary>
		/// ビルド
		/// </summary>
		/// <returns>ビルド＋カラムの追加</returns>
		IBuildAndAddColumnOfCarouselTemplate BuildColumnAction();

	}

}
	