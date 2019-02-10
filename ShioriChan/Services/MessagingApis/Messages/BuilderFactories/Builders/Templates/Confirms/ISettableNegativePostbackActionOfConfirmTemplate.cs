namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {
	/// <summary>
	/// 確認テンプレートのNGボタンのポストバックアクションの任意項目設定インタフェース
	/// </summary>
	public interface ISettableNegativePostbackActionOfConfirmTemplate : IBuildOnlyNegativeActionOfConfirmTemplate {
		ISettableNegativePostbackActionOfConfirmTemplate SetNegativeDisplayText( string displayText );
	}

}
