using Microsoft.EntityFrameworkCore;
using ShioriChan.Models;

namespace ShioriChan.Repositories.Rooms {

	/// <summary>
	/// 部屋情報Repository
	/// </summary>
	public class RoomRepository : DbContext, IRoomRepository {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RoomRepository( DbContextOptions<RoomRepository> options ) : base( options ) {}

		public DbSet<Room> Rooms { set; get; }

		protected override void OnModelCreating( ModelBuilder modelBuilder ) => modelBuilder.Entity<Room>().ToTable( "Room" );

	}

}
