using System;
using System.ComponentModel.DataAnnotations;

namespace ShioriChan.Entities {

	/// <summary>
	/// 部屋情報
	/// </summary>
	public class Room {

		/// <summary>
		/// 部屋管理番号
		/// </summary>
		[Key]
		public int Seq { set; get; }

		/// <summary>
		/// 宿泊施設管理番号
		/// </summary>
		public int HotelSeq { set; get; }

		/// <summary>
		/// 部屋番号
		/// </summary>
		public string Number { set; get; }

		/// <summary>
		/// イベント管理番号
		/// </summary>
		public int EventSeq { set; get; }

		/// <summary>
		/// 鍵を持っている参加者管理番号
		/// </summary>
		public int? HavingKeyUserSeq { set; get; }

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
