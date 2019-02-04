using ShioriChan.Services.MessagingApis.Messages.Builders.Templates.Buttons;
using ShioriChan.Services.MessagingApis.Messages.Builders.Templates.Carousels;
using ShioriChan.Services.MessagingApis.Messages.Builders.Templates.Confirms;
using ShioriChan.Services.MessagingApis.Messages.Builders.Templates.ImageCarousels;

namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates {

	/// <summary>
	/// テンプレート選択のみ可能なTemplateBuilder
	/// </summary>
	public interface ISelectOnlyTemplateMessageBuilder {

		/// <summary>
		/// ボタンテンプレートを使用する
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>ボタンテンプレートBuilder</returns>
		IButtonTemplateMessageBuilder UseButtonTemplate( string text );

		/// <summary>
		/// 確認テンプレートを使用する
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>確認テンプレートBuilder</returns>
		IConfirmTemplateMessageBuilder UseConfirmTemplate( string text );

		/// <summary>
		/// カルーセルテンプレートを使用する
		/// </summary>
		/// <returns>カルーセルテンプレートBuilder </returns>
		IAddAndSetOnlyCarouselTemplateMessageBuilder UseCarouselTemplateMessageBuilder();

		/// <summary>
		/// 画像カルーセルテンプレートを使用する
		/// </summary>
		/// <returns>画像カルーセルテンプレートBuilder</returns>
		IAddColumnOnlyImageCarouselTemplateMessageBuilder UseImageCarouselTemplateMessageBuilder();

	}

}
