using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// ボタンテンプレートBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class ButtonTemplateMessageBuilder : 
			ISettableButtonTemplate, 
			ISelectOnlyActionOfButtonTemplate, 
			ISettableDatetimePickerActionOfButtonTemplate, 
			ISettablePostbackActionOfButtonTemplate 
		{

			/// <summary>
			/// 送信パラメータ
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信パラメータ</param>
			public ButtonTemplateMessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

			/// <summary>
			/// 画像URL設定
			/// </summary>
			/// <param name="thumbnailImageUrl">画像URL</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetThumbnailImageUrl( string thumbnailImageUrl ) {
				this.parameter.Messages.Last[ "template" ][ "thumbnailImageUrl" ] = thumbnailImageUrl;
				return this;
			}

			/// <summary>
			/// 画像のアスペクト比設定
			/// </summary>
			/// <param name="imageAspectRatio">画像のアスペクト比</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetImageAspectRatio( string imageAspectRatio ) {
				this.parameter.Messages.Last[ "template" ][ "imageAspectRatio" ] = imageAspectRatio;
				return this;
			}

			/// <summary>
			/// 画像の表示形式設定
			/// </summary>
			/// <param name="imageSize">画像の表示形式</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetImageSize( string imageSize ) {
				this.parameter.Messages.Last[ "template" ][ "imageSize" ] = imageSize;
				return this;
			}

			/// <summary>
			/// 画像の背景色設定
			/// </summary>
			/// <param name="imageBackGroundColor">画像の背景色</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetImageBackgroundColor( string imageBackGroundColor ) {
				this.parameter.Messages.Last[ "template" ][ "imageBackGroundColor" ] = imageBackGroundColor;
				return this;
			}

			/// <summary>
			/// タイトル
			/// </summary>
			/// <param name="title">タイトル</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetTitle( string title ) {
				this.parameter.Messages.Last[ "template" ][ "title" ] = title;
				return this;
			}

			/// <summary>
			/// テンプレートのBuild
			/// </summary>
			/// <returns>ビルド可能なメッセージBuilder</returns>
			public IMessageBuilder BuildTemplate()
				=> new MessageBuilder( this.parameter );

			public ISelectOnlyActionOfButtonTemplate SetAction() {
				JArray actions = (JArray)this.parameter.Messages.Last[ "template" ][ "actions" ];
				actions.Add( new JObject() );
				this.parameter.Messages.Last[ "template" ][ "actions" ] = actions;
				return this;
			}

			public ISettablePostbackActionOfButtonTemplate UsePostbackAction(
				string label ,
				string data
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "postback";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "data" ] = data;
				return this;
			}

			public IBuildOnlyOfButtonTemplate UseMessageAction( 
				string label , 
				string text
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "message";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "text" ] = text;
				return this;
			}

			public IBuildOnlyOfButtonTemplate UseUriAction( string label , string uri ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "uri";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "uir" ] = uri;
				return this;
			}

			public ISettableDatetimePickerActionOfButtonTemplate UseDatetimePickerAction(
				string label ,
				string data ,
				string mode
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "datetimepicker";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "data" ] = data;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "mode" ] = mode;
				return this;
			}

			public IBuildOnlyOfButtonTemplate SetDisplayText( string displayText ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "displayText" ] = displayText;
				return this;
			}

			public ISettableDatetimePickerActionOfButtonTemplate SetInitial( string initial ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "initial" ] = initial;
				return this;
			}

			public ISettableDatetimePickerActionOfButtonTemplate SetMax( string max ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "max" ] = max;
				return this;
			}

			public ISettableDatetimePickerActionOfButtonTemplate SetMin( string min ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "min" ] = min;
				return this;
			}

		}

	}
}
