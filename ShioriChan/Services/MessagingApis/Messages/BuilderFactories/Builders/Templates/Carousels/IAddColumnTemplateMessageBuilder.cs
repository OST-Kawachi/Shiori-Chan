namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	public interface IAddColumnTemplateMessageBuilder {

		/// <summary>
		/// カラム追加
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>ビルド可能なカルーセルテンプレート用Builder</returns>
		IColumnSettingOnlyCarouselTemplateMessageBuilder AddColumn( string text );

	}

}
