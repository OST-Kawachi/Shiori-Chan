namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// 確認テンプレートのNGボタンの日時設定アクションの任意項目設定インタフェース
	/// </summary>
	public interface ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder : IBuildOnlyNegativeActionConfirmTemplateMessageBuilder {
		ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder SetNegativeInitial( string initial );
		ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder SetNegativeMax( string max );
		ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder SetNegativeMin( string min );
	}

}
