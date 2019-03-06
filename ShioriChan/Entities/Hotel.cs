using System;
using System.ComponentModel.DataAnnotations;

namespace ShioriChan.Entities {

	/// <summary>
	/// 宿泊施設
	/// </summary>
	public class Hotel {

		/// <summary>
		/// 宿泊施設管理番号
		/// </summary>
		[Key]
		public int Seq { set; get; }

		/// <summary>
		/// イベント管理番号
		/// </summary>
		public int EventSeq { set; get; }

		/// <summary>
		/// 宿泊施設名
		/// </summary>
		public string Name { set; get; }

		/// <summary>
		/// チェックイン
		/// </summary>
		public DateTime CheckIn { set; get; }

		/// <summary>
		/// チェックアウト
		/// </summary>
		public DateTime CheckOut { set; get; }

		/// <summary>
		/// URL
		/// </summary>
		public string Url { set; get; }

		/// <summary>
		/// 住所
		/// </summary>
		public string Address { set; get; }

		/// <summary>
		/// 緯度
		/// </summary>
		public double? Latitude { set; get; }

		/// <summary>
		/// 経度
		/// </summary>
		public double? Longitude { set; get; }

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
