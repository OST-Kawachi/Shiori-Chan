using System;
using System.Collections.Generic;

namespace ShioriChan.Entities {

	/// <summary>
	/// ユーザ
	/// </summary>
	public class UserInfo {
	
		/// <summary>
		/// ユーザ管理番号
		/// </summary>
		public int Seq { set; get; }

		/// <summary>
		/// ユーザID
		/// </summary>
		public string Id { set; get; }

		/// <summary>
		/// ユーザ名
		/// </summary>
		public string Name { set; get; }

		/// <summary>
		/// 参加中イベント管理番号
		/// </summary>
		public int? ParticipatingEventSeq { set; get; }

		/// <summary>
		/// 登録者管理番号
		/// </summary>
		public int RegisterUserSeq { set; get; }

		/// <summary>
		/// 登録日時
		/// </summary>
		public DateTime RegisterDatetime { set; get; }

		/// <summary>
		/// 更新者管理番号
		/// </summary>
		public int UpdateUserSeq { set; get; }

		/// <summary>
		/// 更新日時
		/// </summary>
		public DateTime UpdateDatetime { set; get; }

		/// <summary>
		/// バージョン
		/// </summary>
		public int Version { set; get; }

		/// <summary>
		/// プッシュ通知
		/// </summary>
		public ICollection<PushNotification> PushNotifications { set; get; }

		/// <summary>
		/// ユーザ権限
		/// </summary>
		public ICollection<UserPermission> UserPermissions { set; get; }

	}

}
