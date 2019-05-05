namespace ShioriChan.Services.MessagingApis.Profiles {

	/// <summary>
	/// プロフィール
	/// </summary>
	public class Profile {

		/// <summary>
		/// 表示名
		/// </summary>
		public string DisplayName {
			private set;
			get;
		}

		/// <summary>
		/// ユーザID
		/// </summary>
		public string UserId {
			private set;
			get;
		}

		/// <summary>
		/// 画像のURL
		/// </summary>
		public string PictureUrl {
			private set;
			get;
		}

		/// <summary>
		/// ステータスメッセージ
		/// </summary>
		public string StatusMessage {
			private set;
			get;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="displayName">表示名</param>
		/// <param name="userId">ユーザID</param>
		/// <param name="pictureUrl">画像のURL</param>
		/// <param name="statusMessage">ステータスメッセージ</param>
		public Profile( string displayName , string userId , string pictureUrl , string statusMessage ) {
			this.DisplayName = displayName;
			this.UserId = userId;
			this.PictureUrl = pictureUrl;
			this.StatusMessage = statusMessage;
		}

	}

}
