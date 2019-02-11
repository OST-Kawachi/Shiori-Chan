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

			public ISelectColumnActionOfCarouselTemplate AddAction() => this;

			public ISettableColumnOfCarouselTemplate AddColumn( string text ) => this;

			public IBuildAndAddColumnOfCarouselTemplate BuildColumnAction() => this;

			public ISettableColumnOfCarouselTemplate BuildDefaultAction() => this;

			public IMessageBuilder BuildTemplate() => new MessageBuilder( this.parameter );

			public IBuildAndAddColumnActionOfCarouselTemplate SetColumnDisplayText( string displayText ) => this;

			public ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnInitial( string initial ) => this;

			public ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnMax( string max ) => this;

			public ISettableDatetimePickerColumnActionOfCarouselTemplate SetColumnMin( string min ) => this;

			public ISelectDefaultActionOfCarouselTemplate SetDefaultAction() => this;

			public IBuildOnlyDefaultActionOfCarouselTemplate SetDefaultDisplayText( string displayText ) => this;

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultInitial( string initial ) => this;

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultMax( string max ) => this;

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate SetDefaultMin( string min ) => this;

			public ISettableAndAddColumnOfCarouselTemplate SetImageAspectRatio( string imageAspectRatio ) => this;

			public ISettableColumnOfCarouselTemplate SetImageBackgroundColor( string imageBackgroundColor ) => this;

			public ISettableAndAddColumnOfCarouselTemplate SetImageSize( string imageSize ) => this;

			public ISettableColumnOfCarouselTemplate SetThumbnailImageUrl( string thumbnailImageUrl ) => this;

			public ISettableColumnOfCarouselTemplate SetTitle( string title ) => this;

			public ISettableDatetimePickerColumnActionOfCarouselTemplate UseDatetimePickerAction( string label , string data , string mode ) => this;

			public ISettableDatetimePickerDefaultActionOfCarouselTemplate UseDatetimePickerDefaultAction( string label , string data , string mode ) => this;

			public IBuildAndAddColumnActionOfCarouselTemplate UseMessageColumnAction( string label , string text ) => this;

			public IBuildOnlyDefaultActionOfCarouselTemplate UseMessageDefaultAction( string label , string text ) => this;

			public ISettablePostbackColumnActionOfCarouselTemplate UsePostbackColumnAction( string label , string data ) => this;

			public ISettablePostbackDefaultActionOfCarouselTemplate UsePostbackDefaultAction( string label , string data ) => this;

			public IBuildAndAddColumnActionOfCarouselTemplate UseUriColumnAction( string label , string uri ) => this;

			public IBuildOnlyDefaultActionOfCarouselTemplate UseUriDefaultAction( string label , string uri ) => this;

		}

	}
}

	