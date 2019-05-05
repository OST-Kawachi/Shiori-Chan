namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// カルーセルテンプレートの設定＋カラム追加
	/// </summary>
	public interface ISettableAndAddColumnOfCarouselTemplate : IAddOnlyColumnOfCarouselTemplate {

		/// <summary>
		/// 画像のアスペクト比設定
		/// </summary>
		/// <param name="imageAspectRatio">画像のアスペクト比</param>
		/// <returns>カルーセルテンプレートの設定＋カラム追加</returns>
		ISettableAndAddColumnOfCarouselTemplate SetImageAspectRatio( string imageAspectRatio );

		/// <summary>
		/// 画像の表示形式設定
		/// </summary>
		/// <param name="imageSize">画像の表示形式</param>
		/// <returns>カルーセルテンプレートの設定＋カラム追加</returns>
		ISettableAndAddColumnOfCarouselTemplate SetImageSize( string imageSize );
		
	}

}


