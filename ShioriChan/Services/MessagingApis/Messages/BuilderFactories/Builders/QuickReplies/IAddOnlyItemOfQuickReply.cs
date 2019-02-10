namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// Item追加のみができるQuickReplyBuilder
	/// </summary>
	public interface IAddOnlyItemOfQuickReply {

		/// <summary>
		/// アイテムの追加
		/// </summary>
		/// <param name="imageUrl">ボタンの先頭に表示するアイコン</param>
		/// <returns>QuickReplyのアクション設定クラス</returns>
		ISelectOnlyActionOfQuickReply AddItem( string imageUrl );

	}

}
