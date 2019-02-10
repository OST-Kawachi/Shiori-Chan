using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.ImageCarousels;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// テンプレートMessageBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class TemplateMessageBuilder : ISelectOnlyTemplate {

			/// <summary>
			/// 送信用パラメータ
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信用パラメータ</param>
			public TemplateMessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

			/// <summary>
			/// ボタンテンプレートを使用する
			/// </summary>
			/// <param name="text">テキスト</param>
			/// <returns>ボタンテンプレートBuilder</returns>
			public ISettableButtonTemplate UseButtonTemplate( string text )
				=> new ButtonTemplateMessageBuilder( this.parameter );

			/// <summary>
			/// 確認テンプレートを使用する
			/// </summary>
			/// <param name="text">テキスト</param>
			/// <returns>確認テンプレートBuilder</returns>
			public ISelectOnlyPositiveActionOfConfirmTemplate UseConfirmTemplate( string text )
				=> new ConfirmTemplateMessageBuilder( this.parameter );

			/// <summary>
			/// カルーセルテンプレートを使用する
			/// </summary>
			/// <returns>カルーセルテンプレートBuilder </returns>
			public IAddAndSetOnlyCarouselTemplateMessageBuilder UseCarouselTemplateMessageBuilder()
				=> new CarouselTemplateMessageBuilder( this.parameter );

			/// <summary>
			/// 画像カルーセルテンプレートを使用する
			/// </summary>
			/// <returns>画像カルーセルテンプレートBuilder</returns>
			public IAddOnlyColumnOfImageCarouselTemplate UseImageCarouselTemplateMessageBuilder()
				=> new ImageCarouselTemplateMessageBuilder( this.parameter );
		}

	}

}
