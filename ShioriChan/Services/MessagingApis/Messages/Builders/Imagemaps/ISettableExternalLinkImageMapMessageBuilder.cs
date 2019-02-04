namespace ShioriChan.Services.MessagingApis.Messages.Builders.Imagemaps {

	/// <summary>
	/// イメージマップで動画再生後にラベルを表示できるMessageBuilder
	/// </summary>
	public interface ISettableExternalLinkImageMapMessageBuilder : IMessageBuilder {

		/// <summary>
		/// 動画再生後にラベルを表示する
		/// </summary>
		/// <param name="url">ウェブページのURL</param>
		/// <param name="label">ラベル</param>
		/// <returns>送信可能なメッセージBuilder</returns>
		IMessageBuilder SetExternalLink( string url , string label );

	}

}
