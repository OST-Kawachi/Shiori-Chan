namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.ImageCarousels {

	/// <summary>
	/// カラムの追加
	/// </summary>
	public interface IAddOnlyColumnOfImageCarouselTemplate {

		/// <summary>
		/// カラム追加
		/// </summary>
		/// <param name="imageUrl">画像URL</param>
		/// <returns>カラムの追加＋ビルド</returns>
		IBuildOrAddColumnOfImageCarouselTemplate AddColumn( string imageUrl );

	}

}
