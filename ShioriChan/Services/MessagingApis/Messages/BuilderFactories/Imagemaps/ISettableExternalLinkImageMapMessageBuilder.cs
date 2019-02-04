namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Imagemaps {

	/// <summary>
	/// イメージマップで動画再生後にラベルを表示できるMessageBuilder
	/// </summary>
	public interface ISettableExternalLinkImageMapMessageBuilder : IMessageFactory {

		/// <summary>
		/// 動画再生後にラベルを表示する
		/// </summary>
		/// <param name="url">ウェブページのURL</param>
		/// <param name="label">ラベル</param>
		/// <returns>送信可能なメッセージBuilder</returns>
		IMessageFactory SetExternalLink( string url , string label );

	}

}
