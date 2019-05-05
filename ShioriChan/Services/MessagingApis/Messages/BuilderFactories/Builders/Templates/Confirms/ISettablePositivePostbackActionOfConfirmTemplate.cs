namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// ポストバックアクションの設定＋ビルド
	/// </summary>
	public interface ISettablePositivePostbackActionOfConfirmTemplate : IBuildOnlyPositiveActionOfConfirmTemplate {

		/// <summary>
		/// アクション実行時に、ユーザのメッセージとしてLINEのトーク画面に表示されるテキスト
		/// </summary>
		/// <param name="displayText">テキスト</param>
		/// <returns>ポストバックアクションの設定＋ビルド</returns>
		ISettablePositivePostbackActionOfConfirmTemplate SetPositiveDisplayText( string displayText );

	}

}
