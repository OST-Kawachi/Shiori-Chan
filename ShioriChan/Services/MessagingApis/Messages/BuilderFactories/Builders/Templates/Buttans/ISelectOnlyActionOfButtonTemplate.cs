namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// ボタンテンプレートのアクション選択
	/// </summary>
	public interface ISelectOnlyActionOfButtonTemplate {

		/// <summary>
		/// ポストバックアクションを使用
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <returns>ポストバックアクションの設定＋ビルド</returns>
		ISettablePostbackActionOfButtonTemplate UsePostbackAction( string label , string data );

		/// <summary>
		/// メッセージアクションを使用
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="text">アクション実行時に送信されるテキスト</param>
		/// <returns>テンプレートのビルド</returns>
		IBuildOnlyOfButtonTemplate UseMessageAction( string label , string text );

		/// <summary>
		/// URIアクションを使用
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="uri">アクション実行時に開かれるURI</param>
		/// <returns>テンプレートのビルド</returns>
		IBuildOnlyOfButtonTemplate UseUriAction( string label , string uri );

		/// <summary>
		/// 日時選択アクションを使用
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックアクションのデータ</param>
		/// <param name="mode">アクションモード</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettableDatetimePickerActionOfButtonTemplate UseDatetimePickerAction( string label , string data , string mode );

	}

}
