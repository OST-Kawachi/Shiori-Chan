namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// ポストバックの設定＋ビルド＋カラムの追加
	/// </summary>
	public interface ISettablePostbackColumnActionOfCarouselTemplate : IBuildAndAddColumnActionOfCarouselTemplate {

		/// <summary>
		/// アクションの実行時に、ユーザのメッセージとしてLINEのトーク画面に表示されるテキスト
		/// </summary>
		/// <param name="displayText">テキスト</param>
		/// <returns>アクションのビルド＋アクションの追加</returns>
		IBuildAndAddColumnActionOfCarouselTemplate SetColumnDisplayText( string displayText );

	}

}

