﻿namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// 日時選択の設定＋ビルド
	/// </summary>
	public interface ISettableDatetimePickerDefaultActionOfCarouselTemplate : IBuildOnlyDefaultActionOfCarouselTemplate {

		/// <summary>
		/// 日時または時刻の初期値
		/// </summary>
		/// <param name="initial">初期値</param>
		/// <returns>日時選択の設定＋ビルド</returns>
		ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultInitial( string initial );

		/// <summary>
		/// 選択可能な日付または時刻の最大値
		/// </summary>
		/// <param name="max">最大値</param>
		/// <returns>日時選択の設定＋ビルド</returns>
		ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultMax( string max );

		/// <summary>
		/// 選択可能な日付または時刻の最小値
		/// </summary>
		/// <param name="min">最小値</param>
		/// <returns>日時選択の設定＋ビルド</returns>
		ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultMin( string min );

	}

}
