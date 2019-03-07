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
			}

			// 宿泊中の施設を取得
			List<Hotel> hotels = await this.model.Hotels
				.Where( h =>
					h.EventSeq == eventSeq &&
					h.CheckIn <= DateTime.Now && DateTime.Now <= h.CheckOut
				)
				.ToListAsync();

			this.logger.LogTrace( $"Hotels Count is {hotels.Count}" );
			if( hotels.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return null;
			}
			int hotelSeq = hotels[ 0 ].Seq;

			// 宿泊する部屋を取得
			List<RoomMember> roomMembers = await this.model.RoomMembers
				.Where( rm =>
					rm.EventSeq == eventSeq &&
					rm.UserSeq == userSeq
				)
				.ToListAsync();

			this.logger.LogTrace( $"My Rooms Count is {roomMembers.Count}" );
			if( roomMembers.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return null;
			}

			// 宿泊中の施設の部屋情報のみを取得
			List<Room> rooms = await this.model.Rooms
				.Where( r =>
					r.EventSeq == eventSeq &&
					r.HotelSeq == hotelSeq &&
					roomMembers.Any( rm => rm.RoomSeq == r.Seq )
				)
				.ToListAsync();

			this.logger.LogTrace( $"Rooms Count is {rooms.Count}" );
			if( rooms.Count == 0 ) {
				this.logger.LogTrace( "End" );
				return null;
			}

			return rooms[0];
		}

		/// <summary>
		/// 指定した部屋番号のメンバーを取得する
		/// </summary>
		/// <param name="roomSeq">部屋管理番号</param>
		/// <returns>指定した部屋番号のメンバー一覧</returns>
		public List<RoomMember> GetRoomMembers( int roomSeq ) => null;

		/// <summary>
		/// 鍵を持っているメンバーを更新する
		/// </summary>
		/// <param name="roomNumber">部屋番号</param>
		/// <param name="userSeq">鍵を持っているユーザシーケンス</param>
		public void UpdateHavingKeyUser( string roomNumber , int userSeq ) {

		}

	}

}
