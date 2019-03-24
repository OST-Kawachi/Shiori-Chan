using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShioriChan.Services.Features.RollCalls;

namespace ShioriChan.Controllers.RollCalls {

	/// <summary>
	/// 点呼Controller
	/// </summary>
	[Route( "shiori-chan" )]
	public class RollCallsController : Controller {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// 点呼Service
		/// </summary>
		private readonly IRollCallService rollCallService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="rollCallService">点呼Service</param>
		public RollCallsController(
			ILogger<RollCallsController> logger ,
			IRollCallService rollCallService
		)
		{
			this.logger = logger;
			this.rollCallService = rollCallService;
		}

		/// <summary>
		/// 点呼一覧画面取得
		/// </summary>
		[Route( "roll-call/list" )]
		[ActionName( "List" )]
		public IActionResult GetListView()
			=> this.View();

		/// <summary>
		/// 点呼一覧取得API
		/// </summary>
		[Route( "api/roll-call/list" )]
		public void GetList()
			=> this.rollCallService.GetStatuses();

		/// <summary>
		/// 点呼受付開始API
		/// </summary>
		[Route( "api/roll-call/start-accepting" )]
		public void StartAccepting()
			=> this.rollCallService.StartAcception();

	}

}
