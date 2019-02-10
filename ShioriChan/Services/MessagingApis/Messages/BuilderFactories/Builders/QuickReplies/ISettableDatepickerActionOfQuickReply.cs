namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// 任意項目について設定可能なQuickReply用Builder
	/// </summary>
	public interface ISettableDatepickerActionOfQuickReply : IBuildOrAddItemOfQuickReply {

		/// <summary>
		/// 日付または時刻の初期値設定
		/// </summary>
		/// <param name="initial">日付または時刻の初期値</param>
		/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
		ISettableDatepickerActionOfQuickReply SetInitial( string initial );

		/// <summary>
		/// 選択可能な日付または時刻の最大値設定
		/// </summary>
		/// <param name="max">選択可能な日付または時刻の最大値</param>
		/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
		ISettableDatepickerActionOfQuickReply SetMax( string max );

		/// <summary>
		/// 選択可能な日付または時刻の最小値設定
		/// </summary>
		/// <param name="min">選択可能な日付または時刻の最小値</param>
		/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
		ISettableDatepickerActionOfQuickReply SetMin( string min );

	}

}
