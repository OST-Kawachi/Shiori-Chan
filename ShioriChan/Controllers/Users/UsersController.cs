using Microsoft.AspNetCore.Mvc;

namespace ShioriChan.Controllers.Users {

	/// <summary>
	/// ユーザController
	/// </summary>
	/// TODO ApiController属性がつけられない
	[Route( "shiori-chan/" )]
	public class UsersController : Controller {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public UsersController() {

		}

		/// <summary>
		/// ユーザ登録画面取得
		/// </summary>
		/// <param name="encryptedUserSeq">暗号化されたユーザ管理番号</param>
		[Route( "user/register/{encryptedUserSeq}" )]
		[ActionName( "Register" )]
		public IActionResult GetRegisterView( string encryptedUserSeq ) => this.View();

		/// <summary>
		/// ユーザ登録承認画面取得
		/// </summary>
		[Route( "user/approval" )]
		[ActionName("Approval")]
		public IActionResult GetApprovalView() => this.View();

		/// <summary>
		/// ユーザ登録API
		/// </summary>
		[Route("api/user/register")]
		public void Register() {

		}

		/// <summary>
		/// ユーザ登録承認API
		/// </summary>
		[Route("api/user/approval")]
		public void Approval() {

		}

	}

}
