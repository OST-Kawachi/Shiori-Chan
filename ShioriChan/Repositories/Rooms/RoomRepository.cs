using Microsoft.EntityFrameworkCore;
using ShioriChan.Entities;

namespace ShioriChan.Repositories.Rooms {

	/// <summary>
	/// 部屋情報Repository
	/// </summary>
	public class RoomRepository : DbContext, IRoomRepository {

		/// <summary>
		/// 部屋情報
		/// </summary>
		public DbSet<Room> Rooms { set; get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RoomRepository( DbContextOptions<RoomRepository> options ) : base( options ) {}

		/// <summary>
		/// モデル作成
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating( ModelBuilder modelBuilder )
			=> modelBuilder.Entity<Room>().ToTable( "Room" );
		
	}

}
