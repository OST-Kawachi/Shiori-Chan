namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// デフォルトアクションのビルド
	/// </summary>
	public interface IBuildOnlyDefaultActionOfCarouselTemplate {

		/// <summary>
		/// ビルド
		/// </summary>
		/// <returns>カラムの設定</returns>
		ISettableColumnOfCarouselTemplate BuildDefaultAction();

	}

}
