using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Senders {

	/// <summary>
	/// MessageSender
	/// </summary>
	public interface IMessageSender {

		/// <summary>
		/// 送信
		/// </summary>
		/// <param name="replyToken">リプライトークン</param>
		Task Reply( string replyToken );

		/// <summary>
		/// プッシュ通知
		/// </summary>
		/// <param name="to">対象者ID</param>
		Task Push( string to );

		/// <summary>
		/// 複数人プッシュ通知
		/// </summary>
		/// <param name="toList">対象者ID一覧</param>
		Task Multicast( List<string> toList );

        /// <summary>
        /// ブロードキャスト通知
        /// </aummary>
        /// <param name="messages">送信するメッセージ</param>
        Task Broadcast();
	}

}
