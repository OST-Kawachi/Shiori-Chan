namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Carousels {

	/// <summary>
	/// カラムのアクション追加
	/// </summary>
	public interface IAddColumnActionOfCarouselTemplate {

		/// <summary>
		/// カラムのアクション追加
		/// </summary>
		/// <returns>カラムのアクション選択</returns>
		ISelectColumnActionOfCarouselTemplate AddAction();

	}
	
}
	
