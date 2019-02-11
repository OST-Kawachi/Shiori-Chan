namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// カラムの追加しかできない
	/// </summary>
	public interface IAddOnlyColumnOfCarouselTemplate {

		/// <summary>
		/// カラム追加
		/// </summary>
		/// <param name="text">テキスト</param>
		/// <returns>カラムの設定</returns>
		ISettableColumnOfCarouselTemplate AddColumn( string text );

	}

}
