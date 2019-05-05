namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// カラムの設定
	/// </summary>
	public interface ISettableColumnOfCarouselTemplate : IAddColumnActionOfCarouselTemplate {

		/// <summary>
		/// 画像URL設定
		/// </summary>
		/// <param name="thumbnailImageUrl">画像URL</param>
		/// <returns>カラムの設定</returns>
		ISettableColumnOfCarouselTemplate SetThumbnailImageUrl( string thumbnailImageUrl );

		/// <summary>
		/// 画像の背景色設定
		/// </summary>
		/// <param name="imageBackgroundColor">画像の背景色</param>
		/// <returns>カラムの設定</returns>
		ISettableColumnOfCarouselTemplate SetImageBackgroundColor( string imageBackgroundColor );

		/// <summary>
		/// タイトル設定
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <returns>カラムの設定</returns>
		ISettableColumnOfCarouselTemplate SetTitle( string title );

		/// <summary>
		/// 領域全体のアクションの設定
		/// </summary>
		/// <returns>デフォルトアクションの選択</returns>
		ISelectDefaultActionOfCarouselTemplate SetDefaultAction();

	}

}

