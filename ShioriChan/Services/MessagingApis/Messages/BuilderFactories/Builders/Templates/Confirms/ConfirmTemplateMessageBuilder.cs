using Newtonsoft.Json.Linq;
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

			public ISelectOnlyNegativeActionOfConfirmTemplate BuildPositiveAction() {
				JArray actions = (JArray)this.parameter.Messages.Last[ "template" ][ "actions" ];
				actions.Add( new JObject() );
				this.parameter.Messages.Last[ "template" ][ "actions" ] = actions;
				return this;
			}
			public ISettableNegativePostbackActionOfConfirmTemplate SetNegativeDisplayText( string displayText ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "displayText" ] = displayText;
				return this;
			}

			public ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeInitial( string initial ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "initial" ] = initial;
				return this;
			}

			public ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeMax( string max ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "max" ] = max;
				return this;
			}

			public ISettableNegativeDatetimePickerActionOfConfirmTemplate SetNegativeMin( string min ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "min" ] = min;
				return this;
			}

			public ISettablePositivePostbackActionOfConfirmTemplate SetPositiveDisplayText( string displayText ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "displayText" ] = displayText;
				return this;
			}

			public ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveInitial( string initial ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "initial" ] = initial;
				return this;
			}

			public ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMax( string max ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "max" ] = max;
				return this;
			}

			public ISettablePositiveDatetimePickerActionOfConfirmTemplate SetPositiveMin( string min ) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "min" ] = min;
				return this;
			}

			public ISettableNegativeDatetimePickerActionOfConfirmTemplate UseDatetimePickerNegativeAction(
				string label , 
				string data , 
				string mode
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "datetimepicker";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "data" ] = data;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "mode" ] = mode;
				return this;
			}

			public ISettablePositiveDatetimePickerActionOfConfirmTemplate UseDatetimePickerPositiveAction(
				string label ,
				string data ,
				string mode
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "datetimepicker";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "data" ] = data;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "mode" ] = mode;
				return this;
			}

			public IBuildOnlyNegativeActionOfConfirmTemplate UseMessageNegativeAction(
				string label , 
				string text
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "message";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "text" ] = text;
				return this;
			}

			public IBuildOnlyPositiveActionOfConfirmTemplate UseMessagePositiveAction(
				string label ,
				string text
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "message";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "text" ] = text;
				return this;
			}

			public ISettableNegativePostbackActionOfConfirmTemplate UsePostbackNegativeAction(
				string label , 
				string data 
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "postback";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "data" ] = data;
				return this;
			}

			public ISettablePositivePostbackActionOfConfirmTemplate UsePostbackPositiveAction(
				string label , 
				string data 
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "postback";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "data" ] = data;
				return this;
			}

			public IBuildOnlyNegativeActionOfConfirmTemplate UseUriNegativeAction( 
				string label , 
				string uri
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "uri";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "uri" ] = uri;
				return this;
			}

			public IBuildOnlyPositiveActionOfConfirmTemplate UseUriPositiveAction(
				string label ,
				string uri
			) {
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "type" ] = "uri";
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "actions" ].Last[ "uri" ] = uri;
				return this;
			}

		}

	}
}
