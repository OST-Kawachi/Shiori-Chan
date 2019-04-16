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
		private async Task CreateMainMenu()
#pragma warning disable IDE0009
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
#pragma warning restore IDE0009

		/// <summary>
		/// スケジュールメニュー作成
		/// </summary>
		private async Task CreateScheduleMenu()
#pragma warning disable IDE0009
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
#pragma warning restore IDE0009
		
		private async Task CreateMapMenu() {


			// 地図メニューについて
			string mapMenuId = "";
			{

				// リッチメニュー作成
				{

					// Request Body作成
					{

						requestBody[ "name" ] = "Map Menu";

						JArray areas = new JArray();

						// JObject firstArea = new JObject();
						// {
						//     JObject bounds = new JObject();
						//     bounds[ "x" ] = 520;
						//     bounds[ "y" ] = 100;
						//     bounds[ "width" ] = 610;
						//     bounds[ "height" ] = 610;
						//     firstArea[ "bounds" ] = bounds;

						//     JObject action = new JObject();
						//     action[ "type" ] = "postback";
						//     action[ "data" ] = "map-departure";
						//     action[ "displayText" ] = "出発について";
						//     firstArea[ "action" ] = action;
						// }
						// areas.Add( firstArea );

						JObject secondArea = new JObject();
						{
							JObject bounds = new JObject();
							bounds[ "x" ] = 1325;
							bounds[ "y" ] = 100;
							bounds[ "width" ] = 610;
							bounds[ "height" ] = 610;
							secondArea[ "bounds" ] = bounds;

							JObject action = new JObject();
							action[ "type" ] = "postback";
							action[ "data" ] = "map-touristSpot";
							action[ "displayText" ] = "観光地について";
							secondArea[ "action" ] = action;
						}
						areas.Add( secondArea );

						JObject thirdArea = new JObject();
						{
							JObject bounds = new JObject();
							bounds[ "x" ] = 205;
							bounds[ "y" ] = 900;
							bounds[ "width" ] = 610;
							bounds[ "height" ] = 610;
							thirdArea[ "bounds" ] = bounds;

							JObject action = new JObject();
							action[ "type" ] = "postback";
							action[ "data" ] = "map-hotel";
							action[ "displayText" ] = "旅館について";
							thirdArea[ "action" ] = action;
						}
						areas.Add( thirdArea );

						// JObject fourthArea = new JObject();
						// {
						//     JObject bounds = new JObject();
						//     bounds[ "x" ] = 950;
						//     bounds[ "y" ] = 900;
						//     bounds[ "width" ] = 610;
						//     bounds[ "height" ] = 610;
						//     fourthArea[ "bounds" ] = bounds;

						//     JObject action = new JObject();
						//     action[ "type" ] = "postback";
						//     action[ "data" ] = "map-inHotel";
						//     action[ "displayText" ] = "館内について";
						//     fourthArea[ "action" ] = action;
						// }
						// areas.Add( fourthArea );

						JObject fifthArea = new JObject();
						{
							JObject bounds = new JObject();
							bounds[ "x" ] = 1680;
							bounds[ "y" ] = 900;
							bounds[ "width" ] = 610;
							bounds[ "height" ] = 610;
							fifthArea[ "bounds" ] = bounds;

							JObject action = new JObject();
							action[ "type" ] = "postback";
							action[ "data" ] = "map-back";
							action[ "displayText" ] = "戻る";
							fifthArea[ "action" ] = action;
						}
						areas.Add( fifthArea );

						requestBody[ "areas" ] = areas;

					}


				}

			}

		}

		private async Task CreateAdminMenu() {

			// 管理メニューについて
			string adminMenuId = "";
			{

				// リッチメニュー作成
				{

					// Request Body作成
					{

						requestBody[ "name" ] = "Admin Menu";

						JArray areas = new JArray();

						JObject firstArea = new JObject();
						{
							JObject bounds = new JObject();
							bounds[ "x" ] = 520;
							bounds[ "y" ] = 100;
							bounds[ "width" ] = 610;
							bounds[ "height" ] = 610;
							firstArea[ "bounds" ] = bounds;

							JObject action = new JObject();
							action[ "type" ] = "postback";
							action[ "data" ] = "push";
							action[ "displayText" ] = "通知について";
							firstArea[ "action" ] = action;
						}
						areas.Add( firstArea );

						JObject secondArea = new JObject();
						{
							JObject bounds = new JObject();
							bounds[ "x" ] = 1325;
							bounds[ "y" ] = 100;
							bounds[ "width" ] = 610;
							bounds[ "height" ] = 610;
							secondArea[ "bounds" ] = bounds;

							JObject action = new JObject();
							action[ "type" ] = "postback";
							action[ "data" ] = "reSchedule";
							action[ "displayText" ] = "スケジュール変更について";
							secondArea[ "action" ] = action;
						}
						areas.Add( secondArea );

						JObject thirdArea = new JObject();
						{
							JObject bounds = new JObject();
							bounds[ "x" ] = 205;
							bounds[ "y" ] = 900;
							bounds[ "width" ] = 610;
							bounds[ "height" ] = 610;
							thirdArea[ "bounds" ] = bounds;

							JObject action = new JObject();
							action[ "type" ] = "postback";
							action[ "data" ] = "change-position";
							action[ "displayText" ] = "集合場所変更について";
							thirdArea[ "action" ] = action;
						}
						areas.Add( thirdArea );

						JObject fifthArea = new JObject();
						{
							JObject bounds = new JObject();
							bounds[ "x" ] = 1680;
							bounds[ "y" ] = 900;
							bounds[ "width" ] = 610;
							bounds[ "height" ] = 610;
							fifthArea[ "bounds" ] = bounds;

							JObject action = new JObject();
							action[ "type" ] = "postback";
							action[ "data" ] = "admin-back";
							action[ "displayText" ] = "戻る";
							fifthArea[ "action" ] = action;
						}
						areas.Add( fifthArea );

						requestBody[ "areas" ] = areas;

					}

				}

			}

		}

		/// <summary>
		/// メニュー画像を更新する
		/// </summary>
		public async Task UpdateImage() {
			this.logger.LogTrace( "Start" );

			List<string> richMenuIds = await this.richMenuService.GetIds();
			richMenuIds.ForEach( richMenuId => this.richMenuService.Delete( richMenuId ) );

			await this.CreateMainMenu();
			await this.CreateScheduleMenu();
			await this.CreateMapMenu();
			await this.CreateAdminMenu();
			
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
				"curl -v -X POST -H \"Authorization:Bearer " + accessToken + "\" -H \"Content-Type:image/png\" ";

			string curlCommandOfuploadMainMenu =
				curlCommandHead + uploadMainMenuUrl + uploadMainMenuFileName;
			string curlCommandOfuploadScheduleMenu =
				curlCommandHead + uploadScheduleMenuUrl + uploadScheduleMenuFileName;
			string curlCommandOfuploadMapMenu =
				curlCommandHead + uploadMapMenuUrl + uploadMapMenuFileName;
			string curlCommandOfuploadAdminMenu =
				curlCommandHead + uploadAdminMenuUrl + uploadAdminMenuFileName;

			log.Info( "" );
			log.Info( "以下のコマンドをAzure上のBashに張り付けてください" );
			log.Info( moveDirectory );
			log.Info( curlCommandOfuploadMainMenu );
			log.Info( curlCommandOfuploadScheduleMenu );
			log.Info( curlCommandOfuploadMapMenu );
			log.Info( curlCommandOfuploadAdminMenu );
			log.Info( "" );
			log.Info( "メインメニューID : " + mainMenuId );
			log.Info( "スケジュールメニューID : " + scheduleMenuId );
			log.Info( "マップメニューID : " + mapMenuId );
			log.Info( "管理メニューID : " + adminMenuId );
			log.Info( "" );

			log.Info( "Messaging Api Change Rich Menu Http Trigger End" );
			return request.CreateResponse( HttpStatusCode.OK , "" );



		}

	}

}
