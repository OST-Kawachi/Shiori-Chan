namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// カラムのアクション選択
	/// </summary>
	public interface ISelectColumnActionOfCarouselTemplate {

		/// <summary>
		/// カラムのアクションにポストバックを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <returns>ポストバックの設定＋ビルド＋カラムの追加</returns>
		ISettablePostbackColumnActionOfCarouselTemplate UsePostbackColumnAction( string label , string data );

		/// <summary>
		/// カラムのアクションにメッセージを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="text">アクションの実行時に送信されるテキスト</param>
		/// <returns>アクションのビルド＋アクションの追加</returns>
		IBuildAndAddColumnActionOfCarouselTemplate UseMessageColumnAction( string label , string text );

		/// <summary>
		/// カラムのアクションにURIを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="uri">アクションの実行時に開かれるURI</param>
		/// <returns>アクションのビルド＋アクションの追加</returns>
		IBuildAndAddColumnActionOfCarouselTemplate UseUriColumnAction( string label , string uri );

		/// <summary>
		/// カラムのアクションに日時選択を使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <param name="mode">アクションモード</param>
		/// <returns>日時選択の設定＋アクションのビルド＋アクションの追加</returns>
		ISettableDatetimePickerColumnActionOfCarouselTemplate UseDatetimePickerAction( string label , string data , string mode );

	}

}
	