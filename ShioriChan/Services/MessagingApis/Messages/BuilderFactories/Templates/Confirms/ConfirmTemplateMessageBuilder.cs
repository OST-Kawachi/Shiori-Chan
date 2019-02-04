using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Templates.Confirms;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {

	public partial class MessageBuilderFactory {

		/// <summary>
		/// 確認テンプレートBuilder
		/// </summary>
		private class ConfirmTemplateMessageBuilder : IConfirmTemplateMessageBuilder {

			/// <summary>
			/// 送信パラメータ
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信パラメータ</param>
			public ConfirmTemplateMessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

			/// <summary>
			/// テンプレートのBuild
			/// </summary>
			/// <returns>ビルド可能なメッセージBuilder</returns>
			public IMessageFactory BuildTemplate()
				=> new MessageBuilder( this.parameter );

		}

	}

}
