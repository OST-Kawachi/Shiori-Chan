using Microsoft.AspNetCore.Mvc;

namespace ShioriChan.Controllers.RollCalls {

	/// <summary>
	/// 点呼Controller
	/// </summary>
	[Route( "shiori-chan" )]
	public class RollCallsController : Controller {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RollCallsController() {

		}

		/// <summary>
		/// 点呼一覧画面取得
		/// </summary>
		[Route( "roll-call/list" )]
		[ActionName("List")]
		public IActionResult GetListView() => this.View();

		/// <summary>
		/// 点呼一覧取得API
		/// </summary>
		[Route( "api/roll-call/list" )]
		public void GetList() {

		}

		/// <summary>
		/// 点呼受付開始API
		/// </summary>
		[Route( "api/roll-call/start-accepting" )]
		public void StartAccepting() {

		}

	}
}
