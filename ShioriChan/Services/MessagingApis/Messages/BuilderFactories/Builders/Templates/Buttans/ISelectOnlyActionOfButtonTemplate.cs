namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// アクション選択インタフェース
	/// </summary>
	public interface ISelectOnlyActionOfButtonTemplate {

		ISettablePostbackActionOfButtonTemplate UsePostbackAction( string label , string data );
		IBuildOnlyOfButtonTemplate UseMessageAction( string label , string text );
		IBuildOnlyOfButtonTemplate UseUriAction( string label , string uri );
		ISettableDatetimePickerActionOfButtonTemplate UseDatetimePickerAction( string label , string data , string mode );

	}

}
