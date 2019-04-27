using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShioriChan.Repositories.Schedules {

	/// <summary>
	/// スケジュールRepository
	/// </summary>
	public class ScheduleRepository : IScheduleRepository {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// DBモデル
		/// </summary>
		private readonly ModelCreator model;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		public ScheduleRepository(
			ILogger<ScheduleRepository> logger ,
			ModelCreator model
		) {
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 通知する予定の名称を取得
		/// </summary>
		/// <return>メッセージ</return>
		public Schedule GetSchedule() {
			this.logger.LogTrace( "Start" );
			DateTime now = DateTime.Now;
			Schedule schedule = this.model.Schedules
				 .Where( s => now.AddMinutes( 5 ).AddHours( 9 ) > s.StartDatetime )
				 .Where( s => s.IsNotified == false )
				 .FirstOrDefault();

			this.logger.LogTrace( "End" );

			return schedule;
		}

		/// <summary>
		/// 全員のユーザIDを取得
		/// </summary>
		/// <returns>ユーザID</returns>
		public List<string> GetAllUserId() {
			this.logger.LogTrace( "Start" );
			List<string> userIds = this.model.UserInfos
			   .Where( u => !string.IsNullOrEmpty( u.Id ) )
			   .Select( u => u.Id )
			   .ToList();

			this.logger.LogTrace( "End" );
			return userIds;
		}

		/// <summary>
		/// 通知済みであることを更新する
		/// </summary>
		/// <param name="scheduleSeq">通知したスケジュールの管理番号</param>
		/// <return>メッセージ</return>
		public void UpdateNotified( int scheduleSeq ) {
			this.logger.LogTrace( "Start" );
			Schedule updateSchedule = this.model.Schedules
				 .Where( s => s.Seq == scheduleSeq )
				 .FirstOrDefault();

			updateSchedule.IsNotified = true;
			this.model.SaveChanges();
			this.logger.LogTrace( "End" );
		}

		/// <summary>
		/// スケジュール一覧を取得する
		/// </summary>
		/// <returns>スケジュール情報</returns>
		public List<(int, string, string)> GetSchedulesForSelectToChange() {
			this.logger.LogTrace( "Start" );
			DateTime now = DateTime.Now;

			List<Schedule> schedules = this.model.Schedules
				.Where( s => s.EventSeq == 0 )
				.ToList();

			List<(int, string, string)> result = schedules
				// 現在日時からの差を算出する
				.Select( s => new {
					Data = s ,
					MinutesAbs = Math.Abs(
						s.StartDatetime.Month * 60 * 24 * 30 + s.StartDatetime.Day * 60 * 24 + s.StartDatetime.Hour * 60 + s.StartDatetime.Minute
						- ( now.Month * 60 * 24 * 30 + now.Day * 60 * 24 + now.Hour * 60 + now.Minute )
					)
				} )
				// QuickReplyには13項目しか表示できないので現在日時に近い項目に制限して取得する
				.OrderBy( s => s.MinutesAbs )
				.Where( ( s , index ) => index <= 13 )
				// 表示順にソート
				.OrderBy( s => s.Data.StartDatetime )
				.Select( s => (
					s.Data.Seq ,
					s.Data.StartDatetime.ToString( "MM/dd HH:mm" ) + "～ " + s.Data.Name ,
					s.Data.StartDatetime.ToString( "HH:mm" )
				) )
				.ToList();

			this.logger.LogTrace( "End" );
			return result;

		}

	}
		
}
