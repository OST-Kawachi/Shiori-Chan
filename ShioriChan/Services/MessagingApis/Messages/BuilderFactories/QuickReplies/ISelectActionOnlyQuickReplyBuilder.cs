namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.QuickReplies {

	/// <summary>
	/// アクションの選択のみできるQuickReplyBuilder
	/// </summary>
	public interface ISelectActionOnlyQuickReplyBuilder {

		/// <summary>
		/// ポストバックアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <param name="data">データ</param>
		/// <param name="displayText">表示テキスト</param>
		/// <returns>QuickReplyBuilder</returns>
		IQuickReplyBuilder UsePostbackAction( string label , string data , string displayText );

		/// <summary>
		/// メッセージアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>QuickReplyBuilder</returns>
		IQuickReplyBuilder UseMessageAction( string label , string text );

		/// <summary>
		/// 日時選択アクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <param name="data">データ</param>
		/// <param name="mode">モード</param>
		/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
		ISettableDatepickerActionQuickReplyBuilder UseDatepickerAction( string label , string data , string mode );

		/// <summary>
		/// カメラアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>QuickReplyBuilder</returns>
		IQuickReplyBuilder UseCameraAction( string label );

		/// <summary>
		/// カメラロールアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>QuickReplyBuilder</returns>
		IQuickReplyBuilder UseCameraRoll( string label );

		/// <summary>
		/// 位置情報アクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>QuickReplyBuilder</returns>
		IQuickReplyBuilder UseLocation( string label );

	}

}
