using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;
using ShioriChan.Repositories.Schedules;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies;

namespace ShioriChan.Services.Features.Schedules {

	/// <summary>
	/// スケジュールService
	/// </summary>
	public class ScheduleService : IScheduleService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// スケジュールRepository
		/// </summary>
		private readonly IScheduleRepository scheduleRepository;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="scheduleRepository">スケジュールRepository</param>
		public ScheduleService(
			ILogger<ScheduleService> logger ,
			IMessageService messageService ,
			IScheduleRepository scheduleRepository
		) {
			this.logger = logger;
			this.messageService = messageService;
			this.scheduleRepository = scheduleRepository;
		}

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			string replyToken = firstEvent[ "replyToken" ].ToString();
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

			return replyToken;
		}

		/// <summary>
		/// ポストバックデータを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ポストバックデータ</returns>
		private string GetPostbackData( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken postback = firstEvent[ "postback" ];
			string data = postback[ "data" ].ToString();
			this.logger.LogDebug( $"Postback Data is {data}." );
			return data;
		}

		/// <summary>
		/// 日付データを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ポストバックデータ</returns>
		private string GetTime( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken postback = firstEvent[ "postback" ];
			string time = postback[ "params" ]["time"].ToString();
			this.logger.LogDebug( $"Time is {time}." );
			return time;
		}

		/// <summary>
		/// 通知する
		/// </summary>
		public async Task Notice() {
			this.logger.LogInformation( "Start" );

			Schedule schedule = this.scheduleRepository.GetSchedule();

			if( schedule is null ) {
				this.logger.LogDebug( "Notification Target Does Not Exist" );
			}
			else {
				string name = schedule.Name;
				string date = schedule.StartDatetime.ToString( "HH:mm" );
				this.logger.LogDebug($"Name is {name}");
				this.logger.LogDebug($"Date is {date}");

				List<string> userIds = this.scheduleRepository.GetAllUserId();

				this.scheduleRepository.UpdateNotified( schedule.Seq );

				await this.messageService
						.CreateMessageBuilder()
						.AddMessage( "5分前です！！\nそろそろ次の予定が始まりますよ！\n" + date + "～ " + name )
						.BuildMessage()
						.Multicast( userIds );

			}

			this.logger.LogInformation( "End" );
		}

		/// <summary>
		/// 表示する日付を選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ChooseDate( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogDebug($"Reply Token is {replyToken}");

			await this.messageService.CreateMessageBuilder()
		   .AddTemplate( "全体スケジュール" )
		   .UseConfirmTemplate( "下から日付を選んでください\n一日のスケジュールを表示します" )
		   .UsePostbackPositiveAction( "1日目" , "firstSchedule" )
		   .BuildPositiveAction()
		   .UsePostbackNegativeAction( "2日目" , "secondSchedule" )
		   .BuildNegativeAction()
		   .BuildMessage()
		   .Reply( replyToken );

			this.logger.LogInformation( "End" );
		}

		/// <summary>
		/// 表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Show( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			string postbackData = this.GetPostbackData( parameter );
			this.logger.LogDebug($"Reply Token is {replyToken}");
			this.logger.LogDebug($"Postback Data is {postbackData}");

			bool isFirst = "firstSchedule".Equals( postbackData );
			this.logger.LogDebug( $"Is First Schedule ... {isFirst}" );

			List<(string name, string startTime)> schedules = this.scheduleRepository.GetSchedules( isFirst );
			string message = "";
			foreach( (string name, string startTime) in schedules ) {
				message += $"{startTime}～ {name}\n";
			}

			await this.messageService.CreateMessageBuilder()
				.AddMessage( message )
				.BuildMessage()
				.Reply( replyToken );

			this.logger.LogInformation( "End" );
		}



		/// <summary>
		/// 変更するスケジュールを選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task SelectToChange( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

			//スケジュール一覧を取得する
			List<(int, string, string)> schedules = this.scheduleRepository.GetSchedulesForSelectToChange();

			IAddOnlyItemOfQuickReply quickReplyBuilder = this.messageService.CreateMessageBuilder()
				.AddMessage( "スケジュールを変更します\n下のボタンより変更するスケジュールを選択してください" )
				.AddQuickReply();

			ISettableDatepickerActionOfQuickReply settableDatepickerActionOfQuickReply = null;
			foreach( (int seq, string label, string initialdate) in schedules ) {
				settableDatepickerActionOfQuickReply = settableDatepickerActionOfQuickReply is null ? 
				quickReplyBuilder.AddItem( "" ).UseDatepickerAction(
					( label.Length > 20 ) ? label.Substring( 0 , 20 ) : label ,
					"updateSchedule?seq=" + seq ,
					"time"
				).SetInitial( initialdate ) : 
				settableDatepickerActionOfQuickReply.AddItem( "" ).UseDatepickerAction(
					( label.Length > 20 ) ? label.Substring( 0 , 20 ) : label ,
					"updateSchedule?seq=" + seq ,
					"time"
				).SetInitial( initialdate );
			}

			await settableDatepickerActionOfQuickReply
				.BuildQuickReply()
				.BuildMessage()
				.Reply( replyToken );

			this.logger.LogInformation( "End" );
		}

		/// <summary>
		/// スケジュールを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Update( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string postbackData = this.GetPostbackData( parameter );
			this.logger.LogDebug($"Postback Data is {postbackData}");

			int seq = int.Parse( postbackData.Split( "updateSchedule?seq=" )[1] );
			this.logger.LogDebug( $"Schedule Seq is {seq}" );

			string dateTime = this.GetTime( parameter );
			this.logger.LogDebug($"Date Time is {dateTime}");

			Schedule schedule = this.scheduleRepository.UpdateSchedule( seq , dateTime );
			string name = schedule.Name;
			this.logger.LogDebug($"Name is {name}");

			List<string> toList = this.scheduleRepository.GetAllUserId();

			await this.messageService.CreateMessageBuilder()
				.AddMessage( $"{name}の時間が{dateTime}～ に変更されました！" )
				.BuildMessage()
				.Multicast( toList );

			this.logger.LogInformation( "End" );
		}

	}

}
