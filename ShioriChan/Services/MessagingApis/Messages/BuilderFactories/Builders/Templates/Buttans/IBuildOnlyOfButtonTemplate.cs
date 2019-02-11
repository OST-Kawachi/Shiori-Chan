namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// テンプレートのビルド
	/// </summary>
	public interface IBuildOnlyOfButtonTemplate {

		/// <summary>
		/// テンプレートのビルド
		/// </summary>
		/// <returns>メッセージの追加＋ビルド</returns>
		IMessageBuilder BuildTemplate();

	}

}
