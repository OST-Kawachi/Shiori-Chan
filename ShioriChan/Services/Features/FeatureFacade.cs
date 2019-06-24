using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.Features.Contacts;
using ShioriChan.Services.Features.Hotels;
using ShioriChan.Services.Features.MeetingPlaces;
using ShioriChan.Services.Features.Menus;
using ShioriChan.Services.Features.Notifications;
using ShioriChan.Services.Features.Participants;
using ShioriChan.Services.Features.RollCalls;
using ShioriChan.Services.Features.Rooms;
using ShioriChan.Services.Features.Schedules;
using ShioriChan.Services.Features.TouristSpots;
using ShioriChan.Services.Features.Users;
using System.Threading.Tasks;

namespace ShioriChan.Services.Features {

	/// <summary>
	/// しおりちゃん固有機能の窓口Interface
	/// </summary>
	/// TODO 定数群を別クラスに置きたい
	public class FeatureFacade : IFeatureFacade {

		#region イベント種別

		/// <summary>
		/// イベント種別 - ユーザ追加
		/// </summary>
		private const string EventTypeFollow = "follow";

		/// <summary>
		/// イベント種別 - メッセージ
		/// </summary>
		private const string EventTypeMessage = "message";

		/// <summary>
		/// イベント種別 - postback
		/// </summary>
		private const string EventTypePostback = "postback";

		#endregion

		#region メッセージ種別

		/// <summary>
		/// メッセージ種別 - テキスト
		/// </summary>
		private const string MessageTypeText = "text";

		/// <summary>
		/// メッセージ種別 - 位置情報
		/// </summary>
		private const string MessageTypeLocation = "location";

		#endregion

		#region メッセージ文字列による判定

		/// <summary>
		/// 点呼リセット
		/// </summary>
		private const string ResetMessage = "リセット";

		/// <summary>
		/// 点呼
		/// </summary>
		private const string ExistMessage1 = "いるよ";

		/// <summary>
		/// 点呼
		/// </summary>
		private const string ExistMessage2 = "います";

		/// <summary>
		/// 点呼
		/// </summary>
		private const string ExistMessage3 = "居るよ";

		/// <summary>
		/// 点呼一覧
		/// </summary>
		private const string ExistList = "一覧";

		#endregion

		#region ポストバックデータ

		/// <summary>
		/// ポストバックデータ - メイン - 連絡
		/// </summary>
		private const string PostbackMainContact = "main-contact";

		/// <summary>
		/// ポストバックデータ - メイン - 地図
		/// </summary>
		private const string PostbackMainMap = "main-map";

		/// <summary>
		/// ポストバックデータ - メイン - 部屋
		/// </summary>
		private const string PostbackMainRoom = "main-room";

		/// <summary>
		/// ポストバックデータ - メイン - 管理
		/// </summary>
		private const string PostbackMainAdmin = "main-admin";

		/// <summary>
		/// ポストバックデータ - メイン - スケジュール
		/// </summary>
		private const string PostbackMainSchedule = "main-schedule";

		/// <summary>
		/// ポストバックデータ - マップ - 観光地について
		/// </summary>
		private const string PostbackMapTouristSpot = "map-touristSpot";

		/// <summary>
		/// ポストバックデータ - マップ - 旅館について
		/// </summary>
		private const string PostbackMapHotel = "map-hotel";

		/// <summary>
		/// ポストバックデータ - マップ - 戻る
		/// </summary>
		private const string PostbackMapBack = "map-back";

		/// <summary>
		/// ポストバックデータ - スケジュール - 全体について
		/// </summary>
		private const string PostbackScheduleOverall = "schedule-overall";

		/// <summary>
		/// ポストバックデータ - スケジュール - 1日目の全体スケジュール表示
		/// </summary>
		private const string PostbackScheduleFirstSchedule = "firstSchedule";

		/// <summary>
		/// ポストバックデータ - スケジュール - 2日目の全体スケジュール表示
		/// </summary>
		private const string PostbackScheduleSecondSchedule = "secondSchedule";

		/// <summary>
		/// ポストバックデータ - スケジュール - 集合について
		/// </summary>
		private const string PostbackScheduleGather = "schedule-gather";

		/// <summary>
		/// ポストバックデータ - スケジュール - 参加者について
		/// </summary>
		private const string PostbackScheduleParticipant = "schedule-participant";

		/// <summary>
		/// ポストバックデータ - スケジュール - 戻る
		/// </summary>
		private const string PostbackScheduleBack = "schedule-back";

		/// <summary>
		/// ポストバックデータ - 管理 - 通知
		/// </summary>
		private const string PostbackAdminPush = "push";

		/// <summary>
		/// ポストバックデータ - 管理 - リスケ
		/// </summary>
		private const string PostbackAdminReSchedule = "reSchedule";

