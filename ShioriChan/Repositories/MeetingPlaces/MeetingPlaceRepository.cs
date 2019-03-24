using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShioriChan.Repositories.MeetingPlaces {

	/// <summary>
	/// 集合場所Repository
	/// </summary>
	public class MeetingPlaceRepository : IMeetingPlaceRepository {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// データモデル
		/// </summary>
		private readonly ModelCreator model;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="model">データモデル</param>
		public MeetingPlaceRepository(
			ILogger<MeetingPlaceRepository> logger ,
			ModelCreator model
		)
		{
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 集合場所を登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <param name="title">タイトル</param>
		/// <param name="address">住所</param>
		/// <param name="latitude">緯度</param>
		/// <param name="longitude">経度</param>
		public void Register( string userId , string title , string address , double latitude , double longitude )
		{
			this.logger.LogTrace( "Start" );

			List<Schedule> schedules = this.model.Schedules
				.Where( schedule => this.model.UserInfos
					.Where( u => userId.Equals( userId ) )
					.Any( u => u.ParticipatingEventSeq == schedule.EventSeq )
				)
				.ToList();

			this.logger.LogTrace( $"Schedules Count is {schedules.Count}." );
			if( schedules.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return;
			}

			foreach( Schedule schedule in schedules ) {
				if( !( address is null ) ) {
					schedule.Address = address;
				}
				schedule.Latitude = latitude;
				schedule.Longitude = longitude;
			}

			this.model.SaveChanges();

			this.logger.LogTrace( "End" );
		}

	}

}