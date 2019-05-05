namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// OKボタンのビルド
	/// </summary>
	public interface IBuildOnlyPositiveActionOfConfirmTemplate {

		/// <summary>
		/// OKボタンのビルド
		/// </summary>
		/// <returns>NGボタンのアクション選択</returns>
		ISelectOnlyNegativeActionOfConfirmTemplate BuildPositiveAction();

	}

}
