using System;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// 複数のユーザに送信用インタフェース
	/// </summary>
	public interface IMulticastSender {

		/// <summary>
		/// 送信
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void Send();

	}

}
