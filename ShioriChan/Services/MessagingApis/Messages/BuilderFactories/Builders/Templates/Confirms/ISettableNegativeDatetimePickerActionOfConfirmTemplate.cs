namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// 確認テンプレートのNGボタンの日時設定アクションの任意項目設定インタフェース
	/// </summary>
	public interface ISettableNegativeDatetimePickerActionOfConfirmTemplate : IBuildOnlyNegativeActionOfConfirmTemplate {
		ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeInitial( string initial );
		ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeMax( string max );
		ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeMin( string min );
	}

}
