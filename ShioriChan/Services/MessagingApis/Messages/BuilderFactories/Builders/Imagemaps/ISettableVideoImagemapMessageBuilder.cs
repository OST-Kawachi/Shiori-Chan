namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Imagemaps {

	/// <summary>
	/// イメージマップで動画再生を設定できるMessageBuilder
	/// </summary>
	public interface ISettableVideoImagemapMessageBuilder : IMessageBuilder {

		/// <summary>
		/// イメージマップで動画を再生する
		/// </summary>
		/// <param name="originalContentUrl">動画ファイルのURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <param name="areaX">動画領域の位置</param>
		/// <param name="areaY">動画領域の位置</param>
		/// <param name="areaWidth">動画領域の幅</param>
		/// <param name="areaHeight">動画領域の高さ</param>
		/// <returns>イメージマップで動画再生後にラベルを表示できるMessageBuilder</returns>
		ISettableExternalLinkImageMapMessageBuilder SetVideo( string originalContentUrl , string previewImageUrl , int areaX , int areaY , int areaWidth , int areaHeight );

	}

}
