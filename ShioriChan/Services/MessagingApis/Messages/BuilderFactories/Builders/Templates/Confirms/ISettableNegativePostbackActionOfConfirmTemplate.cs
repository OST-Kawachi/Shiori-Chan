namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// ポストバックの設定＋ビルド
	/// </summary>
	public interface ISettableNegativePostbackActionOfConfirmTemplate : IBuildOnlyNegativeActionOfConfirmTemplate {

		/// <summary>
		/// アクションの実行時にユーザのメッセージとしてLINEのトーク画面に表示されるテキスト
		/// </summary>
		/// <param name="displayText">テキスト</param>
		/// <returns>ポストバックの設定＋ビルド</returns>
		ISettableNegativePostbackActionOfConfirmTemplate SetNegativeDisplayText( string displayText );

	}

}
