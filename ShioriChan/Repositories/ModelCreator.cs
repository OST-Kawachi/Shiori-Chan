using Microsoft.EntityFrameworkCore;
using ShioriChan.Entities;

namespace ShioriChan.Repositories {

	/// <summary>
	/// DbContextよりDB接続を行う
	/// </summary>
	public class ModelCreator : DbContext {

		/// <summary>
		/// アクセストークン
		/// </summary>
		public DbSet<AccessToken> AccessTokens { set; get; }

		/// <summary>
		/// イベント
		/// </summary>
		public DbSet<Event> Events { set; get; }

		/// <summary>
		/// 宿泊施設
		/// </summary>
		public DbSet<Hotel> Hotels { set; get; }

		/// <summary>
		/// 参加者
		/// </summary>
		public DbSet<Participant> Participants { set; get; }

		/// <summary>
		/// 権限
		/// </summary>
		public DbSet<Permission> Permissions { set; get; }

		/// <summary>
		/// プッシュ通知
		/// </summary>
		public DbSet<PushNotification> PushNotifications { set; get; }

		/// <summary>
		/// 部屋情報
		/// </summary>
		public DbSet<Room> Rooms { set; get; }

		/// <summary>
		/// 部屋メンバー
		/// </summary>
		public DbSet<RoomMember> RoomMembers { set; get; }

		/// <summary>
		/// スケジュール
		/// </summary>
		public DbSet<Schedule> Schedules { set; get; }

		/// <summary>
		/// ユーザ
		/// </summary>
		public DbSet<UserInfo> UserInfos { set; get; }

		/// <summary>
		/// ユーザ権限
		/// </summary>
		public DbSet<UserPermission> UserPermissions { set; get; }

		/// <summary>
		/// 承認待ちユーザ
		/// </summary>
		public DbSet<WaitedApprovalUser> WaitedApprovalUsers { set; get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ModelCreator( DbContextOptions<ModelCreator> options ) : base( options ) { }

		/// <summary>
		/// モデル作成
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating( ModelBuilder modelBuilder ) {
			modelBuilder.Entity<AccessToken>().ToTable( "AccessToken" );
			modelBuilder.Entity<Event>().ToTable( "Event" );
			modelBuilder.Entity<Hotel>().ToTable( "Hotel" );
			modelBuilder.Entity<Participant>().HasKey( participant => new { participant.EventSeq , participant.UserSeq } );
			modelBuilder.Entity<Permission>().ToTable( "Permission" );
			modelBuilder.Entity<PushNotification>().ToTable( "PushNotification" );
			modelBuilder.Entity<Room>().ToTable( "Room" );
			modelBuilder.Entity<RoomMember>().HasKey( roomMember => new { roomMember.RoomSeq , roomMember.EventSeq , roomMember.UserSeq } );
			modelBuilder.Entity<Schedule>().HasKey( schedule => new { schedule.Seq , schedule.Name } );
			modelBuilder.Entity<UserInfo>().ToTable( "UserInfo" );
			modelBuilder.Entity<UserPermission>().HasKey( userPermission => new { userPermission.UserSeq , userPermission.EventSeq , userPermission.PermissionSeq } );
			modelBuilder.Entity<WaitedApprovalUser>().ToTable( "WaitedApprovalUser" );
		}

	}

}
