namespace ShioriChan.Services.MessagingApis.Messages.Builders.QuickReplies {

	/// <summary>
	/// QuickReplyのアクション設定クラス
	/// </summary>
	public class SettableActionQuickReplyBuilder {

		/// <summary>
		/// ポストバックアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <param name="data">データ</param>
		/// <param name="displayText">表示テキスト</param>
		/// <returns>ビルド可能なQuickReply用Builder</returns>
		public BuildableQuickReplyBuilder UsePostbackAction( string label , string data , string displayText )
			=> new BuildableQuickReplyBuilder();

		/// <summary>
		/// メッセージアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド可能なQuickReply用Builder</returns>
		public BuildableQuickReplyBuilder UseMessageAction( string label , string text )
			=> new BuildableQuickReplyBuilder();

		/// <summary>
		/// 日時選択アクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <param name="data">データ</param>
		/// <param name="mode">モード</param>
		/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
		public SettableDatepickerActionQuickReplyBuilder UseDatepickerAction( string label , string data , string mode )
			=> new SettableDatepickerActionQuickReplyBuilder();

		/// <summary>
		/// カメラアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド可能なQuickReply用Builder</returns>
		public BuildableQuickReplyBuilder UseCameraAction( string label )
			=> new BuildableQuickReplyBuilder();

		/// <summary>
		/// カメラロールアクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド可能なQuickReply用Builder</returns>
		public BuildableQuickReplyBuilder UseCameraRoll( string label )
			=> new BuildableQuickReplyBuilder();

		/// <summary>
		/// 位置情報アクションを使用する
		/// </summary>
		/// <param name="label">ラベル</param>
		/// <returns>ビルド可能なQuickReply用Builder</returns>
		public BuildableQuickReplyBuilder UseLocation( string label )
			=> new BuildableQuickReplyBuilder();

	}
	
}
