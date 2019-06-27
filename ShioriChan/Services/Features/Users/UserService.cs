using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;
using ShioriChan.Repositories.Users;
using ShioriChan.Services.Features.Menus;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Users
{

	/// <summary>
	/// ユーザService
	/// </summary>
	public class UserService : IUserService
	{

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
			this.logger.LogDebug( $"User Id is {userId}." );

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
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

			return replyToken;
		}

		/// <summary>
		/// メニューを表示する
		/// 登録されていなければURLを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ShowMenuAndUrlIfNotRegistered( JToken parameter )
		{
			this.logger.LogInformation( "Start" );

			string userId = this.GetUserId( parameter );
			this.logger.LogDebug( $"User Id is {userId}." );

			bool isRegistered = this.userRepository.IsRegisterd( userId );
			this.logger.LogDebug( $"Registered is {isRegistered}." );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

			if( isRegistered )
			{
				await this.menuService.ChangeMenu( "" , userId , MenuService.MainMenuName );
				await this.messageService
					.CreateMessageBuilder()
					.AddMessage( "また友達追加してくれたんですね！\nありがとうございます！！\nまたよろしくお願いします！" )
					.BuildMessage()
					.Reply( replyToken );
			}
			else
			{

				int waitingApprovalUserSeq = this.userRepository.RegisterOnlyUserIdInWaitingApproval( userId );
				this.logger.LogDebug( $"Waiting Approval User Seq is {waitingApprovalUserSeq}." );

				await this.messageService
					.CreateMessageBuilder()
					.AddMessage( "初めまして！\nしおりと申します！！\nあなたの旅のおともをさせていただきます！\nよろしくお願いします！！" )
					.AddMessage( "まずはあなたのお名前を教えてください！" )
					.AddTemplate( "名前を教えてね！" )
						.UseButtonTemplate( "名前を教える" )
						.SetAction()
						.UseUriAction( "名前を教えます" , "https://shiorichanappservice.azurewebsites.net/shiori-chan/user/apply/" + waitingApprovalUserSeq )
						.BuildTemplate()
					.BuildMessage()
					.Reply( replyToken );
			}

			this.logger.LogInformation( "End" );
		}

		/// <summary>
		/// 申請する
		/// </summary>
		/// <param name="seq">管理番号</param>
		/// <param name="name">ユーザ名</param>
		public async void Apply( int seq , string name )
		{
			this.logger.LogInformation( "Start" );
			this.logger.LogDebug( $"Seq is {seq}." );
			this.logger.LogDebug( $"User Name is {name}." );

			this.userRepository.RegisterWaitingApproval( seq , name );
			List<string> userIds = this.userRepository.GetPushedAdminMembers();

			await this.messageService.CreateMessageBuilder()
				.AddTemplate( "ユーザが登録されました" )
				.UseButtonTemplate( "ユーザが登録されました。\n下記URLからユーザを承認してください" )
				.SetAction()
				.UseUriAction( "確認する" , "https://shiorichanappservice.azurewebsites.net/shiori-chan/user/approval/" )
				.BuildTemplate()
				.BuildMessage()
				.Multicast( userIds );

			this.logger.LogInformation( "End" );
			return;
		}

		/// <summary>
		/// 未登録ユーザ一覧取得
		/// </summary>
		/// <returns>未登録ユーザ一覧</returns>
		public List<UserInfo> GetUnregisteredUsers() {
			this.logger.LogInformation("Call Get Unregistered Users");
			return this.userRepository.GetUnregisteredUsers();
		}

		/// <summary>
		/// 承認待ちユーザ一覧取得
		/// </summary>
		/// <returns>承認待ちユーザ一覧</returns>
		public List<WaitedApprovalUser> GetWaitingApprovalUsers() {
			this.logger.LogInformation("Call Get Waiting Approval Users");
			return this.userRepository.GetWaitingApprovalUsers();
		}

		/// <summary>
		/// 承認済みユーザ一覧取得
		/// </summary>
		/// <returns>承認済みユーザ一覧取得</returns>
		public List<UserInfo> GetApprovedUsers() {
			this.logger.LogInformation("Call Get Approved Users");
			return this.userRepository.GetApprovedUsers();
		}

		/// <summary>
		/// 承認する
		/// </summary>
		public async Task Approval( int unRegisteredUserSeq , int waitingApprovalUserSeq )
		{
			this.logger.LogInformation( "Start" );
			this.logger.LogDebug( $"Un Registered User Seq is {unRegisteredUserSeq}." );
			this.logger.LogDebug( $"Waiting Approval User Seq is {waitingApprovalUserSeq}." );

			this.userRepository.Approval( unRegisteredUserSeq , waitingApprovalUserSeq );

			UserInfo registeredUser = this.userRepository.GetUser( unRegisteredUserSeq );
			this.logger.LogDebug( $"Registered User Name is {registeredUser.Name}." );
			await this.menuService.ChangeMenu("",registeredUser.Id, MenuService.MainMenuName);
			await this.messageService.CreateMessageBuilder()
				.AddMessage( "幹事さん達に承認されました！\nよろしくお願いしますね！\n下にメニューを表示しました！！" )
				.BuildMessage()
				.Push( registeredUser.Id );

			List<string> userIds = this.userRepository.GetPushedAdminMembers();

			await this.messageService.CreateMessageBuilder()
				.AddMessage( $"{registeredUser.Name}さんが承認されました" )
				.BuildMessage()
				.Multicast( userIds );

			this.logger.LogInformation( "End" );
		}

        /// <summary>
        /// ランダムに名前を表示する
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        public async Task ShowRandomly(JToken parameter)
        {
            this.logger.LogInformation("Start");
            this.logger.LogDebug("Show Random Name");

            string name = this.userRepository.GetRandomUserName();

            this.logger.LogDebug("Name is " + name);

            List<string> userIds = this.userRepository.GetAllUserId();
            
            await this.messageService
                    .CreateMessageBuilder()
                    .AddMessage("おめでとうございます！\n" + name + "さんが選ばれました！！")
                    .BuildMessage()
                    .Multicast(userIds);

            this.logger.LogInformation("End");
        }

	}

}
