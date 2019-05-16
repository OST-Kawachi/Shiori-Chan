using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using System.Linq;

namespace ShioriChan.Repositories.Menus
{

	/// <summary>
	/// メニューRepository
	/// </summary>
	public class MenuRepository : IMenuRepository
	{

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// データモデル
		/// </summary>
		private readonly ModelCreator model;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="model">データモデル</param>
		public MenuRepository(
			ILogger<MenuRepository> logger,
			ModelCreator model
		)
		{
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 管理メニューが開けるかどうかチェックする
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>管理メニューが開けるかどうか</returns>
		public bool IsOpenAdminMenu(string userId)
		{

			Permission permission = this.model.Permissions
				.FirstOrDefault(p => "Admin".Equals(p.Name));

			UserInfo userInfo = this.model.UserInfos
				.FirstOrDefault(u => userId.Equals(u.Id));

			UserPermission userPermission = this.model.UserPermissions
				.FirstOrDefault(up => permission.Seq == up.PermissionSeq && userInfo.Seq == up.UserSeq);

			return !(userPermission is null);
		}
	}
}
