namespace ShioriChan.Services.MessagingApis.OAuth {

	/// <summary>
	/// チャンネルアクセストークン発行インタフェース
	/// </summary>
	public interface IChannelAccessTokenService {

		/// <summary>
		/// 発行
		/// </summary>
		void Issue();

		/// <summary>
		/// 取り消し
		/// </summary>
		void Revoke();

	}

}
