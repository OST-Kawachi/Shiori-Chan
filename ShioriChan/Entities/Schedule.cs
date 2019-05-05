using System;

namespace ShioriChan.Entities {

	/// <summary>
	/// スケジュール
	/// </summary>
	public class Schedule {

		/// <summary>
		/// スケジュール管理番号
		/// </summary>
		public int Seq { set; get; }

		/// <summary>
		/// スケジュール名
		/// </summary>
		public string Name { set; get; }

		/// <summary>
		/// イベント管理番号
		/// </summary>
		public int EventSeq { set; get; }

		/// <summary>
		/// 開始日時
		/// </summary>
		public DateTime StartDatetime { set; get; }

		/// <summary>
		/// 集合場所住所
		/// </summary>
		public string Address { set; get; }

		/// <summary>
		/// 集合場所緯度
		/// 元の値×1兆倍
		/// </summary>
		public long? Latitude { set; get; }

		/// <summary>
		/// 集合場所経度
		/// 元の値×1兆倍
		/// </summary>
		public long? Longitude { set; get; }

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
		/// 終了時間
		/// </summary>
		public DateTime? EndDatetime { set; get; }

		/// <summary>
		/// 通知済みかどうか
		/// </summary>
		public bool IsNotified { set; get; }

	}

}
