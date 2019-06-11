using ShioriChan.Services.MessagingApis.Messages.BuilderFactories;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using System;
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
		IAddOnlyMessageOfMessageBuilder CreateMessageBuilder();
		
		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		Task<byte[]> GetContent( string messageId );

        /// <summary>
        /// 追加メッセージの上限数取得
        /// </summary>
        /// <returns></returns>
        Task<object> GetMessageLimit();

        /// <summary>
        /// 当月のメッセージ利用状況を取得する
        /// </summary>
        /// <returns></returns>
        Task<object> GetMessageStatus();

        /// <summary>
        /// 送信済み応答メッセージ数を取得
        /// </summary>
        /// <returns></returns>
        Task<object> GetSentReplyMessageCount( DateTime replyDate );

        /// <summary>
        /// 送信済み応答メッセージ数を取得
        /// </summary>
        /// <param name="replyDate"></param>
        /// <returns></returns>
        Task<object> GetSentPushMessageCount(DateTime replyDate );

        /// <summary>
        /// 送信済みマルチキャストメッセージ数を取得
        /// </summary>
        /// <param name="replyDate"></param>
        /// <returns></returns>
        Task<object> GetSentMulticastMessageCount(DateTime replyDate);

        /// <summary>
        /// 送信済みブロードキャストメッセージ数を取得
        /// </summary>
        /// <param name="replyDate"></param>
        /// <returns></returns>
        Task<object> GetSentBroadcastMessageCount(DateTime replyDate);
	}

}
