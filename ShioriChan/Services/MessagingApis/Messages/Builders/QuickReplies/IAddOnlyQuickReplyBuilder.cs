namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// Item追加のみができるQuickReplyBuilder
	/// </summary>
	public interface IAddOnlyQuickReplyBuilder {

		/// <summary>
		/// アイテムの追加
		/// </summary>
		/// <param name="imageUrl">ボタンの先頭に表示するアイコン</param>
		/// <returns>QuickReplyのアクション設定クラス</returns>
		ISelectActionOnlyQuickReplyBuilder AddItem( string imageUrl );

	}

}
