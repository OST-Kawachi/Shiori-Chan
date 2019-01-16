using ShioriChan.Services.MessagingApis.Messages.Builder;
using System;

namespace ShioriChan.Services.MessagingApis.Messages {

	public interface IMessageService {

		/// <summary>
		/// メッセージBuilder作成
		/// </summary>
		/// <param name="channelAccessToken"></param>
		/// <param name="replyToken"></param>
		/// <returns></returns>
		[Obsolete( "未完成です" , true )]
		MessageBuilderBase CreateMessageBuilder();

	}
}
