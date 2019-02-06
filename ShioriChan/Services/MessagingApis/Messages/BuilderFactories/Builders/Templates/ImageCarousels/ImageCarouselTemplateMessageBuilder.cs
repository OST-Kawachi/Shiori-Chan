using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.ImageCarousels;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// Imageカルーセル用MessageBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class ImageCarouselTemplateMessageBuilder : IImageCarouselTemplateMessageBuilder {

			/// <summary>
			/// 送信パラメータ
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信パラメータ</param>
			public ImageCarouselTemplateMessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

			/// <summary>
			/// カラム追加
			/// </summary>
			/// <param name="imageUrl">画像URL</param>
			/// <returns>ビルド可能な自身の子クラス</returns>
			public IImageCarouselTemplateMessageBuilder AddColumn( string imageUrl )
				=> this;

			/// <summary>
			/// テンプレートのBuild
			/// </summary>
			/// <returns>ビルド可能なメッセージBuilder</returns>
			public IMessageBuilder BuildTemplate()
				=> new MessageBuilder( this.parameter );

		}

	}
}
