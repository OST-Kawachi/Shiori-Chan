using System;
using System.Collections.Generic;

namespace ShioriChan.Services.MessagingApis.RichMenu {

	/// <summary>
	/// リッチメニューService
	/// </summary>
	public interface IRichMenuService {

		/// <summary>
		/// リッチメニュー作成
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void Create();

		/// <summary>
		/// リッチメニューのID一覧を取得する
		/// </summary>
		/// <returns></returns>
		[Obsolete( "未完成です" , true )]
		IEnumerable<string> GetIds();

		/// <summary>
		/// リッチメニューを取得する
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void Get();

		/// <summary>
		/// リッチメニューを削除する
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void Delete();

		/// <summary>
		/// デフォルトのリッチメニューを設定する
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void SetDefault();

		/// <summary>
		/// デフォルトのリッチメニューのIDを取得する
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void GetDefaultId();

		/// <summary>
		/// デフォルトのリッチメニューを解除する
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void ReleaseDefault();

		/// <summary>
		/// リッチメニューとユーザをリンクする
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void LinkToUser();

		/// <summary>
		/// ユーザのリッチメニューのIDを取得する
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void GetId();

		/// <summary>
		/// リッチメニューとユーザのリンクを解除する
		/// </summary>
		[Obsolete( "未完成です" , true )]
		void Release();

	}

}
