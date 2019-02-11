namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// ポストバックアクションの設定＋ビルド
	/// </summary>
	public interface ISettablePostbackActionOfButtonTemplate : IBuildOnlyOfButtonTemplate {

		/// <summary>
		/// アクションの実行時にユーザのメッセージとしてLINEのトーク画面に表示されるテキスト
		/// </summary>
		/// <param name="displayText">テキスト</param>
		/// <returns>テンプレートのビルド</returns>
		IBuildOnlyOfButtonTemplate SetDisplayText( string displayText );

	}

}
