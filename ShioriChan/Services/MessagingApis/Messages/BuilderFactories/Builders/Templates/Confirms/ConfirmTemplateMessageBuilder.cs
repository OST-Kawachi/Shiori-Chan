using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// 確認テンプレートBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class ConfirmTemplateMessageBuilder : 
			ISelectOnlyPositiveActionOfConfirmTemplate,
			ISettablePositivePostbackActionOfConfirmTemplate,
			ISettablePositiveDatetimePickerActionOfConfirmTemplate,
			ISelectOnlyNegativeActionOfConfirmTemplate,
			ISettableNegativePostbackActionOfConfirmTemplate,
			ISettableNegativeDatetimePickerActionOfConfirmTemplate 
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
			public ISelectOnlyNegativeActionOfConfirmTemplate BuildPositiveAction() => this;
			public ISettableNegativePostbackActionOfConfirmTemplate SetNegativeDisplayText( string displayText ) => this;
			public ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeInitial( string initial ) => this;
			public ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeMax( string max ) => this;
			public ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeMin( string min ) => this;
			public ISettablePositivePostbackActionOfConfirmTemplate SetPositiveDisplayText( string displayText ) => this;
			public ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveInitial( string initial ) => this;
			public ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMax( string max ) => this;
			public ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMin( string min ) => this;
			public ISettableNegativeDatetimePickerActionOfConfirmTemplate UseDatetimePickerNegativeAction( string label , string data , string mode ) => this;
			public ISettablePositiveDatetimePickerActionOfConfirmTemplate UseDatetimePickerPositiveAction( string label , string data , string mode ) => this;
			public IBuildOnlyNegativeActionOfConfirmTemplate UseMessageNegativeAction( string label , string text ) => this;
			public IBuildOnlyPositiveActionOfConfirmTemplate UseMessagePositiveAction( string label , string text ) => this;
			public ISettableNegativePostbackActionOfConfirmTemplate UsePostbackNegativeAction( string label , string data ) => this;
			public ISettablePositivePostbackActionOfConfirmTemplate UsePostbackPositiveAction( string label , string data ) => this;
			public IBuildOnlyNegativeActionOfConfirmTemplate UseUriNegativeAction( string label , string uri ) => this;
			public IBuildOnlyPositiveActionOfConfirmTemplate UseUriPositiveAction( string label , string uri ) => this;

		}

	}
}
