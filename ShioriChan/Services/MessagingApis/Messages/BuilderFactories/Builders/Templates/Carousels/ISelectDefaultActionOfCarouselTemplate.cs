namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// デフォルトアクションの選択
	/// </summary>
	public interface ISelectDefaultActionOfCarouselTemplate {

		/// <summary>
		/// デフォルトアクションにポストバックを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <returns>ポストバックの設定＋ビルド</returns>
		ISettablePostbackDefaultActionOfCarouselTemplate UsePostbackDefaultAction( string label , string data );

		/// <summary>
		/// デフォルトアクションにメッセージを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="text">アクションの実行時に送信されるテキスト</param>
		/// <returns>ビルドしかできない</returns>
		IBuildOnlyDefaultActionOfCarouselTemplate UseMessageDefaultAction( string label , string text );

		/// <summary>
		/// デフォルトアクションにURIを使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="uri">アクションの実行時に開かれるURI</param>
		/// <returns>ビルドしかできない</returns>
		IBuildOnlyDefaultActionOfCarouselTemplate UseUriDefaultAction( string label , string uri );

		/// <summary>
		/// デフォルトアクションに日時選択を使用する
		/// </summary>
		/// <param name="label">アクションのラベル</param>
		/// <param name="data">ポストバックのデータ</param>
		/// <param name="mode">アクションモード</param>
		/// <returns>日時選択の設定＋ビルド</returns>
		ISettableDatetimePickerDefaultActionOfCarouselTemplate UseDatetimePickerDefaultAction( string label , string data , string mode );

	}

}

	