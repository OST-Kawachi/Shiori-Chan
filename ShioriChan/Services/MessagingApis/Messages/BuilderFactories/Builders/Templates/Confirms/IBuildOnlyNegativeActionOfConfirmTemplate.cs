namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// NGボタンのアクションのビルド
	/// </summary>
	public interface IBuildOnlyNegativeActionOfConfirmTemplate {

		/// <summary>
		/// NGボタンのアクションのビルド
		/// </summary>
		/// <returns>メッセージの追加＋ビルド</returns>
		IMessageBuilder BuildNegativeAction();

	}

}
