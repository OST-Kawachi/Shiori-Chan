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

			this.logger.LogTrace( "Seq Show Start" );
			try {
				DbSet<Room> rooms = this.model.Rooms;
				this.logger.LogTrace( "Rooms!" );
				List<Room> roomList = await rooms.ToListAsync();
				this.logger.LogTrace( "RoomList!" );
				this.logger.LogTrace( "Room List Count is " + roomList.Count );

				roomList.ForEach( room => this.logger.LogInformation( $"Seq is {room.Seq}" ) );
			}
			catch( Exception e ) {
				this.logger.LogError( "{e}" , e );
			}
			this.logger.LogTrace( "Seq Show End" );

			// ユーザIDはLINEアカウント単位で一意なのでリストで取得するが要素数は0または1
			List<UserInfo> user = await this.model.UserInfos
				.Where( userInfo => userInfo.Id.Equals( userId ) )
				.ToListAsync();

			this.logger.LogTrace( $"User Id Count is {user.Count()}" );
			if( user.Count() == 0 ) {
				this.logger.LogTrace( "End" );
				return null;
			}

			return null;
		}

		/// <summary>
		/// 指定した部屋番号のメンバーを取得する
		/// </summary>
		/// <param name="roomNumber">部屋番号</param>
		/// <returns>指定した部屋番号のメンバー一覧</returns>
		public List<RoomMember> GetRoomMembers( string roomNumber ) => null;

		/// <summary>
		/// 鍵を持っているメンバーを更新する
		/// </summary>
		/// <param name="roomNumber">部屋番号</param>
		/// <param name="userSeq">鍵を持っているユーザシーケンス</param>
		public void UpdateHavingKeyUser( string roomNumber , int userSeq ) {

		}

	}

}
