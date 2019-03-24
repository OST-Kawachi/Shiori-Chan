using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.Users;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Users {

	/// <summary>
	/// ユーザService
	/// </summary>
	public class UserService : IUserService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// ユーザRepository
		/// </summary>
		private readonly IUserRepository userRepository;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="scheduleRepository">ユーザRepository</param>
		public UserService(
			ILogger<UserService> logger ,
			IMessageService messageService ,
			IUserRepository userRepository
		)
		{
			this.logger = logger;
			this.messageService = messageService;
			this.userRepository = userRepository;
		}

		/// <summary>
		/// メニューを表示する
		/// 登録されていなければURLを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task ShowMenuAndUrlIfNotRegistered( JToken parameter )
			=> null;

		/// <summary>
		/// 申請する
		/// </summary>
		public Task Apply() => throw new System.NotImplementedException();

		/// <summary>
		/// 承認待ちユーザ一覧取得
		/// </summary>
		public Task GetAwaitingApprovalUsers() => throw new System.NotImplementedException();

		/// <summary>
		/// 承認する
		/// </summary>
		public Task Approval() => throw new System.NotImplementedException();

		/// <summary>
		/// ランダムに名前を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task ShowRandomly( JToken parameter ) => throw new System.NotImplementedException();

	}

}
