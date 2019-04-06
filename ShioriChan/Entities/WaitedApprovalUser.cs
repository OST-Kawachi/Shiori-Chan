using System;
using System.ComponentModel.DataAnnotations;

namespace ShioriChan.Entities {

	/// <summary>
	/// 承認待ちユーザ
	/// </summary>
	public class WaitedApprovalUser {

		/// <summary>
		/// 承認待ち管理番号
		/// </summary>
		[Key]
		public int Seq { set; get; }

		/// <summary>
		/// ユーザID
		/// </summary>
		public string UserId { set; get; }

		/// <summary>
		/// ユーザ名
		/// </summary>
		public string UserName { set; get; }

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