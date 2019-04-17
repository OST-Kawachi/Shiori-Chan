using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.RichMenus;

namespace ShioriChan.Services.Features.Menus {

	/// <summary>
	/// メニューService
	/// </summary>
	public class MenuService : IMenuService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

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
		/// <param name="messageService">メッセージService</param>
		/// <param name="richMenuService">リッチメニューService</param>
		public MenuService(
			ILogger<MenuService> logger ,
			IMessageService messageService ,
			IRichMenuService richMenuService
		) {
			this.logger = logger;
			this.messageService = messageService;
			this.richMenuService = richMenuService;
		}

		/// <summary>
		/// メニューを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task ChangeMenu( JToken parameter )
			=> throw new System.NotImplementedException();

		/// <summary>
		/// メニューを変更する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <param name="menuId">メニューID</param>
		public Task ChangeMenu( string userId , string menuId ) => throw new System.NotImplementedException();

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
					{ "name" , "Main Menu" } ,
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
					{ "name" , "Schedule Menu" } ,
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
				} } );
		
		private async Task<string> CreateMapMenu()
			=> await this.richMenuService.Create( new JObject {
					{ "selected" , false } ,
					{ "chatBarText" , "メニューを開く" },
					{ "size" , new JObject {
						{  "width" , 2500 } ,
						{ "height" , 1686 }
					} } ,
					{ "name" , "Map Menu" } ,
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
				} } );

		private async Task<string> CreateAdminMenu()
			=> await this.richMenuService.Create( new JObject {
					{ "selected" , false } ,
					{ "chatBarText" , "メニューを開く" },
					{ "size" , new JObject {
						{  "width" , 2500 } ,
						{ "height" , 1686 }
					} } ,
					{ "name" , "Admin Menu" } ,
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
								{ "type" , "postback" } ,
								{ "data" , "change-position" } ,
								{ "displayText" , "集合場所変更について" }
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

			List<string> richMenuIds = await this.richMenuService.GetIds();
			richMenuIds.ForEach( richMenuId => this.richMenuService.Delete( richMenuId ) );

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
