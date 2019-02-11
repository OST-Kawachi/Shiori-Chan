namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// 日時選択の設定＋アクションのビルド＋アクションの追加
	/// </summary>
	public interface ISettableDatetimePickerColumnActionOfCarouselTemplate : IBuildAndAddColumnActionOfCarouselTemplate {

		/// <summary>
		/// 日時または時刻の初期値
		/// </summary>
		/// <param name="initial">初期値</param>
		/// <returns>日時選択の設定＋アクションのビルド＋アクションの追加</returns>
		ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnInitial( string initial );

		/// <summary>
		/// 選択可能な日付または時刻の最大値
		/// </summary>
		/// <param name="max">最大値</param>
		/// <returns>日時選択の設定＋アクションのビルド＋アクションの追加</returns>
		ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnMax( string max );

		/// <summary>
		/// 選択可能な日付または時刻の最小値
		/// </summary>
		/// <param name="min">最小値</param>
		/// <returns>日時選択の設定＋アクションのビルド＋アクションの追加</returns>
		ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnMin( string min );

	}

}


