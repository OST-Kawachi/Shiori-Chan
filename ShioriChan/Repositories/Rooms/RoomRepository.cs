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
	public class RoomRepository : DbContext, IRoomRepository {

		/// <summary>
		/// ログ
		/// </summary>
		private ILogger logger;

		/// <summary>
		/// 部屋情報
		/// </summary>
		private DbSet<Room> Rooms { set; get; }

		/// <summary>
		/// 部屋メンバー
		/// </summary>
		private DbSet<RoomMember> RoomMembers { set; get; }

		/// <summary>
		/// ユーザ情報
		/// </summary>
		private DbSet<UserInfo> UserInfos { set; get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RoomRepository(
			DbContextOptions<RoomRepository> options ,
			ILogger<RoomRepository> logger
		) : base( options )
			=> this.logger = logger;

		/// <summary>
		/// モデル作成
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating( ModelBuilder modelBuilder ) {
			modelBuilder.Entity<Room>().ToTable( "Room" );
			modelBuilder.Entity<RoomMember>().ToTable( "RoomMember" );
			modelBuilder.Entity<UserInfo>().ToTable( "UserInfo" );
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
			List<UserInfo> user = await this.UserInfos
				.Where( userInfo => userInfo.Id.Equals( userId ) )
				.ToListAsync().ConfigureAwait( false );

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
