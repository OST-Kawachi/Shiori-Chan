namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのNGボタンのアクション選択インタフェース
	/// </summary>
	public interface ISelectOnlyNegativeActionOfConfirmTemplate {
		ISettableNegativePostbackActionOfConfirmTemplate UsePostbackNegativeAction( string label , string data );
		IBuildOnlyNegativeActionOfConfirmTemplate UseMessageNegativeAction( string label , string text );
		IBuildOnlyNegativeActionOfConfirmTemplate UseUriNegativeAction( string label , string uri );
		ISettableNegativeDatetimePickerActionOfConfirmTemplate UseDatetimePickerNegativeAction( string label , string data , string mode );
	}

}
