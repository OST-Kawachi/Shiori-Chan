namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms {

	/// <summary>
	/// 日時選択アクションの設定＋ビルド
	/// </summary>
	public interface ISettablePositiveDatetimePickerActionOfConfirmTemplate : IBuildOnlyPositiveActionOfConfirmTemplate {

		/// <summary>
		/// 日付または時刻の初期値
		/// </summary>
		/// <param name="initial">初期値</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveInitial( string initial );

		/// <summary>
		/// 選択可能な日付または時刻の最大値
		/// </summary>
		/// <param name="max">最大値</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMax( string max );

		/// <summary>
		/// 選択可能な日付または時刻の最小値
		/// </summary>
		/// <param name="min">最小値</param>
		/// <returns>日時選択アクションの設定＋ビルド</returns>
		ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMin( string min );

	}

}
