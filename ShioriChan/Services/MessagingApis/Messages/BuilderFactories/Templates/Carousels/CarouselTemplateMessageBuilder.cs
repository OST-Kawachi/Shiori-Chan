using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Templates.Carousels;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {

	public partial class MessageBuilderFactory {

		/// <summary>
		/// 確認テンプレートBuilder
		/// </summary>
		private class CarouselTemplateMessageBuilder : ICarouselTemplateMessageBuilder , IColumnSettingOnlyCarouselTemplateMessageBuilder {

			/// <summary>
			/// 送信パラメータ
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信パラメータ</param>
			public CarouselTemplateMessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

			/// <summary>
			/// 画像のアスペクト比設定
			/// </summary>
			/// <param name="imageAspectRatio">画像のアスペクト比</param>
			/// <returns>自身のBuilderクラス</returns>
			public IAddAndSetOnlyCarouselTemplateMessageBuilder SetImageAspectRatio( string imageAspectRatio )
				=> this;

			/// <summary>
			/// 画像の表示形式設定
			/// </summary>
			/// <param name="imageSize">画像の表示形式</param>
			/// <returns>自身のBuilderクラス</returns>
			public IAddAndSetOnlyCarouselTemplateMessageBuilder SetImageSize( string imageSize )
				=> this;

			/// <summary>
			/// カラム追加
			/// </summary>
			/// <param name="text">テキスト</param>
			/// <returns>ビルド可能なカルーセルテンプレート用Builder</returns>
			public IColumnSettingOnlyCarouselTemplateMessageBuilder AddColumn( string text )
				=> this;

			/// <summary>
			/// 画像URL設定
			/// </summary>
			/// <param name="thumbnailImageUrl">画像URL</param>
			/// <returns>自身のクラス</returns>
			public IColumnSettingOnlyCarouselTemplateMessageBuilder SetThumbnailImageUrl( string thumbnailImageUrl )
				=> this;

			/// <summary>
			/// 画像の背景色設定
			/// </summary>
			/// <param name="imageBackgroundColor">画像の背景色</param>
			/// <returns>自身のクラス</returns>
			public IColumnSettingOnlyCarouselTemplateMessageBuilder SetImageBackgroundColor( string imageBackgroundColor )
				=> this;

			/// <summary>
			/// タイトル設定
			/// </summary>
			/// <param name="title">タイトル</param>
			/// <returns>自身のクラス</returns>
			public IColumnSettingOnlyCarouselTemplateMessageBuilder SetTitle( string title )
				=> this;

			/// <summary>
			/// 領域全体のアクションの設定
			/// </summary>
			/// <returns>自身のクラス</returns>
			public IColumnSettingOnlyCarouselTemplateMessageBuilder SetDefaultAction()
				=> this;

			/// <summary>
			/// テンプレートのBuild
			/// </summary>
			/// <returns>ビルド可能なメッセージBuilder</returns>
			public IMessageFactory BuildTemplate()
				=> new MessageBuilder( this.parameter );

		}

	}

}
