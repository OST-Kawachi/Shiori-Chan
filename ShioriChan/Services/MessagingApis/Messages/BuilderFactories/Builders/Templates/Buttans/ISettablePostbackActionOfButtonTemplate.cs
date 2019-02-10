namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// ポストバックアクションの任意項目を設定できるインタフェース
	/// </summary>
	public interface ISettablePostbackActionOfButtonTemplate : IBuildOnlyOfButtonTemplate {
		IBuildOnlyOfButtonTemplate SetDisplayText( string displayText );
	}

}
