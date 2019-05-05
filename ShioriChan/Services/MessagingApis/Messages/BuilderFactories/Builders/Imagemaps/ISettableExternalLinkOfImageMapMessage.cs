namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Imagemaps {

	/// <summary>
	/// メッセージの追加＋ビルド＋ビデオ再生後のラベル設定
	/// </summary>
	public interface ISettableExternalLinkOfImageMapMessage : IMessageBuilder {

		/// <summary>
		/// 動画再生後にラベルを表示する
		/// </summary>
		/// <param name="url">ウェブページのURL</param>
		/// <param name="label">ラベル</param>
		/// <returns>メッセージの追加＋ビルド</returns>
		IMessageBuilder SetExternalLink( string url , string label );

	}

}
