namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// ポストバックの設定＋ビルド
	/// </summary>
	public interface ISettablePostbackDefaultActionOfCarouselTemplate : IBuildOnlyDefaultActionOfCarouselTemplate {

		/// <summary>
		/// アクション実行時に、ユーザのメッセージとしてLINEのトーク画面に表示されるテキスト
		/// </summary>
		/// <param name="displayText">テキスト</param>
		/// <returns>ビルドしかできない</returns>
		IBuildOnlyDefaultActionOfCarouselTemplate SetDefaultDisplayText( string displayText );

	}

}
