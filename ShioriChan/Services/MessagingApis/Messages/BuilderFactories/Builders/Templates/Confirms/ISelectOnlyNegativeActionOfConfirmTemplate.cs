namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// NGボタンのアクション選択
	/// </summary>
	public interface ISelectOnlyNegativeActionOfConfirmTemplate {

		/// <summary>
		/// NGボタンのアクションにポストバックを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <returns>ポストバックの設定＋ビルド</returns>
		ISettableNegativePostbackActionOfConfirmTemplate UsePostbackNegativeAction( string label , string data );

		/// <summary>
		/// NGボタンのアクションにメッセージを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="text">アクション実行時に送信されるテキスト</param>
		/// <returns>NGボタンのアクションのビルド</returns>
		IBuildOnlyNegativeActionOfConfirmTemplate UseMessageNegativeAction( string label , string text );

		/// <summary>
		/// NGボタンのアクションにURIを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="uri">アクション実行時に開かれるURI</param>
		/// <returns>NGボタンのアクションのビルド</returns>
		IBuildOnlyNegativeActionOfConfirmTemplate UseUriNegativeAction( string label , string uri );

		/// <summary>
		/// NGボタンのアクションに日時選択を使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <param name="mode">アクションモード</param>
		/// <returns>日時選択の設定＋ビルド</returns>
		ISettableNegativeDatetimePickerActionOfConfirmTemplate UseDatetimePickerNegativeAction( string label , string data , string mode );

	}

}
