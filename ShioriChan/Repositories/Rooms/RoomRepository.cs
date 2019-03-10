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
		) {
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 部屋番号取得
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>部屋情報</returns>
		public async Task<Room> GetMyRoom( string userId ) {
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"User Id is {userId}." );
			
			// ユーザIDはLINEアカウント単位で一意なのでリストで取得するが要素数は0または1
			List<UserInfo> user = await this.model.UserInfos
				.Where( u => u.Id.Equals( userId ) )
				.ToListAsync();

			this.logger.LogTrace( $"Users Count is {user.Count}" );
			if( user.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return null;
			}

			int userSeq = user[ 0 ].Seq;
			int eventSeq = user[ 0 ].ParticipatingEventSeq ?? -1;
			this.logger.LogTrace( $"User Seq is {userSeq}" );
			this.logger.LogTrace( $"Event Seq is {eventSeq}" );
			if( eventSeq == -1 ) {
				this.logger.LogTrace( "End" );
				return null;
			}

			// 宿泊中の施設の部屋情報のみを取得
			List<Room> rooms = await this.model.Rooms
				.Where( r =>
					this.model.Hotels
						.Where( h =>
							h.EventSeq == eventSeq &&
							h.CheckIn <= DateTime.Now && DateTime.Now <= h.CheckOut
						)
						.Any( h => h.Seq == r.HotelSeq )
					&&
					this.model.RoomMembers
						.Where( rm => rm.UserSeq == userSeq )
						.Any( rm => rm.RoomSeq == r.Seq )
				)
				.ToListAsync();

			this.logger.LogTrace( $"Rooms Count is {rooms.Count}" );
			if( rooms.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return null;
			}

			this.logger.LogTrace( "Start" );
			return rooms[0];
		}

		/// <summary>
		/// 指定した部屋番号のメンバーを取得する
		/// </summary>
		/// <param name="roomSeq">部屋管理番号</param>
		/// <returns>指定した部屋番号のメンバー一覧と鍵を持っているユーザの管理番号</returns>
		public async Task<(List<UserInfo>,int?)> GetRoomMembers( int roomSeq ) {
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"Room Seq is {roomSeq}." );

			// 鍵を持っているユーザの管理番号を取得
			List<Room> rooms = await this.model.Rooms
				.Where( r => r.Seq == roomSeq )
				.ToListAsync();
			this.logger.LogTrace( $"Rooms Count is {rooms.Count}." );
			if( rooms.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return (null,null);
			}
			int? havingKeyUserSeq = rooms[ 0 ].HavingKeyUserSeq;
			this.logger.LogTrace( $"Having Key User Seq is {havingKeyUserSeq?.ToString() ?? "None"}" );

			// メンバーのユーザ情報を取得する
			List<RoomMember> roomMembers = await this.model.RoomMembers
				.Where( rm => rm.RoomSeq == roomSeq )
				.ToListAsync();
			this.logger.LogTrace( $"Room Members Count is {roomMembers.Count}" );
			if( roomMembers.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return (null,null);
			}
			roomMembers.ForEach( rm => this.logger.LogTrace( $"Room Member Uesr Seq is {rm.UserSeq}" ) );
			List<UserInfo> userInfos = await this.model.UserInfos
				.Where( ui => roomMembers.Any( rm => rm.UserSeq == ui.Seq ) )
				.ToListAsync();
			this.logger.LogTrace( $"User Infos Count is {userInfos.Count}" );
			if( userInfos.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return (null, null);
			}

			this.logger.LogTrace( "End" );
			return (userInfos, havingKeyUserSeq);
		}

		/// <summary>
		/// 鍵を持っているメンバーを更新する
		/// </summary>
		/// <param name="roomNumber">部屋管理番号</param>
		/// <param name="userSeq">鍵を持っているユーザ管理番号</param>
		public void UpdateHavingKeyUser( int roomSeq , int? userSeq ) {
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"Room Seq is {roomSeq}." );
			this.logger.LogTrace( $"UserSeq is {userSeq}." );

			Room room = this.model.Rooms.Single( r => r.Seq == roomSeq );
			room.HavingKeyUserSeq = userSeq;

			this.model.SaveChanges();

			this.logger.LogTrace( "End" );
		}

	}

}
