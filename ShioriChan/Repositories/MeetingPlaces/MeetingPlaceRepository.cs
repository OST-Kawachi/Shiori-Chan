using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShioriChan.Repositories.MeetingPlaces {

	/// <summary>
	/// 集合場所Repository
	/// </summary>
	public class MeetingPlaceRepository : IMeetingPlaceRepository {

		private readonly long trillion = 1000000000000;

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
		/// 管理者かどうか
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>管理者かどうか</returns>
		public bool IsAdmin(string userId)
		{
			this.logger.LogTrace("Start");

			Permission permission = this.model.Permissions
				.FirstOrDefault(p => "Admin".Equals(p.Name));

			UserInfo userInfo = this.model.UserInfos
				.FirstOrDefault(u => userId.Equals(u.Id));

			UserPermission userPermission = this.model.UserPermissions
				.FirstOrDefault(up => permission.Seq == up.PermissionSeq && userInfo.Seq == up.UserSeq);

			this.logger.LogTrace("End");

			return !(userPermission is null);

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
				schedule.Latitude = (long)(latitude * this.trillion);
				schedule.Longitude = (long)(longitude * this.trillion);
			}

			this.model.SaveChanges();

			this.logger.LogTrace( "End" );
		}
		/// <summary>
		/// 集合場所の取得
		/// </summary>
		/// <param name="seq"></param>
		/// <returns></returns>
		public (string title, string address, double? latitude, double? longitude) GetLocation() {

			this.logger.LogTrace( "Repository Start" );
			int maxNum = this.model.Schedules
				.Where( s => s.EventSeq == 0)
				.Max( sc => sc.Seq );
			this.logger.LogTrace($"maxNum is {maxNum}");

			List<Schedule> schedule = this.model.Schedules
				.Where( s => s.Seq == maxNum)
				.ToList();
			this.logger.LogTrace( "There is a Schedule Data" );

			if( schedule.Count == 0 ) {
				this.logger.LogWarning("No Record");
				return (null,null,null,null);
			}

			string title = "ここです！！！";
			this.logger.LogTrace( $"title is {title}" );

			string address = schedule[ 0 ].Address;
			this.logger.LogTrace( $"address is {address}" );
			
			double? latitude = (double?)schedule[0].Latitude / this.trillion;
			this.logger.LogTrace( $"latitude is {latitude}" );

			double? longitude = (double?)schedule[0].Longitude / this.trillion;
			this.logger.LogTrace( $"longitude is {longitude}" );
			
			return (title, address, latitude, longitude);
		}

	}

}