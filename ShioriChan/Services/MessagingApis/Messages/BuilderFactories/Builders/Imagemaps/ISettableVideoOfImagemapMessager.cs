namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Imagemaps {

	/// <summary>
	/// メッセージの追加＋ビルド＋ビデオの設定
	/// </summary>
	public interface ISettableVideoOfImagemapMessager : IMessageBuilder {

		/// <summary>
		/// イメージマップで動画を再生する
		/// </summary>
		/// <param name="originalContentUrl">動画ファイルのURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <param name="areaX">動画領域の位置</param>
		/// <param name="areaY">動画領域の位置</param>
		/// <param name="areaWidth">動画領域の幅</param>
		/// <param name="areaHeight">動画領域の高さ</param>
		/// <returns>メッセージの追加＋ビルド＋ビデオ再生後のラベル設定</returns>
		ISettableExternalLinkOfImageMapMessage SetVideo( string originalContentUrl , string previewImageUrl , int areaX , int areaY , int areaWidth , int areaHeight );

	}

}
