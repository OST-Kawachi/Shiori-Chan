namespace ShioriChan.Repositories.OAuthes {

	/// <summary>
	/// 認証用Repository
	/// </summary>
	public interface IOAuthRepository {

		/// <summary>
		/// 最新のチャンネルアクセストークンを取得する
		/// </summary>
		/// <returns>最新のチャンネルアクセストークン</returns>
		string GetNewlyChannelAccessToken();

		/// <summary>
		/// チャンネルアクセストークンを登録する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		void RegisterChannelAccessToken( string channelAccessToken );

	}

}
