using ShioriChan.Services.MessagingApis.Messages.Builders.Templates.Buttons;

namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	public partial class MessageBuilder {

		/// <summary>
		/// ボタンテンプレートBuilder
		/// </summary>
		private class ButtonTemplateMessageBuilder : IButtonTemplateMessageBuilder {

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

		}

	}

}
