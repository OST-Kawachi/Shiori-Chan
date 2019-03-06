using System;
using System.ComponentModel.DataAnnotations;

namespace ShioriChan.Entities {

	/// <summary>
	/// アクセストークン
	/// </summary>
	public class AccessToken {

		/// <summary>
		/// トークン管理番号
		/// </summary>
		[Key]
		public int Seq { set; get; }

		/// <summary>
		/// アクセストークン
		/// </summary>
		public string Token { set; get; }

		/// <summary>
		/// 開始日時
		/// </summary>
		public DateTime StartDateTime { set; get; }
		
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
