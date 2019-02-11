namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies {

	/// <summary>
	/// クイックリプライのアクション選択
	/// </summary>
	public interface ISelectOnlyActionOfQuickReply {

		/// <summary>
		/// ポストバックアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <param name="data">データ</param>
		/// <param name="displayText">表示テキスト</param>
		/// <returns>ビルド＋アイテム追加</returns>
		IBuildOrAddItemOfQuickReply UsePostbackAction( string label , string data , string displayText );

		/// <summary>
		/// メッセージアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド＋アイテム追加</returns>
		IBuildOrAddItemOfQuickReply UseMessageAction( string label , string text );

		/// <summary>
		/// 日時選択アクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <param name="data">データ</param>
		/// <param name="mode">モード</param>
		/// <returns>ビルド＋アイテム追加＋Datepickerの設定</returns>
		ISettableDatepickerActionOfQuickReply UseDatepickerAction( string label , string data , string mode );

		/// <summary>
		/// カメラアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド＋アイテム追加</returns>
		IBuildOrAddItemOfQuickReply UseCameraAction( string label );

		/// <summary>
		/// カメラロールアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド＋アイテム追加</returns>
		IBuildOrAddItemOfQuickReply UseCameraRoll( string label );

		/// <summary>
		/// 位置情報アクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド＋アイテム追加</returns>
		IBuildOrAddItemOfQuickReply UseLocation( string label );

	}

}