		/// <summary>
		/// ポストバックデータ - 管理 - ランダム表示
		/// </summary>
		private const string PostbackAdminRandom = "admin-random";

		/// <summary>
		/// ポストバックデータ - 管理 - 戻る
		/// </summary>
		private const string PostbackAdminBack = "admin-back";

		/// <summary>
		/// ポストバックデータ - 管理 - 集合場所変更
		/// </summary>
		private const string PostbackAdminChangePosition = "change-position";

		/// <summary>
		/// ポストバックデータ - 頭文字決定
		/// </summary>
		private const string PostbackSelectedHeadConditions = "selectedHead";

		/// <summary>
		/// ポストバックデータ - 名前決定
		/// </summary>
		private const string PostbackDecideUserConditions = "decideUserSeq";

		/// <summary>
		/// ポストバックデータ - 鍵を持っている人を変更
		/// </summary>
		private const string PostbackChangeHasKeyConditions = "changeHasKey";

		/// <summary>
		/// ポストバックデータ - プッシュ通知を送信する
		/// </summary>
		private const string PostbackDecisionPushConditions = "decisionPush";

		/// <summary>
		/// ポストバックデータ - リスケ決定
		/// </summary>
		private const string PostbackUpdateScheduleConditions = "updateSchedule";

		/// <summary>
		/// ポストバックデータ - 点呼返信
		/// </summary>
		private const string PostbackRollCallReply = "roll-call-reply";

		#endregion

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		#region 各機能Servvice

		/// <summary>
		/// 部屋情報Service
		/// </summary>
		private readonly IRoomService roomService;

		/// <summary>
		/// 集合場所Service
		/// </summary>
		private readonly IMeetingPlaceService meetingPlaceService;

		/// <summary>
		/// メニューService
		/// </summary>
		private readonly IMenuService menuService;

		/// <summary>
		/// ユーザService
		/// </summary>
		private readonly IUserService userService;

		/// <summary>
		/// 連絡先Service
		/// </summary>
		private readonly IContactService contactService;

		/// <summary>
		/// 観光地Service
		/// </summary>
		private readonly ITouristSpotService touristSpotService;

		/// <summary>
		/// 宿泊施設Service
		/// </summary>
		private readonly IHotelService hotelService;

		/// <summary>
		/// スケジュールService
		/// </summary>
		private readonly IScheduleService scheduleService;

		/// <summary>
		/// 点呼Service
		/// </summary>
		private readonly IRollCallService rollCallService;

		/// <summary>
		/// 参加者Service
		/// </summary>
		private readonly IParticipantService participantService;

		/// <summary>
		/// 通知Service
		/// </summary>
		private readonly INotificationService notificationService;

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="roomService">部屋情報Service</param>
		/// <param name="meetingPlaceService">集合場所Service</param>
		/// <param name="menuService">メニューService</param>
		/// <param name="userService">ユーザService</param>
		/// <param name="contactService">連絡先Service</param>
		/// <param name="touristSpotService">観光地Service</param>
		/// <param name="hotelService">宿泊施設Service</param>
		/// <param name="scheduleService">スケジュールService</param>
		/// <param name="rollCallService">点呼Service</param>
		/// <param name="participantService">参加者Service</param>
		/// <param name="notificationService">通知Service</param>
		public FeatureFacade(
			ILogger<FeatureFacade> logger ,
			IRoomService roomService ,
			IMeetingPlaceService meetingPlaceService ,
			IMenuService menuService ,
			IUserService userService ,
			IContactService contactService ,
			ITouristSpotService touristSpotService ,
			IHotelService hotelService ,
			IScheduleService scheduleService ,
			IRollCallService rollCallService ,
			IParticipantService participantService ,
			INotificationService notificationService
		)
		{
			this.logger = logger;
			this.roomService = roomService;
			this.meetingPlaceService = meetingPlaceService;
			this.menuService = menuService;
			this.userService = userService;
			this.contactService = contactService;
			this.touristSpotService = touristSpotService;
			this.hotelService = hotelService;
			this.scheduleService = scheduleService;
			this.rollCallService = rollCallService;
			this.participantService = participantService;
			this.notificationService = notificationService;
		}

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// TODO かなり1メソッドの役割が大きいので細分化したい
		public async Task Execute( JToken parameter )
		{
			this.logger.LogTrace( "Start" );

			if( parameter is null ) {
				this.logger.LogWarning( "Parameter is NULL." );
				this.logger.LogTrace( "End" );
				return;
			}

			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];
			string eventType = firstEvent[ "type" ].ToString();
			string userId = firstEvent[ "source" ][ "userId" ]?.ToString();

