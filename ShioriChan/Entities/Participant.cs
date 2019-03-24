using System;

namespace ShioriChan.Entities {

	/// <summary>
	/// 参加者
	/// </summary>
	public class Participant {

		/// <summary>
		/// イベント管理番号
		/// </summary>
		public int EventSeq { set; get; }

		/// <summary>
		/// ユーザ管理番号
		/// </summary>
		public int UserSeq { set; get; }

		/// <summary>
		/// 点呼状況
		/// </summary>
		public bool? RollCall { set; get; }

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