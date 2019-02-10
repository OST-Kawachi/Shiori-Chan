using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public partial class MessageBuilderFactory {

		/// <summary>
		/// 確認テンプレートBuilder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class CarouselTemplateMessageBuilder :
			IBuildableCarouselTemplateMessageBuilder,
			ICarouselTemplateMessageBuilder,
			ISelectDefaultActionCarouselTemplateMessageBuilder,
			ISelectOnlyColumnActionCarouselTemplateMessageBuilder,
			ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder,
			ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder,
			ISettablePostbackColumnActionCarouselTemplateMessageBuilder,
			ISettablePostbackDefaultActionCarouselTemplateMessageBuilder 
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

			public ISelectOnlyColumnActionCarouselTemplateMessageBuilder AddAction() => this;
			public IColumnSettingOnlyCarouselTemplateMessageBuilder AddColumn( string text ) => this;
			public IBuildableCarouselTemplateMessageBuilder BuildColumnAction() => this;
			public IColumnSettingOnlyCarouselTemplateMessageBuilder BuildDefaultAction() => this;
			public IMessageBuilder BuildTemplate() => new MessageBuilder( this.parameter );
			public IBuildOnlyColumnActionCarouselTemplateMessageBuilder SetColumnDisplayText( string displayText ) => this;
			public ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder SetColumnInitial( string initial ) => this;
			public ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder SetColumnMax( string max ) => this;
			public ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder SetColumnMin( string min ) => this;
			public ISelectDefaultActionCarouselTemplateMessageBuilder SetDefaultAction() => this;
			public IBuildOnlyDefaultActionCarouselTemplateMessageBuilder SetDefaultDisplayText( string displayText ) => this;
			public ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder SetDefaultInitial( string initial ) => this;
			public ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder SetDefaultMax( string max ) => this;
			public ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder SetDefaultMin( string min ) => this;
			public IAddAndSetOnlyCarouselTemplateMessageBuilder SetImageAspectRatio( string imageAspectRatio ) => this;
			public IColumnSettingOnlyCarouselTemplateMessageBuilder SetImageBackgroundColor( string imageBackgroundColor ) => this;
			public IAddAndSetOnlyCarouselTemplateMessageBuilder SetImageSize( string imageSize ) => this;
			public IColumnSettingOnlyCarouselTemplateMessageBuilder SetThumbnailImageUrl( string thumbnailImageUrl ) => this;
			public IColumnSettingOnlyCarouselTemplateMessageBuilder SetTitle( string title ) => this;
			public ISettableDatetimePickerColumnActionCarouselTemplateMessageBuilder UseDatetimePickerAction( string label , string data , string mode ) => this;
			public ISettableDatetimePickerDefaultActionCarouselTemplateMessageBuilder UseDatetimePickerDefaultAction( string label , string data , string mode ) => this;
			public IBuildOnlyColumnActionCarouselTemplateMessageBuilder UseMessageColumnAction( string label , string text ) => this;
			public IBuildOnlyDefaultActionCarouselTemplateMessageBuilder UseMessageDefaultAction( string label , string text ) => this;
			public ISettablePostbackColumnActionCarouselTemplateMessageBuilder UsePostbackColumnAction( string label , string data ) => this;
			public ISettablePostbackDefaultActionCarouselTemplateMessageBuilder UsePostbackDefaultAction( string label , string data ) => this;
			public IBuildOnlyColumnActionCarouselTemplateMessageBuilder UseUriColumnAction( string label , string uri ) => this;
			public IBuildOnlyDefaultActionCarouselTemplateMessageBuilder UseUriDefaultAction( string label , string uri ) => this;
		}

	}
}

	