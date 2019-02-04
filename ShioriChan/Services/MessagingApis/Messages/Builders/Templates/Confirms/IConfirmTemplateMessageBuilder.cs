﻿namespace ShioriChan.Services.MessagingApis.Messages.Builders.Templates.Confirms {

	/// <summary>
	/// ビルドのみ可能なテンプレートBuilder
	/// </summary>
	public interface IConfirmTemplateMessageBuilder {

		/// <summary>
		/// テンプレートのBuild
		/// </summary>
		/// <returns>ビルド可能なメッセージBuilder</returns>
		IMessageBuilder BuildTemplate();

	}

}
