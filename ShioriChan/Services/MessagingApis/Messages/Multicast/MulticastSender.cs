using System;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// 複数のユーザに送信用クラス
	/// </summary>
	public class MulticastSender : IMulticastSender {

		/// <summary>
		/// 送信
		/// </summary>
		[Obsolete( "未完成です" , true )]
		public void Send() => throw new NotImplementedException();

	}

}
