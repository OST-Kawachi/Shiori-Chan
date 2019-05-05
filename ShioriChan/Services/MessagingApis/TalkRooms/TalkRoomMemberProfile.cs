namespace ShioriChan.Services.MessagingApis.TalkRooms {

	/// <summary>
	/// トークルームメンバーのプロフィール
	/// </summary>
	public class TalkRoomMemberProfile {

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
		/// プロフィール画像のURL
		/// </summary>
		public string PictureUrl {
			private set;
			get;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="displayName">表示名</param>
		/// <param name="userId">ユーザID</param>
		/// <param name="pictureUrl">プロフィール画像のURL</param>
		public TalkRoomMemberProfile( string displayName , string userId , string pictureUrl ) {
			this.DisplayName = displayName;
			this.UserId = userId;
			this.PictureUrl = pictureUrl;
		}

	}

}
