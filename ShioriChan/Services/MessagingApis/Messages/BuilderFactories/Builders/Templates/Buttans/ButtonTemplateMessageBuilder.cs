using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// ボタンテンプレートBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class ButtonTemplateMessageBuilder : 
			IButtonTemplateMessageBuilder, 
			IOnlySelectActionButtonTemplateMessageBuilder, 
			ISettableDatetimePickerActionButtonTemplateMessageBuilder, 
			ISettablePostbackActionButtonTemplateMessageBuilder 
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
			public IButtonTemplateMessageBuilder SetThumbnailImageUrl( string thmbnailImageUrl ) => this;

			/// <summary>
			/// 画像のアスペクト比設定
			/// </summary>
			/// <param name="imageAspectRatio">画像のアスペクト比</param>
			/// <returns>自身のBuilderクラス</returns>
			public IButtonTemplateMessageBuilder SetImageAspectRatio( string imageAspectRatio ) => this;

			/// <summary>
			/// 画像の表示形式設定
			/// </summary>
			/// <param name="imageSize">画像の表示形式</param>
			/// <returns>自身のBuilderクラス</returns>
			public IButtonTemplateMessageBuilder SetImageSize( string imageSize ) => this;

			/// <summary>
			/// 画像の背景色設定
			/// </summary>
			/// <param name="imageBackGroundColor">画像の背景色</param>
			/// <returns>自身のBuilderクラス</returns>
			public IButtonTemplateMessageBuilder SetImageBackgroundColor( string imageBackGroundColor ) => this;

			/// <summary>
			/// タイトル
			/// </summary>
			/// <param name="title">タイトル</param>
			/// <returns>自身のBuilderクラス</returns>
			public IButtonTemplateMessageBuilder SetTitle( string title ) => this;

			/// <summary>
			/// テンプレートのBuild
			/// </summary>
			/// <returns>ビルド可能なメッセージBuilder</returns>
			public IMessageBuilder BuildTemplate()
				=> new MessageBuilder( this.parameter );

			public IOnlySelectActionButtonTemplateMessageBuilder SetAction()
				=> this;

			public ISettablePostbackActionButtonTemplateMessageBuilder UsePostbackAction( string label , string data ) => this;
			public IBuildOnlyButtonTemplateMessageBuilder UseMessageAction( string label , string text ) => this;
			public IBuildOnlyButtonTemplateMessageBuilder UseUriAction( string label , string uri ) => this;
			public ISettableDatetimePickerActionButtonTemplateMessageBuilder UseDatetimePickerAction( string label , string data , string mode ) => this;
			public IBuildOnlyButtonTemplateMessageBuilder SetDisplayText( string displayText ) => this;
			public ISettableDatetimePickerActionButtonTemplateMessageBuilder SetInitial( string initial ) => this;
			public ISettableDatetimePickerActionButtonTemplateMessageBuilder SetMax( string max ) => this;
			public ISettableDatetimePickerActionButtonTemplateMessageBuilder SetMin( string min ) => this;
		}

	}
}
