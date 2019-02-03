namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	public partial class MessageBuilder {

		/// <summary>
		/// QuickReply用Builder
		/// 直接インスタンス生成してほしくないのでprivateとする
		/// </summary>
		private class QuickReplyBuilder : IQuickReplyBuilder , ISelectActionOnlyQuickReplyBuilder , ISettableDatepickerActionQuickReplyBuilder {

			/// <summary>
			/// 送信用Parameter
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信用Parameter</param>
			public QuickReplyBuilder( MessageParameter parameter ) => this.parameter = parameter;

			/// <summary>
			/// アイテムの追加
			/// </summary>
			/// <param name="imageUrl">ボタンの先頭に表示するアイコン</param>
			/// <returns>QuickReplyのアクション設定クラス</returns>
			public ISelectActionOnlyQuickReplyBuilder AddItem( string imageUrl )
				=> this;

			/// <summary>
			/// ポストバックアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <param name="data">データ</param>
			/// <param name="displayText">表示テキスト</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IQuickReplyBuilder UsePostbackAction( string label , string data , string displayText )
				=> this;

			/// <summary>
			/// メッセージアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IQuickReplyBuilder UseMessageAction( string label , string text )
				=> this;

			/// <summary>
			/// 日時選択アクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <param name="data">データ</param>
			/// <param name="mode">モード</param>
			/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
			public ISettableDatepickerActionQuickReplyBuilder UseDatepickerAction( string label , string data , string mode )
				=> this;

			/// <summary>
			/// カメラアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IQuickReplyBuilder UseCameraAction( string label )
				=> this;

			/// <summary>
			/// カメラロールアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IQuickReplyBuilder UseCameraRoll( string label )
				=> this;

			/// <summary>
			/// 位置情報アクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IQuickReplyBuilder UseLocation( string label )
				=> this;

			/// <summary>
			/// 日付または時刻の初期値設定
			/// </summary>
			/// <param name="initial">日付または時刻の初期値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionQuickReplyBuilder SetInitial( string initial )
				=> this;

			/// <summary>
			/// 選択可能な日付または時刻の最大値設定
			/// </summary>
			/// <param name="max">選択可能な日付または時刻の最大値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionQuickReplyBuilder SetMax( string max )
				=> this;

			/// <summary>
			/// 選択可能な日付または時刻の最小値設定
			/// </summary>
			/// <param name="min">選択可能な日付または時刻の最小値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionQuickReplyBuilder SetMin( string min )
				=> this;

			/// <summary>
			/// QuickReplyのBuild
			/// </summary>
			/// <returns>ビルドしかできないMessageBuilder</returns>
			public IBuildOnlyMessageBuilder BuildQuickReply() => new MessageBuilder( this.parameter );

		}

	}

}
