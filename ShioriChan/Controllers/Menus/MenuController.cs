using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShioriChan.Services.Features.Menus;

namespace ShioriChan.Controllers.Menus {

	/// <summary>
	/// メニューController
	/// </summary>
	[Route( "shiori-chan" )]
	public class MenuController : Controller {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// メニューService
		/// </summary>
		private readonly IMenuService menuService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="menuService">メニューService</param>
		public MenuController(
			ILogger<MenuController> logger ,
			IMenuService menuService
		)
		{
			this.logger = logger;
			this.menuService = menuService;
		}

		/// <summary>
		/// メニュー画像を更新する
		/// </summary>
		[Route( "api/menu" )]
		[HttpPost]
		public async Task<StatusCodeResult> Post()
		{
			this.logger.LogTrace( "Start" );
			await this.menuService.UpdateImage();
			this.logger.LogTrace( "End" );
			return this.Ok();
		}

	}
}
