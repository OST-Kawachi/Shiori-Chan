using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShioriChan.Entities;

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

		public dynamic GetScheduleList() {

			DateTime dNow = System.DateTime.Now;

			var result = this.model.Schedules
				.Select(
					s => new {
						SEQ = s.Seq
						,
						START_TIME = s.StartDatetime
						,
						MAIN_TIME = s.StartDatetime
						,
						NAME = s.Name
						,
						MINUTES_ABS = Math.Abs(
							int.Parse( s.StartDatetime.Date.ToString() ) * 60 * 24
								+ s.StartDatetime.Hour * 60
								+ s.StartDatetime.Minute
								- (
									  int.Parse( dNow.Date.ToString() ) * 60 * 24
									+ dNow.Hour * 60
									+ dNow.Minute
								)
						)
					}
				)
				.OrderBy( s => s.MINUTES_ABS )
				.Select(
					( s , index ) => new {
						s.SEQ
						,
						LABEL = s.START_TIME.ToString( "M/d HH:mm" ) + "~ " + s.NAME
						,
						START_TIME = s.START_TIME.ToString( "HH:mm" )
						,
						s.MAIN_TIME
						,
						s.MINUTES_ABS
						,
						ABS_RANK = index
					}
				)
				.OrderBy( s => s.MAIN_TIME )
				.Select(
					s => new {
						s.SEQ
						,
						s.LABEL
						,
						s.START_TIME
						,
						s.MINUTES_ABS
						,
						s.ABS_RANK
					}
				)
				.Where( s => s.ABS_RANK >= 30 );
				
			return result;
		}
	}
			

}
