using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.RichMenu {

	/// <summary>
	/// リッチメニューService
	/// </summary>
	public interface IRichMenuService {

		/// <summary>
		/// リッチメニュー作成
		/// </summary>
		void Create();

		/// <summary>
		/// リッチメニューのID一覧を取得する
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetIds();

		/// <summary>
		/// リッチメニューを取得する
		/// </summary>
		void Get();

		/// <summary>
		/// リッチメニューを削除する
		/// </summary>
		void Delete();

		/// <summary>
		/// デフォルトのリッチメニューを設定する
		/// </summary>
		void SetDefault();

		/// <summary>
		/// デフォルトのリッチメニューのIDを取得する
		/// </summary>
		void GetDefaultId();

		/// <summary>
		/// デフォルトのリッチメニューを解除する
		/// </summary>
		void ReleaseDefault();

		/// <summary>
		/// リッチメニューとユーザをリンクする
		/// </summary>
		void LinkToUser();

		/// <summary>
		/// ユーザのリッチメニューのIDを取得する
		/// </summary>
		void GetId();

		/// <summary>
		/// リッチメニューとユーザのリンクを解除する
		/// </summary>
		void Release();

	}

}
