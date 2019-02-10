namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.ImageCarousels {

	public interface IAddOnlyColumnOfImageCarouselTemplate {

		/// <summary>
		/// カラム追加
		/// </summary>
		/// <param name="imageUrl">画像URL</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		IBuildOrAddColumnOfImageCarouselTemplate AddColumn( string imageUrl );

	}

}
