using System;
using System.ComponentModel.DataAnnotations;

namespace ShioriChan.Entities {

	/// <summary>
	/// プッシュ通知
	/// </summary>
	public class PushNotification {

		/// <summary>
		/// 通知管理番号
		/// </summary>
		[Key]
		public int Seq { set; get; }

		/// <summary>
		/// ユーザ管理番号
		/// </summary>
		public int UserSeq { set; get; }

		/// <summary>
		/// 通知状況
		/// </summary>
		public int Status { set; get; }

		/// <summary>
		/// 通知内容
		/// </summary>
		public string Text { set; get; }

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

	}

}
