using System;

namespace ShioriChan.Models {

	/// <summary>
	/// 部屋メンバー
	/// </summary>
	public class RoomMember {

		/// <summary>
		/// 部屋管理番号
		/// </summary>
		public int RoomSeq { set; get; }

		/// <summary>
		/// イベント管理番号
		/// </summary>
		public int EventSeq { set; get; }

		/// <summary>
		/// ユーザ管理番号
		/// </summary>
		public int UserSeq { set; get; }

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
