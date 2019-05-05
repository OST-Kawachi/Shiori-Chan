using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Confirms;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.ImageCarousels;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates {

	/// <summary>
	/// テンプレートの選択
	/// </summary>
	public interface ISelectOnlyTemplate {

		/// <summary>
		/// ボタンテンプレートを使用する
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>ボタンテンプレートの設定</returns>
		ISettableButtonTemplate UseButtonTemplate( string text );

		/// <summary>
		/// 確認テンプレートを使用する
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>確認テンプレートのOKボタンのアクション選択</returns>
		ISelectOnlyPositiveActionOfConfirmTemplate UseConfirmTemplate( string text );

		/// <summary>
		/// カルーセルテンプレートを使用する
		/// </summary>
		/// <returns>カルーセルテンプレートの設定＋カラム追加</returns>
		ISettableAndAddColumnOfCarouselTemplate UseCarouselTemplateMessageBuilder();

		/// <summary>
		/// 画像カルーセルテンプレートを使用する
		/// </summary>
		/// <returns>画像カルーセルテンプレートの設定＋カラム追加</returns>
		IAddOnlyColumnOfImageCarouselTemplate UseImageCarouselTemplateMessageBuilder();

	}

}
