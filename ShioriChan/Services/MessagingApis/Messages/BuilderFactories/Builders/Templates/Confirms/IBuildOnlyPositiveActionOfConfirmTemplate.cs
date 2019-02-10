namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのOKボタンのアクションビルドインタフェース
	/// </summary>
	public interface IBuildOnlyPositiveActionOfConfirmTemplate {
		ISelectOnlyNegativeActionOfConfirmTemplate BuildPositiveAction();
	}

}
