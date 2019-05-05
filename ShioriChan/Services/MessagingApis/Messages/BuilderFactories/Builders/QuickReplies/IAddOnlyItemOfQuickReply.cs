namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// クイックリプライのアイテム追加
	/// </summary>
	public interface IAddOnlyItemOfQuickReply {

		/// <summary>
		/// アイテムの追加
		/// </summary>
		/// <param name="imageUrl">ボタンの先頭に表示するアイコン</param>
		/// <returns>クイックリプライのアクション選択</returns>
		ISelectOnlyActionOfQuickReply AddItem( string imageUrl );

	}

}
