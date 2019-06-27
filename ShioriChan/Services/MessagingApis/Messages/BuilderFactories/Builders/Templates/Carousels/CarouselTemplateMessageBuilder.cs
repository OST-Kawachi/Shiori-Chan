using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// 確認テンプレートBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class CarouselTemplateMessageBuilder :
			ISelectColumnActionOfCarouselTemplate,
			IBuildAndAddColumnOfCarouselTemplate,
			ISelectDefaultActionOfCarouselTemplate,
			ISettablePostbackColumnActionOfCarouselTemplate,
			ISettablePostbackDefaultActionOfCarouselTemplate,
			ISettableDatetimePickerDefaultActionOfCarouselTemplate,
			ISettableDatetimePickerColumnActionOfCarouselTemplate,
			ISettableAndAddColumnOfCarouselTemplate,
			ISettableColumnOfCarouselTemplate
		{

			/// <summary>
			/// 送信パラメータ
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信パラメータ</param>
			public CarouselTemplateMessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

			public ISelectColumnActionOfCarouselTemplate AddAction() {
				JArray actions = (JArray)this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ];
				actions.Add( new JObject() );
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ] = actions;
				return this;
			}

			public ISettableColumnOfCarouselTemplate AddColumn( string text ) {
				JArray columns = (JArray)this.parameter.Messages.Last[ "template" ][ "columns" ];
				columns.Add( new JObject(){
					{ "actions" , new JArray() },
                    { "text" , text }
				} );
				this.parameter.Messages.Last[ "template" ][ "columns" ] = columns;
				return this;
			}

			public IBuildAndAddColumnOfCarouselTemplate BuildColumnAction() => this;

			public ISettableColumnOfCarouselTemplate BuildDefaultAction() => this;

			public IMessageBuilder BuildTemplate() => new MessageBuilder( this.parameter );

			public IBuildAndAddColumnActionOfCarouselTemplate SetColumnDisplayText( string displayText ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "displayText" ] = displayText;
				return this;
			}

			public ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnInitial( string initial ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "initial" ] = initial;
				return this;
			}

			public ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnMax( string max ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "max" ] = max;
				return this;
			}

			public ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnMin( string min ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "min" ] = min;
				return this;
			}

			public ISelectDefaultActionOfCarouselTemplate SetDefaultAction() {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ] = new JObject();
				return this;
			}

			public IBuildOnlyDefaultActionOfCarouselTemplate SetDefaultDisplayText( string displayText ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "displayText" ] = displayText;
				return this;
			}

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultInitial( string initial ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "initial" ] = initial;
				return this;
			}

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultMax( string max ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "max" ] = max;
				return this;
			}

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultMin( string min ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "min" ] = min;
				return this;
			}

			public ISettableAndAddColumnOfCarouselTemplate SetImageAspectRatio( string imageAspectRatio ) {
				this.parameter.Messages.Last[ "template" ][ "imageAspectRatio" ] = imageAspectRatio;
				return this;
			}
				
			public ISettableColumnOfCarouselTemplate SetImageBackgroundColor( string imageBackgroundColor ) {
				this.parameter.Messages.Last[ "template" ][ "imageBackgroundColor" ] = imageBackgroundColor;
				return this;
			}

			public ISettableAndAddColumnOfCarouselTemplate SetImageSize( string imageSize ) {
				this.parameter.Messages.Last[ "template" ][ "imageSize" ] = imageSize;
				return this;
			}

			public ISettableColumnOfCarouselTemplate SetThumbnailImageUrl( string thumbnailImageUrl ) {
				this.parameter.Messages.Last[ "template" ]["columns"].Last[ "thumbnailImageUrl" ] = thumbnailImageUrl;
				return this;
			}

			public ISettableColumnOfCarouselTemplate SetTitle( string title ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "title" ] = title;
				return this;
			}

			public ISettableDatetimePickerColumnActionOfCarouselTemplate UseDatetimePickerAction( 
				string label , 
				string data , 
				string mode
			) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "type" ] = "datetimepicker";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "data" ] = data;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "mode" ] = mode;
				return this;
			}

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate UseDatetimePickerDefaultAction(
				string label ,
				string data , 
				string mode
			) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "type" ] = "datetimepicker";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "data" ] = data;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "mode" ] = mode;
				return this;
			}

			public IBuildAndAddColumnActionOfCarouselTemplate UseMessageColumnAction( string label , string text ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "type" ] = "message";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "text" ] = text;
				return this;
			}

			public IBuildOnlyDefaultActionOfCarouselTemplate UseMessageDefaultAction( string label , string text ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "type" ] = "message";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "text" ] = text;
				return this;
			}

			public ISettablePostbackColumnActionOfCarouselTemplate UsePostbackColumnAction( string label , string data ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "type" ] = "postback";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "data" ] = data;
				return this;
			}

			public ISettablePostbackDefaultActionOfCarouselTemplate UsePostbackDefaultAction( string label , string data ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "type" ] = "postback";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "data" ] = data;
				return this;
			}

			public IBuildAndAddColumnActionOfCarouselTemplate UseUriColumnAction( string label , string uri ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "type" ] = "uri";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "actions" ].Last[ "uri" ] = uri;
				return this;
			}

			public IBuildOnlyDefaultActionOfCarouselTemplate UseUriDefaultAction( string label , string uri ) {
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "type" ] = "uri";
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "label" ] = label;
				this.parameter.Messages.Last[ "template" ][ "columns" ].Last[ "defaultAction" ][ "uri" ] = uri;
				return this;
			}

		}

	}
}

	