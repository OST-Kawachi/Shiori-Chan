namespace ShioriChan.Services.MessagingApis.OAuth.LinkToken {

	/// <summary>
	/// 連携トークン発行用インタフェース
	/// </summary>
	public interface ILinkTokenService {

		/// <summary>
		/// 発行
		/// </summary>
		void Issue();

	}

}
