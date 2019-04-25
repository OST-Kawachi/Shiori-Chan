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
				 .Where( s => now.AddMinutes( 5 ) > s.StartDatetime )
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
	}

}
