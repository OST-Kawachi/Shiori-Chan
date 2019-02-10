namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// Datepickerの任意項目を設定するインタフェース
	/// </summary>
	public interface ISettableDatetimePickerActionOfButtonTemplate : IBuildOnlyOfButtonTemplate {
		ISettableDatetimePickerActionOfButtonTemplate SetInitial( string initial );
		ISettableDatetimePickerActionOfButtonTemplate SetMax( string max );
		ISettableDatetimePickerActionOfButtonTemplate SetMin( string min );
	}

}
