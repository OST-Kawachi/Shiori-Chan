namespace ShioriChan.Services.MessagingApis.Messages.Builders.Imagemaps {
	/// <summary>
	/// 送信可能で動画再生するイメージマップにラベルが表示できるメッセージBuilder
	/// </summary>
	public class BuildableShowableLabelImagemapMessageBuilder : BuildableMessageBuilder {
		
		/// <summary>
		/// 動画再生後にラベルを表示する
		/// </summary>
		/// <param name="url">ウェブページのURL</param>
		/// <param name="label">ラベル</param>
		/// <returns>送信可能なメッセージBuilder</returns>
		public BuildableMessageBuilder SetExternalLink( string url , string label )
			=> this;

	}


}
