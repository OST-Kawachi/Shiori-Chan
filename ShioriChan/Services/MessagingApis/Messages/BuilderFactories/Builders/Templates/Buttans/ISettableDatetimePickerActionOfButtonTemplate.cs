namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// 日時選択アクションの設定＋ビルド
	/// </summary>
	public interface ISettableDatetimePickerActionOfButtonTemplate : IBuildOnlyOfButtonTemplate {

		/// <summary>
		/// 初期値の設定
		/// </summary>
		/// <param name="initial">初期値</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettableDatetimePickerActionOfButtonTemplate SetInitial( string initial );

		/// <summary>
		/// 選択可能な日付または時刻の最大値
		/// </summary>
		/// <param name="max">最大値</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettableDatetimePickerActionOfButtonTemplate SetMax( string max );

		/// <summary>
		/// 選択可能な日付または時刻の最小値
		/// </summary>
		/// <param name="min">最小値</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettableDatetimePickerActionOfButtonTemplate SetMin( string min );

	}

}
