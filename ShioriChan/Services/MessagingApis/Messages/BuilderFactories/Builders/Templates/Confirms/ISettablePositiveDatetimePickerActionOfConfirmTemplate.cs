namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのOKボタンの日時設定アクションの任意項目設定インタフェース
	/// </summary>
	public interface ISettablePositiveDatetimePickerActionOfConfirmTemplate : IBuildOnlyPositiveActionOfConfirmTemplate {
		ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveInitial( string initial );
		ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMax( string max );
		ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMin( string min );
	}

}
