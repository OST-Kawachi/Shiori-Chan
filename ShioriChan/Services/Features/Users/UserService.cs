using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;
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
					.AddMessage( "初めまして！\nしおりと申します！！\nあなたの旅のおともをさせていただきます！\nよろしくお願いします！！" )
					.AddMessage( "まずはあなたのお名前を教えてください！" )
					.AddTemplate("名前を教えてね！")
						.UseButtonTemplate( "名前を教える" )
						.SetAction()
						.UseUriAction( "名前を教えます" , "https://shiorichanappservice.azurewebsites.net/shiori-chan/user/apply/" + waitingApprovalUserSeq )
						.BuildTemplate()
					.BuildMessage()
					.Reply( replyToken );
			}

			this.logger.LogTrace( "End" );
		}

		/// <summary>
		/// 申請する
		/// </summary>
		/// <param name="seq">管理番号</param>
		/// <param name="name">ユーザ名</param>
		public async void Apply( int seq , string name )
		{
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"Seq is {seq}." );
			this.logger.LogTrace( $"User Name is {name}." );

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

			this.logger.LogTrace( "End" );
			return;
		}

		/// <summary>
		/// 未登録ユーザ一覧取得
		/// </summary>
		/// <returns>未登録ユーザ一覧</returns>
		public List<UserInfo> GetUnregisteredUsers()
			=> this.userRepository.GetUnregisteredUsers();

		/// <summary>
		/// 承認待ちユーザ一覧取得
		/// </summary>
		/// <returns>承認待ちユーザ一覧</returns>
		public List<WaitedApprovalUser> GetWaitingApprovalUsers()
			=> this.userRepository.GetWaitingApprovalUsers();
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
