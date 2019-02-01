namespace ShioriChan.Services.MessagingApis.Messages.Builders.QuickReplies {

	/// <summary>
	/// 任意項目について設定可能なQuickReply用Builder
	/// </summary>
	public class SettableDatepickerActionQuickReplyBuilder : BuildableQuickReplyBuilder {

		/// <summary>
		/// 日付または時刻の初期値設定
		/// </summary>
		/// <param name="initial">日付または時刻の初期値</param>
		/// <returns>自身のBuilderクラス</returns>
		public SettableDatepickerActionQuickReplyBuilder SetInitial( string initial )
			=> this;

		/// <summary>
		/// 選択可能な日付または時刻の最大値設定
		/// </summary>
		/// <param name="max">選択可能な日付または時刻の最大値</param>
		/// <returns>自身のBuilderクラス</returns>
		public SettableDatepickerActionQuickReplyBuilder SetMax( string max )
			=> this;

		/// <summary>
		/// 選択可能な日付または時刻の最小値設定
		/// </summary>
		/// <param name="min">選択可能な日付または時刻の最小値</param>
		/// <returns>自身のBuilderクラス</returns>
		public SettableDatepickerActionQuickReplyBuilder SetMin( string min )
			=> this;

	}
	
}