			this.logger.LogInformation( "Event Type is {eventType}." , eventType );
			switch( eventType ) {

				case EventTypeFollow:
					this.logger.LogInformation( "Start Follow Event." );
					await this.ShowMenuAndUrlIfNotRegistered( parameter );
					break;

				case EventTypeMessage:
					this.logger.LogInformation( "Start Message Event." );

					if( this.IsUnknownUser( userId ) ) {
						this.logger.LogInformation( "User is Unknown." );
						break;
					}

					JObject messageParameter = (JObject)firstEvent[ "message" ];
					string messageType = messageParameter[ "type" ].ToString();
					this.logger.LogInformation( "Message Type is {messageType}." , messageType );
					switch( messageType ) {

						case MessageTypeText:
							this.logger.LogInformation( "Start Text Message Event" );

							this.RegisterMessage( parameter );

							string message = firstEvent[ "message" ][ "text" ].ToString();
							this.logger.LogInformation( "Message is {message}." , message );

							break;

						case MessageTypeLocation:
							this.logger.LogInformation( "Start Location Message Event" );
							this.RecodeLocation( parameter );
							break;

						default:
							this.logger.LogWarning( "Unexpected Message Type." );
							break;
					}
					break;

				case EventTypePostback:
					this.logger.LogInformation( "Start Postback Event." );

					string postbackData = firstEvent[ "postback" ][ "data" ].ToString();
					this.logger.LogInformation( "Postback Data is {postbackData}." , postbackData );
					switch( postbackData ) {

						case PostbackMainContact:
							this.logger.LogInformation( "Start Main Content" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ReplyContent( parameter );

							break;

						case PostbackMainMap:
							this.logger.LogInformation( "Start Main Map" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ChangeMenuMap( parameter );

							break;

						case PostbackMainRoom:
							this.logger.LogInformation( "Start Main Room" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ShowRoomMember( parameter );

							break;

						case PostbackMainAdmin:
							this.logger.LogInformation( "Start Main Admin" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ChangeMenuAdmin( parameter );

							break;

						case PostbackMainSchedule:
							this.logger.LogInformation( "Start Main Schedule" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ChangeMenuSchedule( parameter );

							break;

						case PostbackMapTouristSpot:
							this.logger.LogInformation( "Start Map Tourist Spot" );
							await this.ShowTouristShop( parameter );
							break;

						case PostbackMapHotel:
							this.logger.LogInformation( "Start Map Hotel" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ShowHotel( parameter );

							break;

						case PostbackMapBack:
							this.logger.LogInformation( "Start Map Back" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.BackFromMap( parameter );

							break;

						case PostbackScheduleOverall:
							this.logger.LogInformation( "Start Schedule Overall" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ChooseSchedule( parameter );

							break;

						case PostbackScheduleFirstSchedule:
							this.logger.LogInformation( "Start Schedule First Schedule" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ShowFirstSchedule( parameter );

							break;

						case PostbackScheduleSecondSchedule:
							this.logger.LogInformation( "Start Schedule Second Schedule" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ShowSecondSchedule( parameter );

							break;

						case PostbackScheduleGather:
							this.logger.LogInformation( "Start Schedule Gather" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ShowMeetingPlace( parameter );

							break;

						case PostbackScheduleParticipant:
							this.logger.LogInformation( "Start Schedule Participant" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ShowParticipant( parameter );

							break;

						case PostbackScheduleBack:
							this.logger.LogInformation( "Start Schedule Back" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.BackFromSchedule( parameter );

							break;

						case PostbackAdminPush:
							this.logger.LogInformation( "Start Admin Push" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ConfirmPush( parameter );

							break;

						case PostbackAdminReSchedule:
							this.logger.LogInformation( "Start Admin Re Schedule" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.SelectToChange( parameter );

							break;

						case PostbackAdminBack:
							this.logger.LogInformation( "Start Admin Back" );

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.BackFromAdmin( parameter );

							break;

						case PostbackAdminRandom:
							this.logger.LogInformation("Start Random");

							if( this.IsUnknownUser( userId ) ) {
								this.logger.LogWarning( "User is Unknown." );
								break;
							}

							await this.ShowRandomName( parameter );

							break;

						case PostbackRollCallReply:
							this.logger.LogInformation( "Start Exist User" );
							await this.Reply( parameter );
							break;

						default:
							if( postbackData.StartsWith( PostbackChangeHasKeyConditions ) ) {
								this.logger.LogInformation( "Start Change Has Key User" );

								if( this.IsUnknownUser( userId ) ) {
									this.logger.LogWarning( "User is Unknown." );
									break;
								}

								await this.ChangeHavingKeyUser( parameter );

							}
							else if( postbackData.StartsWith( PostbackDecisionPushConditions ) ) {
								this.logger.LogInformation( "Start Decision Push" );

								if( this.IsUnknownUser( userId ) ) {
									this.logger.LogWarning( "User is Unknown." );
									break;
								}

								await this.Push( parameter );

							}
							else if( postbackData.StartsWith( PostbackUpdateScheduleConditions ) ) {
								this.logger.LogInformation( "Start Update Schedule" );

								if( this.IsUnknownUser( userId ) ) {
									this.logger.LogWarning( "User is Unknown." );
									break;
								}

								await this.UpdateSchedule( parameter );

							}
							else {
								this.logger.LogWarning( "Unexpected Postback Data." );
							}
							break;
					}
					break;

				default:
					this.logger.LogWarning( "Unexpected Event Type." );
					break;
			}

			this.logger.LogTrace( "End" );
		}

		/// <summary>
		/// 登録されていないユーザかどうか判定する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>登録されていないユーザかどうか</returns>
		private bool IsUnknownUser( string userId )
		{

			if( userId is null ) {
				this.logger.LogInformation( "User Id is Null." );
				return true;
			}

			// TODO 登録されていないユーザかどうか判定する

			return false;
		}

		/// <summary>
		/// ユーザ追加イベント実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowMenuAndUrlIfNotRegistered( JToken parameter )
			=> await this.userService.ShowMenuAndUrlIfNotRegistered( parameter );

		/// <summary>
		/// メッセージの登録
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private void RegisterMessage( JToken parameter )
			=> this.notificationService.Register( parameter );

		/// <summary>
		/// 位置情報の登録
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private void RecodeLocation( JToken parameter )
			=> this.meetingPlaceService.Register( parameter );

		/// <summary>
		/// 連絡先の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ReplyContent( JToken parameter )
			=> await this.contactService.Show( parameter );

		/// <summary>
		/// 地図メニュー表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ChangeMenuMap( JToken parameter )
			=> await this.menuService.ChangeMenu( parameter );

		/// <summary>
		/// 同じ部屋のメンバー表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowRoomMember( JToken parameter )
			=> await this.roomService.ShowRoomMember( parameter );

		/// <summary>
		/// 管理メニュー表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ChangeMenuAdmin( JToken parameter )
			=> await this.menuService.ChangeMenu( parameter );

		/// <summary>
		/// スケジュールメニュー表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ChangeMenuSchedule( JToken parameter )
			=> await this.menuService.ChangeMenu( parameter );

		/// <summary>
		/// 観光地情報の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowTouristShop( JToken parameter )
			=> await this.touristSpotService.Show( parameter );

		/// <summary>
		/// ホテル情報の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowHotel( JToken parameter )
			=> await this.hotelService.Show( parameter );

		/// <summary>
		/// マップから戻る
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task BackFromMap( JToken parameter )
			=> await this.menuService.ChangeMenu( parameter );

		/// <summary>
		/// 全体スケジュールの表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ChooseSchedule( JToken parameter )
			=> await this.scheduleService.ChooseDate( parameter );

		/// <summary>
		/// 1日目の全体スケジュール表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowFirstSchedule( JToken parameter )
			=> await this.scheduleService.Show( parameter );

		/// <summary>
		/// 2日目の全体スケジュール表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowSecondSchedule( JToken parameter )
			=> await this.scheduleService.Show( parameter );

		/// <summary>
		/// 集合場所の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowMeetingPlace( JToken parameter )
			=> await this.meetingPlaceService.Show( parameter );

		/// <summary>
		/// 参加者の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowParticipant( JToken parameter )
			=> await this.participantService.Show( parameter );

		/// <summary>
		///スケジュールから戻る
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task BackFromSchedule( JToken parameter )
			=> await this.menuService.ChangeMenu( parameter );

		/// <summary>
		/// プッシュ通知を送るか確認する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ConfirmPush( JToken parameter )
			=> await this.notificationService.Confirm( parameter );

		/// <summary>
		/// リスケ
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task SelectToChange( JToken parameter )
			=> await this.scheduleService.SelectToChange( parameter );

		/// <summary>
		/// 管理メニューから戻る
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task BackFromAdmin( JToken parameter )
			=> await this.menuService.ChangeMenu( parameter );

		/// <summary>
		/// ランダムに名前を表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ShowRandomName( JToken parameter )
			=> await this.userService.ShowRandomly( parameter );
		
		/// <summary>
		/// 鍵を持っている人を変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task ChangeHavingKeyUser( JToken parameter )
			=> await this.roomService.ChangeHavingKeyUser( parameter );

		/// <summary>
		/// プッシュ通知を送信する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task Push( JToken parameter )
			=> await this.notificationService.Push( parameter );

		/// <summary>
		/// スケジュールを変更
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task UpdateSchedule( JToken parameter )
			=> await this.scheduleService.Update( parameter );

		/// <summary>
		/// 点呼
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task Reply( JToken parameter )
			=> this.rollCallService.Reply( parameter );

	}

}
