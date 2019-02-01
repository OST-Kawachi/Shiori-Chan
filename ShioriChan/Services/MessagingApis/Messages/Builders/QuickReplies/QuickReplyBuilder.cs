namespace ShioriChan.Services.MessagingApis.Messages.Builders.QuickReplies {

	/// <summary>
	/// QuickReply用Builder
	/// </summary>
	public class QuickReplyBuilder {

		/// <summary>
		/// アイテムの追加
		/// </summary>
		/// <param name="imageUrl">ボタンの先頭に表示するアイコン</param>
		/// <returns>QuickReplyのアクション設定クラス</returns>
		public SettableActionQuickReplyBuilder AddItem( string imageUrl )
			=> new SettableActionQuickReplyBuilder();

	}
	
}
