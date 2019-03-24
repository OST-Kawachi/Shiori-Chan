using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.Users;
using ShioriChan.Services.Features.Menus;
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
		/// メニューService
		/// </summary>
		private readonly IMenuService menuService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="userRepository">ユーザRepository</param>
		/// <param name="menuService">メニューService</param>
		public UserService(
			ILogger<UserService> logger ,
			IMessageService messageService ,
			IUserRepository userRepository ,
			IMenuService menuService
		)
		{
			this.logger = logger;
			this.messageService = messageService;
			this.userRepository = userRepository;
			this.menuService = menuService;
		}

		/// <summary>
		/// ユーザIDを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ユーザID</returns>
		private string GetUserId( JToken parameter )
		{
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken source = firstEvent[ "source" ];
			string userId = source[ "userId" ].ToString();
			this.logger.LogTrace( $"User Id is {userId}." );

			return userId;
		}

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter )
		{
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			string replyToken = firstEvent[ "replyToken" ].ToString();
			this.logger.LogTrace( $"Reply Token is {replyToken}." );

			return replyToken;
		}

		/// <summary>
		/// メニューを表示する
		/// 登録されていなければURLを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ShowMenuAndUrlIfNotRegistered( JToken parameter )
		{
			this.logger.LogTrace( "Start" );

			string userId = this.GetUserId( parameter );
			this.logger.LogTrace( $"User Id is {userId}." );

			bool isRegistered = this.userRepository.IsRegisterd( userId );
			this.logger.LogTrace( $"Registered is {isRegistered}." );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogTrace( $"Reply Token is {replyToken}." );

			if( isRegistered ) {
				await this.menuService.ChangeMenu( userId , "" );
				await this.messageService
					.CreateMessageBuilder()
					.AddMessage( "また友達追加してくれたんですね！\nありがとうございます！！\nまたよろしくお願いします！" )
					.BuildMessage()
					.Reply( replyToken );
			}
			else {

				int waitingApprovalUserSeq = this.userRepository.RegisterOnlyUserIdInWaitingApproval( userId );
				this.logger.LogTrace( $"Waiting Approval User Seq is {waitingApprovalUserSeq}." );

				await this.messageService
					.CreateMessageBuilder()
					.AddMessage( "初めまして！\nあなたの旅のおともをさせていただきます！\nしおりと申します！\nよろしくお願いします！！" )
					.AddMessage( "まずはあなたのお名前を教えてください！" )
					.AddTemplate("名前を教えてね！")
						.UseButtonTemplate( "名前を教える" )
						.SetAction()
						.UseUriAction( "名前を教えます" , "" + waitingApprovalUserSeq )
						.BuildTemplate()
					.BuildMessage()
					.Reply( replyToken );
			}

			this.logger.LogTrace( "End" );
		}

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
