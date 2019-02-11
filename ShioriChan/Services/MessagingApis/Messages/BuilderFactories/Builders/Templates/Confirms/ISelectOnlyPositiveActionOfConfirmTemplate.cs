namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// 確認テンプレートのOKボタンのアクション選択
	/// </summary>
	public interface ISelectOnlyPositiveActionOfConfirmTemplate {

		/// <summary>
		/// OKボタンのアクションにポストバックを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <returns>ポストバックアクションの設定＋ビルド</returns>
		ISettablePositivePostbackActionOfConfirmTemplate UsePostbackPositiveAction( string label , string data );

		/// <summary>
		/// OKボタンのアクションにメッセージアクションを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="text">アクション実行時に送信されるテキスト</param>
		/// <returns>OKボタンのビルド</returns>
		IBuildOnlyPositiveActionOfConfirmTemplate UseMessagePositiveAction( string label , string text );

		/// <summary>
		/// OKボタンのアクションにURIアクションを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="uri">アクション実行時に開かれるURI</param>
		/// <returns>OKボタンのビルド</returns>
		IBuildOnlyPositiveActionOfConfirmTemplate UseUriPositiveAction( string label , string uri );

		/// <summary>
		/// OKボタンのアクションに日時選択アクションを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <param name="mode">アクションモード</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettablePositiveDatetimePickerActionOfConfirmTemplate UseDatetimePickerPositiveAction( string label , string data , string mode );

	}

}
