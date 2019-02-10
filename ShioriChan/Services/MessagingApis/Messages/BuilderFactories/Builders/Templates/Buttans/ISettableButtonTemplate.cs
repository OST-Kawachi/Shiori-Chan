namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// ボタンテンプレートBuilder
	/// </summary>
	public interface ISettableButtonTemplate {

		/// <summary>
		/// 画像URL設定
		/// </summary>
		/// <param name="thmbnailImageUrl">画像URL</param>
		/// <returns>自身のBuilderクラス</returns>
		ISettableButtonTemplate SetThumbnailImageUrl( string thmbnailImageUrl );

		/// <summary>
		/// 画像のアスペクト比設定
		/// </summary>
		/// <param name="imageAspectRatio">画像のアスペクト比</param>
		/// <returns>自身のBuilderクラス</returns>
		ISettableButtonTemplate SetImageAspectRatio( string imageAspectRatio );

		/// <summary>
		/// 画像の表示形式設定
		/// </summary>
		/// <param name="imageSize">画像の表示形式</param>
		/// <returns>自身のBuilderクラス</returns>
		ISettableButtonTemplate SetImageSize( string imageSize );

		/// <summary>
		/// 画像の背景色設定
		/// </summary>
		/// <param name="imageBackGroundColor">画像の背景色</param>
		/// <returns>自身のBuilderクラス</returns>
		ISettableButtonTemplate SetImageBackgroundColor( string imageBackGroundColor );

		/// <summary>
		/// タイトル
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <returns>自身のBuilderクラス</returns>
		ISettableButtonTemplate SetTitle( string title );

		/// <summary>
		/// アクション設定
		/// </summary>
		/// <returns>アクション選択インタフェース</returns>
		ISelectOnlyActionOfButtonTemplate SetAction();

	}

}
