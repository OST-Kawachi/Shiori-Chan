using ShioriChan.Services.MessagingApis.Messages.Builder;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// メッセージ作成クラス
	/// </summary>
	public class MessageService {

		/// <summary>
		/// メッセージBuilder作成
		/// </summary>
		/// <param name="channelAccessToken"></param>
		/// <param name="replyToken"></param>
		/// <returns></returns>
		[Obsolete( "未完成です" , true )]
		public MessageBuilderBase CreateMessageBuilder()
			=> new MessageBuilderBase();

	}

}
