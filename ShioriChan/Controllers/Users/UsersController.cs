using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.Features.Users;
using System.IO;
using ShioriChan.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShioriChan.Controllers.Users
{

	/// <summary>
	/// ユーザController
	/// </summary>
	/// TODO ApiController属性がつけられない
	[Route( "shiori-chan/" )]
	public class UsersController : Controller
	{

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
		[Route("user/apply/{encryptedUserSeq}")]
		[ActionName("Apply")]
		public IActionResult GetApplyView(string encryptedUserSeq) {
			this.logger.LogInformation("Call Get Apply View");
			return this.View();
		}

		/// <summary>
		/// ユーザ登録承認画面取得
		/// </summary>
		[Route("user/approval")]
		[ActionName("Approval")]
		public IActionResult GetApprovalView() {
			this.logger.LogInformation("Call Get Approval View");
			return this.View();
		}

		/// <summary>
		/// ユーザ申請API
		/// </summary>
		[Route( "api/user/apply" )]
		public int Apply()
		{
			this.logger.LogInformation( "Start" );

			// TODO リクエストボディをJTokenの形で受け取れれば必要ない変換処理
			string request = null;
			{
				using( StreamReader streamReader = new StreamReader( this.Request.Body ) )
				{
					request = streamReader.ReadToEnd();
				}
				this.logger.LogInformation( "Request is {request}." , request );
			}
			if( request is null) {
				this.logger.LogWarning("Request is NULL");
				return 200;
			}
			JToken requestObj = JToken.Parse( request );

			// TODO ユーザ管理番号が生データ
			this.userService.Apply( int.Parse( requestObj[ "userSeq" ].ToString() ) , requestObj[ "name" ].ToString() );
			this.logger.LogInformation( "End" );
			return 200;
		}

		/// <summary>
		/// 承認待ちユーザ一覧取得API
		/// </summary>
		[Route("api/user/waiting-approval-users")]
		public IActionResult GetAwaitingApprovalUsers()
		{
			this.logger.LogInformation("Start");

			List<UserInfo> unRegisteredUsers = this.userService.GetUnregisteredUsers();
			if (unRegisteredUsers is null) {
				this.logger.LogInformation("Un Registered Users is NULL");
				unRegisteredUsers = new List<UserInfo>();
			}

			List<WaitedApprovalUser> waitingApprovalUsers = this.userService.GetWaitingApprovalUsers();
			if( waitingApprovalUsers is null) {
				this.logger.LogInformation("Waiting Approval Users is NULL");
				waitingApprovalUsers = new List<WaitedApprovalUser>();
			}

			List<UserInfo> approvedUsers = this.userService.GetApprovedUsers();
			if( approvedUsers is null) {
				this.logger.LogInformation("Approved Users is NULL");
				approvedUsers = new List<UserInfo>();
			}

			this.logger.LogInformation("End");
			return this.Json(new
			{
				unRegisteredUsers = unRegisteredUsers.Select(u => new { u.Seq, u.Name }).ToList(),
				waitingApprovalUsers = waitingApprovalUsers.Select(u => new { u.Seq, u.UserName }).ToList(),
				approvedUsers = approvedUsers.Select(u => new { u.Seq, u.Name }).ToList()
			});
		}

		/// <summary>
		/// ユーザ登録承認API
		/// </summary>
		[Route( "api/user/approval/{unRegisteredUserSeq}/{waitingApprovalUserSeq}" )]
		public async Task Approval( int unRegisteredUserSeq , int waitingApprovalUserSeq )
		{
			this.logger.LogInformation( "Start" );
			this.logger.LogDebug( $"Un Registered User Seq is {unRegisteredUserSeq}." );
			this.logger.LogDebug( $"Waiting Approval User Seq is {waitingApprovalUserSeq}." );

			await this.userService.Approval( unRegisteredUserSeq , waitingApprovalUserSeq );

			this.logger.LogInformation( "End" );
		}

	}

}