
using System.Collections.Generic;

namespace ShioriChan.Repositories.Menus
{

	/// <summary>
	/// メニューRepository
	/// </summary>
	public interface IMenuRepository
	{
		/// <summary>
		/// 管理メニューが開けるかどうかチェックする
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>管理メニューが開けるかどうか</returns>
		bool IsOpenAdminMenu(string userId);

		/// <summary>
		/// ユーザID一覧を取得する
		/// </summary>
		/// <returns>ユーザID一覧取得</returns>
		List<string> GetUserIds();

	}

}

