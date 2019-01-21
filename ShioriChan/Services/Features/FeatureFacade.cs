using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.Features.Sample;
using System.Threading.Tasks;

namespace ShioriChan.Services.Features {

	/// <summary>
	/// しおりちゃん固有機能の窓口Interface
	/// </summary>
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
		private const string PostbackMainContent = "main-content";

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
		/// ポストバックデータ - 管理 - 通知
		/// </summary>
		private const string PostbackAdminPush = "push";

		/// <summary>
		/// ポストバックデータ - 管理 - リスケ
		/// </summary>
		private const string PostbackAdminReSchedule = "reSchedule";

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

		#endregion

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		#region 各機能Servvice

		/// <summary>
		/// サンプル用Service
		/// </summary>
		private readonly ISampleService sampleService;

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="service">サンプル用Service</param>
		public FeatureFacade( ILogger<FeatureFacade> logger , ISampleService service ) {
			this.logger = logger;
			this.sampleService = service;
		}
		
		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Execute( JToken parameter ) {
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
					await this.ShowLastNameHead( parameter );
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

							await this.RecodeMessage( parameter );

							string message = firstEvent[ "message" ][ "text" ].ToString();
							this.logger.LogInformation( "Message is {message}." , message );
							if( message.Contains( ResetMessage ) ) {

							}
							else if(
								message.Contains( ExistMessage1 ) ||
								message.Contains( ExistMessage2 ) ||
								message.Contains( ExistMessage3 )
							) {

							}
							else if( message.Contains( ExistList ) ) {

							}


							break;

						case MessageTypeLocation:
							this.logger.LogInformation( "Start Location Message Event" );
							await this.RecodeLocation( parameter );
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
						case PostbackMainContent:
							break;
						case PostbackMainMap:
							break;
						case PostbackMainRoom:
							break;
						case PostbackMainAdmin:
							break;
						case PostbackMainSchedule:
							break;
						case PostbackMapTouristSpot:
							break;
						case PostbackMapHotel:
							break;
						case PostbackMapBack:
							break;
						case PostbackScheduleOverall:
							break;
						case PostbackScheduleFirstSchedule:
							break;
						case PostbackScheduleSecondSchedule:
							break;
						case PostbackScheduleGather:
							break;
						case PostbackScheduleParticipant:
							break;
						case PostbackAdminPush:
							break;
						case PostbackAdminReSchedule:
							break;
						case PostbackAdminBack:
							break;
						default:
							if( postbackData.StartsWith( PostbackSelectedHeadConditions ) ) {

							}
							else if( postbackData.StartsWith( PostbackDecideUserConditions ) ) {

							}
							else if( postbackData.StartsWith( PostbackChangeHasKeyConditions ) ) {

							}
							else if( postbackData.StartsWith( PostbackDecisionPushConditions ) ) {

							}
							else if( postbackData.StartsWith( PostbackUpdateScheduleConditions ) ) {

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
		private bool IsUnknownUser( string userId ) {

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
		private async Task ShowLastNameHead( JToken parameter )
			// TODO 頭文字選択
			=> await this.sampleService.Execute( parameter );

		/// <summary>
		/// メッセージの登録
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task RecodeMessage( JToken parameter )
			// TODO メッセージ登録
			=> await this.sampleService.Execute( parameter );

		/// <summary>
		/// 位置情報の登録
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		private async Task RecodeLocation( JToken parameter )
			// TODO 位置情報の登録
			=> await this.sampleService.Execute( parameter );
		
	}

}
