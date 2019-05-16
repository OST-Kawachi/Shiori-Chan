using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.Menus;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.RichMenus;

namespace ShioriChan.Services.Features.Menus {

	/// <summary>
	/// メニューService
	/// </summary>
	public class MenuService : IMenuService {

		public static readonly string MainMenuName = "Main Menu";

		public static readonly string MapMenuName = "Map Menu";

		public static readonly string ScheduleMenuName = "Schedule Menu";

		public static readonly string AdminMenuName = "Admin Menu";

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// メニューRepository
		/// </summary>
		private readonly IMenuRepository menuRepository;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// リッチメニューService
		/// </summary>
		private readonly IRichMenuService richMenuService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="menuRepository">メニューRepository</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="richMenuService">リッチメニューService</param>
		public MenuService(
			ILogger<MenuService> logger,
			IMenuRepository menuRepository,
			IMessageService messageService,
			IRichMenuService richMenuService
		) {
			this.logger = logger;
			this.menuRepository = menuRepository;
			this.messageService = messageService;
			this.richMenuService = richMenuService;
		}

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken(JToken parameter)
		{
			JArray events = (JArray)parameter["events"];
			JObject firstEvent = (JObject)events[0];

			string replyToken = firstEvent["replyToken"].ToString();
			this.logger.LogTrace($"Reply Token is {replyToken}.");

			return replyToken;
		}

		/// <summary>
		/// ユーザIDを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ユーザID</returns>
		private string GetUserId( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken source = firstEvent[ "source" ];
			string userId = source[ "userId" ].ToString();
			this.logger.LogTrace( $"User Id is {userId}." );

			return userId;
		}

		/// <summary>
		/// ポストバックデータを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ポストバックデータ</returns>
		private string GetPostBackData( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken postback = firstEvent[ "postback" ];
			string data = postback[ "data" ].ToString();
			this.logger.LogTrace( $"Postback Data is {data}." );

			return data;
		}

		/// <summary>
		/// メニューを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ChangeMenu(JToken parameter)
		{
			string replyToken = this.GetReplyToken(parameter);
			string userId = this.GetUserId(parameter);
			string postBackData = this.GetPostBackData(parameter);

			switch (postBackData)
			{
				case "main-map":
					await this.ChangeMenu(replyToken, userId, MapMenuName);
					break;
				case "main-admin":
					await this.ChangeMenu(replyToken, userId, AdminMenuName);
					break;
				case "main-schedule":
					await this.ChangeMenu(replyToken, userId, ScheduleMenuName);
					break;
				case "map-back":
					await this.ChangeMenu(replyToken, userId, MainMenuName);
					break;
				case "schedule-back":
					await this.ChangeMenu(replyToken, userId, MainMenuName);
					break;
				case "admin-back":
					await this.ChangeMenu(replyToken, userId, MainMenuName);
					break;
				default:
					this.logger.LogWarning("Postback Data Is Not Match");
					break;
			}

		}

		/// <summary>
		/// メニューを変更する
		/// </summary>
		/// <param name="replyToken">リプライトークン</param>
		/// <param name="userId">ユーザID</param>
		/// <param name="menuName">メニュー名</param>
		public async Task ChangeMenu(string replyToken, string userId, string menuName)
		{

			if (AdminMenuName.Equals(menuName) && !this.menuRepository.IsOpenAdminMenu(userId))
			{

				await this.messageService.CreateMessageBuilder()
					.AddMessage("申し訳ありませんが、管理メニューは管理者でないと開けません＞＜")
					.BuildMessage()
					.Reply(replyToken);

				return;
			}

			Dictionary<string, string> Ids = await this.richMenuService.GetIds();
			string menuId = Ids[menuName];
			await this.richMenuService.LinkToUser(menuId, userId);
		}

		/// <summary>
		/// メインメニュー作成
		/// </summary>
		private async Task<string> CreateMainMenu()
			=> await this.richMenuService.Create( new JObject {
					{ "selected" , false } ,
					{ "chatBarText" , "メニューを開く" },
					{ "size" , new JObject {
						{  "width" , 2500 } ,
						{ "height" , 1686 }
					} } ,
					{ "name" , MainMenuName } ,
					{ "areas" , new JArray(){
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 520 } ,
								{ "y" , 100 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "main-room" } ,
								{ "displayText" , "部屋について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1325 } ,
								{ "y" , 100 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "main-contact" } ,
								{ "displayText" , "連絡先について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 205 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "main-admin" } ,
								{ "displayText" , "管理について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 950 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "main-schedule" } ,
								{ "displayText" , "スケジュールについて" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1680 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "main-map" } ,
								{ "displayText" , "地図について" }
							} }
						}
					}
				} } );

