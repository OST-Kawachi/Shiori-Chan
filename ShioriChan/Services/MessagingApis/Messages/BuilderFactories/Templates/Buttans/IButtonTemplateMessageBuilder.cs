namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Templates.Buttons {

	/// <summary>
	/// ボタンテンプレートBuilder
	/// </summary>
	public interface IButtonTemplateMessageBuilder {

		/// <summary>
		/// 画像URL設定
		/// </summary>
		/// <param name="thmbnailImageUrl">画像URL</param>
		/// <returns>自身のBuilderクラス</returns>
		IButtonTemplateMessageBuilder SetThumbnailImageUrl( string thmbnailImageUrl );

		/// <summary>
		/// 画像のアスペクト比設定
		/// </summary>
		/// <param name="imageAspectRatio">画像のアスペクト比</param>
		/// <returns>自身のBuilderクラス</returns>
		IButtonTemplateMessageBuilder SetImageAspectRatio( string imageAspectRatio );

		/// <summary>
		/// 画像の表示形式設定
		/// </summary>
		/// <param name="imageSize">画像の表示形式</param>
		/// <returns>自身のBuilderクラス</returns>
		IButtonTemplateMessageBuilder SetImageSize( string imageSize );

		/// <summary>
		/// 画像の背景色設定
		/// </summary>
		/// <param name="imageBackGroundColor">画像の背景色</param>
		/// <returns>自身のBuilderクラス</returns>
		IButtonTemplateMessageBuilder SetImageBackgroundColor( string imageBackGroundColor );

		/// <summary>
		/// タイトル
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <returns>自身のBuilderクラス</returns>
		IButtonTemplateMessageBuilder SetTitle( string title );

		/// <summary>
		/// アクション設定
		/// </summary>
		/// <returns>アクション選択インタフェース</returns>
		IOnlySelectActionButtonTemplateMessageBuilder SetAction();

	}

	/// <summary>
	/// アクション選択インタフェース
	/// </summary>
	public interface IOnlySelectActionButtonTemplateMessageBuilder {

		ISettablePostbackActionButtonTemplateMessageBuilder UsePostbackAction( string label , string data );
		IBuildOnlyButtonTemplateMessageBuilder UseMessageAction( string label , string text );
		IBuildOnlyButtonTemplateMessageBuilder UseUriAction( string label , string uri );
		ISettableDatetimePickerActionButtonTemplateMessageBuilder UseDatetimePickerAction( string label , string data , string mode );

	}

	public interface ISettablePostbackActionButtonTemplateMessageBuilder : IBuildOnlyButtonTemplateMessageBuilder {
		IBuildOnlyButtonTemplateMessageBuilder SetDisplayText( string displayText );
	}

	public interface ISettableDatetimePickerActionButtonTemplateMessageBuilder : IBuildOnlyButtonTemplateMessageBuilder {
		ISettableDatetimePickerActionButtonTemplateMessageBuilder SetInitial( string initial );
		ISettableDatetimePickerActionButtonTemplateMessageBuilder SetMax( string max );
		ISettableDatetimePickerActionButtonTemplateMessageBuilder SetMin( string min );
	}

	/// <summary>
	/// ビルドのみ可能インタフェース
	/// </summary>
	public interface IBuildOnlyButtonTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageFactory BuildTemplate();

	}

}
