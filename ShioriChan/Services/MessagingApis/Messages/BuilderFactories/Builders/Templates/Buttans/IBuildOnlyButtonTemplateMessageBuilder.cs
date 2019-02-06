namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.Templates.Buttons {

	/// <summary>
	/// ビルドのみ可能インタフェース
	/// </summary>
	public interface IBuildOnlyButtonTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageBuilder BuildTemplate();

	}

}
