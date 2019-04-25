using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;
using ShioriChan.Repositories.Schedules;
using ShioriChan.Services.MessagingApis.Messages;

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
		/// 通知する
		/// </summary>
		public async Task Notice() {
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( "Show Random Name" );

			Schedule schedule = this.scheduleRepository.GetSchedule();

			if( schedule is null ) {
				this.logger.LogTrace( "Notification Target Does Not Exist" );
			}
			else {
				string name = schedule.Name;
				string date = schedule.StartDatetime.ToString();

				List<string> userIds = this.scheduleRepository.GetAllUserId();

				await this.messageService
						.CreateMessageBuilder()
						.AddMessage( "5分前です！！\nそろそろ次の予定が始まりますよ！\n" + date + "～ " + name )
						.BuildMessage()
						.Multicast( userIds );

				this.scheduleRepository.UpdateNotified( schedule.Seq );

			}

			this.logger.LogTrace( "End" );
		}

		/// <summary>
		/// 表示する日付を選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ChooseDate( JToken parameter ) {
			this.logger.LogTrace( "Start" );
			string replyToken = this.GetReplyToken( parameter );

			await this.messageService.CreateMessageBuilder()
		   .AddTemplate( "全体スケジュール" )
		   .UseConfirmTemplate( "下から日付を選んでください\n一日のスケジュールを表示します" )
		   .UsePostbackPositiveAction( "1日目" , "firstSchedule" )
		   .BuildPositiveAction()
		   .UsePostbackNegativeAction( "2日目" , "secondSchedule" )
		   .BuildNegativeAction()
		   .BuildMessage()
		   .Reply( replyToken );

			this.logger.LogTrace( "End" );
		}

		/// <summary>
		/// 表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// 変更するスケジュールを選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task SelectToChange( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// スケジュールを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Update( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			string replyToken = firstEvent[ "replyToken" ].ToString();
			this.logger.LogTrace( $"Reply Token is {replyToken}." );

			return replyToken;
		}

	}

}
