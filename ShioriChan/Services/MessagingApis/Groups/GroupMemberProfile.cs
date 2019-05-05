namespace ShioriChan.Services.MessagingApis.Groups {

	/// <summary>
	/// グループメンバーのプロフィール
	/// </summary>
	public class GroupMemberProfile {

		/// <summary>
		/// 表示名
		/// </summary>
		public string DisplayName { set; get; }

		/// <summary>
		/// ユーザID
		/// </summary>
		public string UserId { set; get; }

		/// <summary>
		/// プロフィール画像のURL
		/// </summary>
		public string PictureUrl { set; get; }

	}

}
