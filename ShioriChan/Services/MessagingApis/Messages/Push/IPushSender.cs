using System;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// プッシュメッセージ送信用インタフェース
	/// </summary>
	public interface IPushSender {

		/// <summary>
		/// 送信
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void Send();

	}

}
