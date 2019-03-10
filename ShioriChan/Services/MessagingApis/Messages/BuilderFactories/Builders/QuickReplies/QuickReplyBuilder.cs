using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public static partial class MessageBuilderFactory {

		/// <summary>
		/// QuickReply用Builder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class QuickReplyBuilder :
			IBuildOrAddItemOfQuickReply,
			ISelectOnlyActionOfQuickReply,
			ISettableDatepickerActionOfQuickReply 
		{

			/// <summary>
			/// 送信用Parameter
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信用Parameter</param>
			public QuickReplyBuilder( MessageParameter parameter )
				=> this.parameter = parameter;

			/// <summary>
			/// アイテムの追加
			/// </summary>
			/// <param name="imageUrl">【任意】ボタンの先頭に表示するアイコン</param>
			/// <returns>QuickReplyのアクション設定クラス</returns>
			public ISelectOnlyActionOfQuickReply AddItem( string imageUrl ) {
				JObject item = new JObject() {
					{ "type" , "action" } ,
					{ "action" , new JObject() }
				};
				if( !string.IsNullOrEmpty( imageUrl ) ) {
					item[ "imageUrl" ] = imageUrl;
				}
				JArray items = (JArray)this.parameter.Messages.Last[ "quickReply" ][ "items" ];
				items.Add( item );
				this.parameter.Messages.Last[ "quickReply" ][ "items" ] = items;
				return this;
			}

			/// <summary>
			/// ポストバックアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <param name="data">データ</param>
			/// <param name="displayText">表示テキスト</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UsePostbackAction(
				string label ,
				string data ,
				string displayText
			) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ]
					= new JObject() {
						{ "type" , "postback" } ,
						{ "label" , label } ,
						{ "data" , data } ,
						{ "displayText",displayText }
					};
				return this;
			}

			/// <summary>
			/// メッセージアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseMessageAction( 
				string label , 
				string text 
			) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ]
					= new JObject() {
						{ "type" , "message" } ,
						{ "label" , label } ,
						{ "text" , text }
					};
				return this;
			}

			/// <summary>
			/// 日時選択アクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <param name="data">データ</param>
			/// <param name="mode">モード</param>
			/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
			public ISettableDatepickerActionOfQuickReply UseDatepickerAction(
				string label ,
				string data ,
				string mode
			) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ]
					= new JObject(){
						{ "type" , "datetimepicker" } ,
						{ "label" , label } ,
						{ "data" , data } ,
						{ "mode" , mode }
					};
				return this;
			}

			/// <summary>
			/// カメラアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseCameraAction( string label ) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ]
					= new JObject() {
						{ "type" , "camera" } ,
						{ "label" , label }
					};
				return this;
			}

			/// <summary>
			/// カメラロールアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseCameraRoll( string label ) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ]
					= new JObject() {
						{ "type" , "cameraRoll" } ,
						{ "label" , label }
					};
				return this;
			}

			/// <summary>
			/// 位置情報アクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseLocation( string label ) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ]
					= new JObject() {
						{ "type", "location" } ,
						{ "label" , label }
					};
				return this;
			}

			/// <summary>
			/// 日付または時刻の初期値設定
			/// </summary>
			/// <param name="initial">日付または時刻の初期値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionOfQuickReply SetInitial( string initial ) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ][ "initial" ] = initial;
				return this;
			}

			/// <summary>
			/// 選択可能な日付または時刻の最大値設定
			/// </summary>
			/// <param name="max">選択可能な日付または時刻の最大値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionOfQuickReply SetMax( string max ) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ][ "max" ] = max;
				return this;
			}

			/// <summary>
			/// 選択可能な日付または時刻の最小値設定
			/// </summary>
			/// <param name="min">選択可能な日付または時刻の最小値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionOfQuickReply SetMin( string min ) {
				this.parameter.Messages.Last[ "quickReply" ][ "items" ].Last[ "action" ][ "min" ] = min;
				return this;
			}

			/// <summary>
			/// QuickReplyのBuild
			/// </summary>
			/// <returns>ビルドしかできないMessageBuilder</returns>
			public IBuildOnlyOfMessageBuilder BuildQuickReply() => new MessageBuilder( this.parameter );

		}

	}

}
