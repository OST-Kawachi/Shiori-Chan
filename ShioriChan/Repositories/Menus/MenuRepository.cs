using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using System.Collections.Generic;
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
			this.logger.LogInformation("Start");
			this.logger.LogDebug($"User Id is {userId}");

			Permission permission = this.model.Permissions
				.FirstOrDefault(p => "Admin".Equals(p.Name));
			if (permission is null) {
				this.logger.LogWarning("Admin Permission is NULL");
				return false;
			}

			UserInfo userInfo = this.model.UserInfos
				.FirstOrDefault(u => userId.Equals(u.Id));
			if (userInfo is null) {
				this.logger.LogInformation("User Info is NULL");
				return false;
			}

			UserPermission userPermission = this.model.UserPermissions
				.FirstOrDefault(up => permission.Seq == up.PermissionSeq && userInfo.Seq == up.UserSeq);

			this.logger.LogInformation("End");

			return !(userPermission is null);
		}


		/// <summary>
		/// ユーザID一覧を取得する
		/// </summary>
		/// <returns>ユーザID一覧取得</returns>
		public List<string> GetUserIds() {
			this.logger.LogInformation("Call Get User Ids");
			return this.model.UserInfos
				.Where(ui => !string.IsNullOrEmpty(ui.Id))
				.Where(ui => ui.ParticipatingEventSeq == 0)
				.Select(ui => ui.Id)
				.ToList();
		}

	}

}
