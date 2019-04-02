using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShioriChan.Services.Features.Users;
using System.IO;
using System.Threading.Tasks;

namespace ShioriChan.Controllers.Users {

	/// <summary>
	/// ユーザController
	/// </summary>
	/// TODO ApiController属性がつけられない
	[Route( "shiori-chan/" )]
	public class UsersController : Controller {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// ユーザService
		/// </summary>
		private readonly IUserService userService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="userService">ユーザService</param>
		public UsersController(
			ILogger<UsersController> logger ,
			IUserService userService
		)
		{
			this.logger = logger;
			this.userService = userService;
		}

		/// <summary>
		/// ユーザ申請画面取得
		/// </summary>
		/// <param name="encryptedUserSeq">暗号化されたユーザ管理番号</param>
		[Route( "user/apply/{encryptedUserSeq}" )]
		[ActionName( "Apply" )]
		public IActionResult GetApplyView( string encryptedUserSeq )
			=> this.View();

		/// <summary>
		/// ユーザ登録承認画面取得
		/// </summary>
		[Route( "user/approval" )]
		[ActionName( "Approval" )]
		public IActionResult GetApprovalView()
			=> this.View();

		/// <summary>
		/// ユーザ申請API
		/// </summary>
		[Route( "api/user/apply" )]
		public async Task<int> Apply() {
			this.logger.LogTrace( "Start" );

			// TODO リクエストボディをJTokenの形で受け取れれば必要ない変換処理
			string request = null;
			{
				using( StreamReader streamReader = new StreamReader( this.Request.Body ) ) {
					request = streamReader.ReadToEnd();
				}
				this.logger.LogInformation( "Request is {request}." , request );
			}
			await this.userService.Apply();
			this.logger.LogTrace( "End" );
			return 200;
		}
		/// <summary>
		/// 承認待ちユーザ一覧取得API
		/// </summary>
		[Route( "api/user/waiting-approval-users" )]
		public void GetAwaitingApprovalUsers()
			=> this.userService.GetAwaitingApprovalUsers();

		/// <summary>
		/// ユーザ登録承認API
		/// </summary>
		[Route( "api/user/approval" )]
		public void Approval()
			=> this.userService.Approval();

	}

}