		/// <summary>
		/// スケジュールメニュー作成
		/// </summary>
		private async Task<string> CreateScheduleMenu()
			=> await this.richMenuService.Create( new JObject {
					{ "selected" , false } ,
					{ "chatBarText" , "メニューを開く" },
					{ "size" , new JObject {
						{  "width" , 2500 } ,
						{ "height" , 1686 }
					} } ,
					{ "name" , ScheduleMenuName } ,
					{ "areas" , new JArray(){
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 520 } ,
								{ "y" , 100 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "schedule-overall" } ,
								{ "displayText" , "全体について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1325 } ,
								{ "y" , 100 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "schedule-gather" } ,
								{ "displayText" , "集合について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 205 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "schedule-participant" } ,
								{ "displayText" , "参加者について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1680 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "schedule-back" } ,
								{ "displayText" , "戻る" }
							} }
						}
					}
				} });

		/// <summary>
		/// 地図メニューの作成
		/// </summary>
		/// <returns></returns>
		private async Task<string> CreateMapMenu()
			=> await this.richMenuService.Create(new JObject {
					{ "selected" , false } ,
					{ "chatBarText" , "メニューを開く" },
					{ "size" , new JObject {
						{  "width" , 2500 } ,
						{ "height" , 1686 }
					} } ,
					{ "name" , MapMenuName } ,
					{ "areas" , new JArray(){
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1325 } ,
								{ "y" , 100 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "map-touristSpot" } ,
								{ "displayText" , "観光地について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 205 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "map-hotel" } ,
								{ "displayText" , "旅館について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1680 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "map-back" } ,
								{ "displayText" , "戻る" }
							} }
						}
					}
				} });

		/// <summary>
		/// 管理メニューの作成
		/// </summary>
		/// <returns></returns>
		private async Task<string> CreateAdminMenu()
			=> await this.richMenuService.Create(new JObject {
					{ "selected" , false } ,
					{ "chatBarText" , "メニューを開く" },
					{ "size" , new JObject {
						{  "width" , 2500 } ,
						{ "height" , 1686 }
					} } ,
					{ "name" , AdminMenuName } ,
					{ "areas" , new JArray(){
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 520 } ,
								{ "y" , 100 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "push" } ,
								{ "displayText" , "通知について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1325 } ,
								{ "y" , 100 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "reSchedule" } ,
								{ "displayText" , "スケジュール変更について" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 205 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "uri" } ,
								{ "uri" , "https://shiorichanappservice.azurewebsites.net/shiori-chan/roll-call/list" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 950 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "admin-random" } ,
								{ "displayText" , "ランダムにユーザ名表示して" }
							} }
						} ,
						new JObject(){
							{ "bounds" , new JObject() {
								{ "x" , 1680 } ,
								{ "y" , 900 } ,
								{ "width" , 610 } ,
								{ "height" , 610 }
							} } ,
							{ "action" , new JObject() {
								{ "type" , "postback" } ,
								{ "data" , "admin-back" } ,
								{ "displayText" , "戻る" }
							} }
						}
					}
				} } );

		/// <summary>
		/// メニュー画像を更新する
		/// </summary>
		public async Task UpdateImage() {
			this.logger.LogTrace( "Start" );

			Dictionary<string,string> richMenuIds = await this.richMenuService.GetIds();
			foreach( KeyValuePair<string , string> richMenuId in richMenuIds ) {
				await this.richMenuService.Delete( richMenuId.Value );
			}

			string mainMenuId = await this.CreateMainMenu();
			string scheduleMenuId = await this.CreateScheduleMenu();
			string mapMenuId = await this.CreateMapMenu();
			string adminMenuId = await this.CreateAdminMenu();
			
			this.logger.LogTrace( "End" );

			string moveDirectory = "cd /home/shassbeleth/clouddrive";

			string uploadRichMenuUrlHead = " https://api.line.me/v2/bot/richmenu/";
			string uploadRichMenuUrlFoot = "/content ";

			string uploadMainMenuUrl = uploadRichMenuUrlHead + mainMenuId + uploadRichMenuUrlFoot;
			string uploadScheduleMenuUrl = uploadRichMenuUrlHead + scheduleMenuId + uploadRichMenuUrlFoot;
			string uploadMapMenuUrl = uploadRichMenuUrlHead + mapMenuId + uploadRichMenuUrlFoot;
			string uploadAdminMenuUrl = uploadRichMenuUrlHead + adminMenuId + uploadRichMenuUrlFoot;

			string uploadMainMenuFileName = " -T メインメニュー.png ";
			string uploadScheduleMenuFileName = " -T スケジュール.png ";
			string uploadMapMenuFileName = " -T 地図.png ";
			string uploadAdminMenuFileName = " -T 管理メニュー.png ";

			string curlCommandHead =
				"curl -v -X POST -H \"Authorization:Bearer {}\" -H \"Content-Type:image/png\" ";

			string curlCommandOfuploadMainMenu =
				curlCommandHead + uploadMainMenuUrl + uploadMainMenuFileName;
			string curlCommandOfuploadScheduleMenu =
				curlCommandHead + uploadScheduleMenuUrl + uploadScheduleMenuFileName;
			string curlCommandOfuploadMapMenu =
				curlCommandHead + uploadMapMenuUrl + uploadMapMenuFileName;
			string curlCommandOfuploadAdminMenu =
				curlCommandHead + uploadAdminMenuUrl + uploadAdminMenuFileName;


			this.logger.LogInformation( "///////////////////////////////////////////////////////////////" );
			this.logger.LogInformation( "以下のコマンドをAzure上のBashに貼り付けてください" );
			this.logger.LogInformation( "アクセストークンはDBより取得してください" );
			this.logger.LogInformation( moveDirectory );
			this.logger.LogInformation( curlCommandOfuploadMainMenu );
			this.logger.LogInformation( curlCommandOfuploadScheduleMenu );
			this.logger.LogInformation( curlCommandOfuploadMapMenu );
			this.logger.LogInformation( curlCommandOfuploadAdminMenu );
			this.logger.LogInformation( "" );
			this.logger.LogInformation( "メインメニューID : " + mainMenuId );
			this.logger.LogInformation( "スケジュールメニューID : " + scheduleMenuId );
			this.logger.LogInformation( "マップメニューID : " + mapMenuId );
			this.logger.LogInformation( "管理メニューID : " + adminMenuId );
			this.logger.LogInformation( "////////////////////////////////////////////////////////////////////" );

		}

	}

}
