namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	public partial class MessageBuilder {

		/// <summary>
		/// テンプレートMessageBuilder
		/// 直接インスタンス生成してほしくないのでprivateとする
		/// </summary>
		private class TemplateMessageBuilder : ISelectOnlyTemplateMessageBuilder {

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
			public IButtonTemplateMessageBuilder UseButtonTemplate( string text )
				=> new ButtonTemplateMessageBuilder( this.parameter );

			/// <summary>
			/// 確認テンプレートを使用する
			/// </summary>
			/// <param name="text">テキスト</param>
			/// <returns>確認テンプレートBuilder</returns>
			public IConfirmTemplateMessageBuilder UseConfirmTemplate( string text )
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
			public IAddColumnOnlyImageCarouselTemplateMessageBuilder UseImageCarouselTemplateMessageBuilder()
				=> new ImageCarouselTemplateMessageBuilder( this.parameter );
		}

	}

}
