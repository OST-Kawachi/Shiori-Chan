namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのOKボタンのアクション選択インタフェース
	/// </summary>
	public interface ISelectOnlyPositiveActionOfConfirmTemplate {
		ISettablePositivePostbackActionOfConfirmTemplate UsePostbackPositiveAction( string label , string data );
		IBuildOnlyPositiveActionOfConfirmTemplate UseMessagePositiveAction( string label , string text );
		IBuildOnlyPositiveActionOfConfirmTemplate UseUriPositiveAction( string label , string uri );
		ISettablePositiveDatetimePickerActionOfConfirmTemplate UseDatetimePickerPositiveAction( string label , string data , string mode );
	}

}
