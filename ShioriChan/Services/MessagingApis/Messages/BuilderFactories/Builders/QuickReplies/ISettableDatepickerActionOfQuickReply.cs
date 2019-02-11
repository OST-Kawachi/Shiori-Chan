namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// ビルド＋アイテム追加＋Datepickerの設定
	/// </summary>
	public interface ISettableDatepickerActionOfQuickReply : IBuildOrAddItemOfQuickReply {

		/// <summary>
		/// 日付または時刻の初期値設定
		/// </summary>
		/// <param name="initial">日付または時刻の初期値</param>
		/// <returns>ビルド＋アイテム追加＋Datepickerの設定</returns>
		ISettableDatepickerActionOfQuickReply SetInitial( string initial );

		/// <summary>
		/// 選択可能な日付または時刻の最大値設定
		/// </summary>
		/// <param name="max">選択可能な日付または時刻の最大値</param>
		/// <returns>ビルド＋アイテム追加＋Datepickerの設定</returns>
		ISettableDatepickerActionOfQuickReply SetMax( string max );

		/// <summary>
		/// 選択可能な日付または時刻の最小値設定
		/// </summary>
		/// <param name="min">選択可能な日付または時刻の最小値</param>
		/// <returns>ビルド＋アイテム追加＋Datepickerの設定</returns>
		ISettableDatepickerActionOfQuickReply SetMin( string min );

	}

}
