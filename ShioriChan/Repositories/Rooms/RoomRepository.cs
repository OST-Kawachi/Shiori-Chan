using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShioriChan.Entities;

namespace ShioriChan.Repositories.Rooms {

	/// <summary>
	/// 部屋情報Repository
	/// </summary>
	public class RoomRepository : IRoomRepository {

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
		public RoomRepository(
			ILogger<RoomRepository> logger ,
			ModelCreator model
		)
		{
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 部屋番号取得
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>部屋情報</returns>
		public Room GetMyRoom( string userId )
		{
			this.logger.LogInformation( "Start" );
			this.logger.LogDebug( $"User Id is {userId}." );

			// ユーザIDはLINEアカウント単位で一意なのでリストで取得するが要素数は0または1
			UserInfo user = this.model.UserInfos
				.SingleOrDefault(u => u.Id.Equals(userId));

			if( user is null ) {
				this.logger.LogWarning( "User is NULL" );
				return null;
			}

			int userSeq = user.Seq;
			int eventSeq = user.ParticipatingEventSeq ?? -1;
			this.logger.LogDebug( $"User Seq is {userSeq}" );
			this.logger.LogDebug( $"Event Seq is {eventSeq}" );
			if( eventSeq == -1 ) {
				this.logger.LogWarning( "Participanting Event Seq is -1" );
				return null;
			}

			List<Hotel> hotels = this.model.Hotels
				.Where(h => 
					h.EventSeq == eventSeq &&
					h.CheckIn <= DateTime.Now && 
					DateTime.Now <= h.CheckOut
				)
				.ToList();

			List<RoomMember> roomMembers = this.model.RoomMembers
				.Where(rm => rm.UserSeq == userSeq)
				.ToList();

			// 宿泊中の施設の部屋情報のみを取得
			Room room = this.model.Rooms
				.SingleOrDefault(r =>
				  hotels.Any(h => h.Seq == r.HotelSeq) &&
				  roomMembers.Any(rm => rm.RoomSeq == r.Seq)
				);

			this.logger.LogInformation( "End" );
			return room;
		}

		/// <summary>
		/// 指定した部屋番号のメンバーを取得する
		/// </summary>
		/// <param name="roomSeq">部屋管理番号</param>
		/// <returns>指定した部屋番号のメンバー一覧と鍵を持っているユーザの管理番号</returns>
		public (List<UserInfo>, int?) GetRoomMembers( int roomSeq )
		{
			this.logger.LogInformation( "Start" );
			this.logger.LogDebug( $"Room Seq is {roomSeq}." );

			// 鍵を持っているユーザの管理番号を取得
			Room room = this.model.Rooms
				.SingleOrDefault(r => r.Seq == roomSeq);

			if( room is null ) {
				this.logger.LogWarning("Room is NULL");
				return (null, null);
			}

			int? havingKeyUserSeq = room.HavingKeyUserSeq;
			this.logger.LogDebug( $"Having Key User Seq is {havingKeyUserSeq?.ToString() ?? "None"}" );

			// メンバーのユーザ情報を取得する
			List<RoomMember> roomMembers = this.model.RoomMembers
				.Where( rm => rm.RoomSeq == roomSeq )
				.ToList();

			this.logger.LogDebug( $"Room Members Count is {roomMembers.Count}" );
			if( roomMembers.Count == 0 ) {
				this.logger.LogWarning("Room Members Count is 0");
				return (null, null);
			}
			roomMembers.ForEach( rm => this.logger.LogDebug( $"Room Member Uesr Seq is {rm.UserSeq}" ) );

			List<UserInfo> userInfos = this.model.UserInfos
				.Where( ui => roomMembers.Any( rm => rm.UserSeq == ui.Seq ) )
				.ToList();
			this.logger.LogDebug( $"User Infos Count is {userInfos.Count}" );
			if( userInfos.Count == 0 ) {
				this.logger.LogWarning("User Infos Count is 0");
				return (null, null);
			}

			this.logger.LogInformation( "End" );
			return (userInfos, havingKeyUserSeq);
		}

		/// <summary>
		/// 鍵を持っているメンバーを更新する
		/// </summary>
		/// <param name="roomNumber">部屋管理番号</param>
		/// <param name="userSeq">鍵を持っているユーザ管理番号</param>
		public void UpdateHavingKeyUser( int roomSeq , int? userSeq )
		{
			this.logger.LogInformation( "Start" );
			this.logger.LogDebug( $"Room Seq is {roomSeq}." );
			this.logger.LogDebug( $"UserSeq is {userSeq}." );

			Room room = this.model.Rooms.SingleOrDefault( r => r.Seq == roomSeq );
			if( room is null) {
				this.logger.LogWarning("Room is NULL");
				return;
			}
			room.HavingKeyUserSeq = userSeq;

			this.model.SaveChanges();

			this.logger.LogInformation( "End" );
		}

	}

}