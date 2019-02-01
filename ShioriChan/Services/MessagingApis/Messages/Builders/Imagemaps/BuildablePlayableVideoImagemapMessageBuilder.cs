namespace ShioriChan.Services.MessagingApis.Messages.Builders.Imagemaps {
	/// <summary>
	/// 送信可能でイメージマップで動画を再生できるメッセージBuilder
	/// </summary>
	public class BuildablePlayableVideoImagemapMessageBuilder : BuildableMessageBuilder {
		
		/// <summary>
		/// イメージマップで動画を再生する
		/// </summary>
		/// <param name="originalContentUrl">動画ファイルのURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <param name="areaX">動画領域の位置</param>
		/// <param name="areaY">動画領域の位置</param>
		/// <param name="areaWidth">動画領域の幅</param>
		/// <param name="areaHeight">動画領域の高さ</param>
		/// <returns></returns>
		public BuildableShowableLabelImagemapMessageBuilder SetVideo(
			string originalContentUrl ,
			string previewImageUrl ,
			int areaX ,
			int areaY ,
			int areaWidth ,
			int areaHeight
		)
			=> (BuildableShowableLabelImagemapMessageBuilder)(BuildableMessageBuilder)this;

	}


}
