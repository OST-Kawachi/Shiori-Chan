using ShioriChan.Services.MessagingApis.Messages.Builders;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// メッセージ作成クラス
	/// </summary>
	public interface IMessageService {

		/// <summary>
		/// メッセージBuilder作成
		/// </summary>
		/// <returns>メッセージBuilder</returns>
		MessageBuilder CreateMessageBuilder();
		
		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		Task GetContent( string channelAccessToken , string messageId );

	}

}
