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
			/// <param name="thmbnailImageUrl">画像URL</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetThumbnailImageUrl( string thmbnailImageUrl ) => this;

			/// <summary>
			/// 画像のアスペクト比設定
			/// </summary>
			/// <param name="imageAspectRatio">画像のアスペクト比</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetImageAspectRatio( string imageAspectRatio ) => this;

			/// <summary>
			/// 画像の表示形式設定
			/// </summary>
			/// <param name="imageSize">画像の表示形式</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetImageSize( string imageSize ) => this;

			/// <summary>
			/// 画像の背景色設定
			/// </summary>
			/// <param name="imageBackGroundColor">画像の背景色</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetImageBackgroundColor( string imageBackGroundColor ) => this;

			/// <summary>
			/// タイトル
			/// </summary>
			/// <param name="title">タイトル</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableButtonTemplate SetTitle( string title ) => this;

			/// <summary>
			/// テンプレートのBuild
			/// </summary>
			/// <returns>ビルド可能なメッセージBuilder</returns>
			public IMessageBuilder BuildTemplate()
				=> new MessageBuilder( this.parameter );

			public ISelectOnlyActionOfButtonTemplate SetAction()
				=> this;

			public ISettablePostbackActionOfButtonTemplate UsePostbackAction( string label , string data ) => this;
			public IBuildOnlyOfButtonTemplate UseMessageAction( string label , string text ) => this;
			public IBuildOnlyOfButtonTemplate UseUriAction( string label , string uri ) => this;
			public ISettableDatetimePickerActionOfButtonTemplate UseDatetimePickerAction( string label , string data , string mode ) => this;
			public IBuildOnlyOfButtonTemplate SetDisplayText( string displayText ) => this;
			public ISettableDatetimePickerActionOfButtonTemplate SetInitial( string initial ) => this;
			public ISettableDatetimePickerActionOfButtonTemplate SetMax( string max ) => this;
			public ISettableDatetimePickerActionOfButtonTemplate SetMin( string min ) => this;
		}

	}
}
