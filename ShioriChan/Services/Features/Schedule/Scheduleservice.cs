using System;
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
		public Task Notice() => null;

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
		public async Task Show( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// 変更するスケジュールを選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task SelectToChange( JToken parameter ) {
			this.logger.LogTrace( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogTrace( $"Reply Token is {replyToken}." );

			//スケジュール一覧を取得する
			List<Schedule> schedules = this.scheduleRepository.GetScheduleList();

			int actionNumber = schedules.Count % 3 == 0 ? 3 : schedules.Count % 2 == 0 ? 2 : 1;
			for( int templateNum = 0 ; templateNum < schedules.Count / actionNumber + ( schedules.Count % actionNumber == 0 ? 0 : 1 ) ; templateNum++ ) {
				
				for( int actionNum = templateNum * actionNumber, count = 0 ; actionNum < schedules.Count && count < actionNumber ; actionNum++, count++ ) {
					
				}
				
			}

			await this.messageService.CreateMessageBuilder()
				.AddMessage( "スケジュールを変更します\n下のボタンより変更するスケジュールを選択してください" )
				.AddQuickReply()
				.AddItem( "" ).UsePostbackAction( "aaa1" , "bbb" , "ccc1" )
				.AddItem( "" ).UsePostbackAction( "aaa2" , "bbb" , "ccc2" )
				.AddItem( "" ).UsePostbackAction( "aaa3" , "bbb" , "ccc3" )
				.AddItem( "" ).UsePostbackAction( "aaa4" , "bbb" , "ccc4" )
				.AddItem( "" ).UsePostbackAction( "aaa5" , "bbb" , "ccc5" )
				.AddItem( "" ).UsePostbackAction( "aaa6" , "bbb" , "ccc6" )
				.AddItem( "" ).UsePostbackAction( "aaa7" , "bbb" , "ccc7" )
				.AddItem( "" ).UsePostbackAction( "aaa8" , "bbb" , "ccc8" )
				.AddItem( "" ).UsePostbackAction( "aaa9" , "bbb" , "ccc9" )
				.AddItem( "" ).UsePostbackAction( "aaa0" , "bbb" , "ccc0" )
				.BuildQuickReply()
				.BuildMessage()
				.Reply( replyToken );

			this.logger.LogTrace( "End" );
		}

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
