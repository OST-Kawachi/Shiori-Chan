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

		public List<(int, string, string)> GetScheduleList() {

			DateTime dNow = DateTime.Now;

			List<(int, string, string )> result = this.model.Schedules
				.Select(
					s => new {
						s.Seq
						,
						StartDateTime = s.StartDatetime
						,
						MainTime = s.StartDatetime
						,
						s.Name
						,
						MinutesAbs = Math.Abs(
							s.StartDatetime.Day * 60 * 24
								+ s.StartDatetime.Hour * 60
								+ s.StartDatetime.Minute
								- (
									  dNow.Day * 60 * 24
									+ dNow.Hour * 60
									+ dNow.Minute
								)
						)
					}
				)
				.OrderBy( s => s.MinutesAbs )
				.Select(
					( s , index ) => new {
						s.Seq
						,
						Label = s.StartDateTime.ToString( "M/d HH:mm" ) + "~ " + s.Name
						,
						StartDateTime = s.StartDateTime.ToString( "HH:mm" )
						,
						s.MainTime
						,
						s.MinutesAbs
						,
						AbsRank = index
					}
				)
				.Where( s => s.AbsRank >= 13 )
				.OrderBy( s => s.MainTime )
				.Select(
					s => new{
						 s.Seq
						,
						s.Label
						,
						s.StartDateTime

					}
				)
				.Cast<(int, string, string)>()
				.ToList();
				
				
			return result;
		}
	}
			

}
