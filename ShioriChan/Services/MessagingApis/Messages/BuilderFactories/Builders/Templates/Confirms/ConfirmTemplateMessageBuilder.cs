using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// 確認テンプレートBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class ConfirmTemplateMessageBuilder : 
			ISelectPositiveActionConfirmTemplateMessageBuilder,
			ISettablePositivePostbackActionConfirmTemplateMessageBuilder,
			ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder,
			ISelectNegativeActionConfirmTemplateMessageBuilder,
			ISettableNegativePostbackActionConfirmTemplateMessageBuilder,
			ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder 
		{

			/// <summary>
			/// 送信パラメータ
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信パラメータ</param>
			public ConfirmTemplateMessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

			public IMessageBuilder BuildNegativeAction() => new MessageBuilder( this.parameter );
			public ISelectNegativeActionConfirmTemplateMessageBuilder BuildPositiveAction() => this;
			public ISettableNegativePostbackActionConfirmTemplateMessageBuilder SetNegativeDisplayText( string displayText ) => this;
			public ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder SetNegativeInitial( string initial ) => this;
			public ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder SetNegativeMax( string max ) => this;
			public ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder SetNegativeMin( string min ) => this;
			public ISettablePositivePostbackActionConfirmTemplateMessageBuilder SetPositiveDisplayText( string displayText ) => this;
			public ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder SetPositiveInitial( string initial ) => this;
			public ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder SetPositiveMax( string max ) => this;
			public ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder SetPositiveMin( string min ) => this;
			public ISettableNegativeDatetimePickerActionConfirmTemplateMessageBuilder UseDatetimePickerNegativeAction( string label , string data , string mode ) => this;
			public ISettablePositiveDatetimePickerActionConfirmTemplateMessageBuilder UseDatetimePickerPositiveAction( string label , string data , string mode ) => this;
			public IBuildOnlyNegativeActionConfirmTemplateMessageBuilder UseMessageNegativeAction( string label , string text ) => this;
			public IBuildOnlyPositiveActionConfirmTemplateMessageBuilder UseMessagePositiveAction( string label , string text ) => this;
			public ISettableNegativePostbackActionConfirmTemplateMessageBuilder UsePostbackNegativeAction( string label , string data ) => this;
			public ISettablePositivePostbackActionConfirmTemplateMessageBuilder UsePostbackPositiveAction( string label , string data ) => this;
			public IBuildOnlyNegativeActionConfirmTemplateMessageBuilder UseUriNegativeAction( string label , string uri ) => this;
			public IBuildOnlyPositiveActionConfirmTemplateMessageBuilder UseUriPositiveAction( string label , string uri ) => this;

		}

	}
}
