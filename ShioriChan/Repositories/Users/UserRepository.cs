using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShioriChan.Repositories.Users
{

	/// <summary>
	/// ユーザRepository
	/// </summary>
	public class UserRepository : IUserRepository
	{

		/// <summary>
		/// ユーザ名で重複削除するためのEqualiy
		/// </summary>
		private class UserInfoComparer : IEqualityComparer<UserInfo>
		{
			public bool Equals(UserInfo x, UserInfo y) => !string.IsNullOrEmpty(x.Id) && x.Id.Equals(y.Id);

			public int GetHashCode(UserInfo obj) => throw new NotImplementedException();
		}

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
		/// <param name="logger">ログ</param>
		public UserRepository(
			ILogger<UserRepository> logger ,
			ModelCreator model
		)
		{
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 登録済みかどうか
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>登録済みかどうか</returns>
		public bool IsRegisterd( string userId )
		{
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"User Id is {userId}." );
			bool isRegistered = this.model.UserInfos.Any( user => userId.Equals( user.Id ) );
			this.logger.LogTrace( $"Is Registered ... {isRegistered}." );
			this.logger.LogTrace( "End" );
			return isRegistered;
		}

		/// <summary>
		/// ユーザIDのみ承認待ちテーブルに登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>承認待ちテーブル管理番号</returns>
		public int RegisterOnlyUserIdInWaitingApproval( string userId )
		{
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"User Id is {userId}." );
			int seq = this.model.WaitedApprovalUsers.OrderByDescending(user => user.Seq).Select( user => user.Seq ).First();
			this.logger.LogTrace( $"Max User Seq is {seq}" );
			this.model.WaitedApprovalUsers.Add( new WaitedApprovalUser()
			{
				Seq = seq + 1 ,
				UserId = userId ,
				UserName = "" ,
				RegisterUserSeq = seq + 1 ,
				RegisterDatetime = DateTime.Now ,
				UpdateUserSeq = seq + 1 ,
				UpdateDatetime = DateTime.Now ,
				Version = 0
			} );
			this.model.SaveChanges();
			return seq + 1;
		}

		/// <summary>
		/// ユーザIDを元に名前を登録するのみ承認待ちテーブルに登録する
		/// </summary>
		/// <param name="seq">管理番号</param>
		/// <param name="userName">ユーザ名</param>
		/// <returns>承認待ちテーブル管理番号</returns>
		public void RegisterWaitingApproval( int seq , string userName )
		{
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"Seq is {seq}. " );
			this.logger.LogTrace( $"User Name is {userName}." );

			WaitedApprovalUser user = this.model.WaitedApprovalUsers
				.SingleOrDefault( wau => wau.Seq == seq );

			if( user is null )
			{
				this.logger.LogWarning( "User is NULL." );
				return;
			}

			user.UserName = userName;
			this.model.SaveChanges();

		}

		/// <summary>
		/// プッシュ通知が送られてくる管理者メンバーを取得
		/// </summary>
		/// <returns>ユーザID</returns>
		public List<string> GetPushedAdminMembers()
		{
			this.logger.LogTrace( "Start" );
			IQueryable<int> pushablePermissionSeqs = this.model.Permissions
				.Where( p => "Pushable".Equals( p.Name ) )
				.Select( p => p.Seq );
			IQueryable<int> pushableUserSeq = this.model.UserPermissions
				.Where( pu => pu.EventSeq == 0 )
				.Where( pu =>
					pushablePermissionSeqs.Any( p => p == pu.PermissionSeq )
				)
				.Select( up => up.UserSeq );

			IQueryable<int> adminPermissionSeqs = this.model.Permissions
				.Where( p => "Admin".Equals( p.Name ) )
				.Select( p => p.Seq );
			IQueryable<int> adminUserSeq = this.model.UserPermissions
				.Where( pu => pu.EventSeq == 0 )
				.Where( pu =>
					adminPermissionSeqs.Any( p => p == pu.PermissionSeq )
				)
				.Select( up => up.UserSeq );

			List<string> userIds = this.model.UserInfos
				.Where( ui => pushableUserSeq.Any( seq => ui.Seq == seq ) )
				.Where( ui => adminUserSeq.Any( seq => ui.Seq == seq ) )
				.Where( ui => !string.IsNullOrEmpty( ui.Id ) )
				.Select( ui => ui.Id )
				.ToList();

			this.logger.LogTrace( $"User Ids Count is {userIds.Count}." );
			this.logger.LogTrace( "End" );
			return userIds;

		}

		/// <summary>
		/// 未登録ユーザ一覧取得
		/// </summary>
		/// <returns>未登録ユーザ一覧</returns>
		public List<UserInfo> GetUnregisteredUsers()
			=> this.model.UserInfos
				.Where( u => string.IsNullOrEmpty( u.Id ) )
				.ToList();

		/// <summary>
		/// 承認待ちユーザ一覧取得
		/// </summary>
		/// <returns>承認待ちユーザ一覧</returns>
		public List<WaitedApprovalUser> GetWaitingApprovalUsers()
		{
			List<WaitedApprovalUser> waitedApprovalUsers = this.model.WaitedApprovalUsers
				.Where(wau =>
				   !string.IsNullOrEmpty(wau.UserName)
				   &&
				   !string.IsNullOrEmpty(wau.UserId)
				)
				.OrderByDescending( wau => wau.Seq )
				.ToList();

			List<WaitedApprovalUser> ans = new List<WaitedApprovalUser>();
			waitedApprovalUsers.ForEach(wau =>
			{
				bool exist = false;
				ans.ForEach(a =>
				{
					if (a.UserId.Equals(wau.UserId))
					{
						exist = true;
					}
				});
				if (!exist)
				{
					ans.Add(wau);
				}
			}
			);
			return ans;
		}

		/// <summary>
		/// 承認済みユーザ一覧取得
		/// </summary>
		/// <returns>承認済みユーザ一覧</returns>
		public List<UserInfo> GetApprovedUsers() => this.model.UserInfos
			.Where(ui =>
				!string.IsNullOrEmpty(ui.Id)
			)
			.ToList();

		/// <summary>
		/// 承認
		/// </summary>
		/// <param name="unRegisteredUserSeq">ユーザ管理番号</param>
		/// <param name="waitingApprovalUserSeq">承認待ちユーザ管理番号</param>
		public void Approval( int unRegisteredUserSeq , int waitingApprovalUserSeq )
		{
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"Un Registered User Seq is {unRegisteredUserSeq}." );
			this.logger.LogTrace( $"Waiting Approval User Seq is {waitingApprovalUserSeq}." );

			UserInfo userInfo = this.model.UserInfos.SingleOrDefault( u => u.Seq == unRegisteredUserSeq );
			if( userInfo is null )
			{
				this.logger.LogWarning( "Un Registered User is NULL" );
				return;
			}

			WaitedApprovalUser waitedApprovalUser = this.model.WaitedApprovalUsers
				.SingleOrDefault( wau => wau.Seq == waitingApprovalUserSeq );
			if( waitedApprovalUser is null )
			{
				this.logger.LogWarning( "Waited Approval User is NULL." );
				return;
			}

			userInfo.Id = waitedApprovalUser.UserId;
			this.model.SaveChanges();

			this.logger.LogTrace( "End" );
		}

		/// <summary>
		/// ユーザ情報取得
		/// </summary>
		/// <param name="seq">管理番号</param>
		/// <returns>ユーザ情報</returns>
		public UserInfo GetUser( int seq )
			=> this.model.UserInfos.SingleOrDefault( u => u.Seq == seq );

        /// <summary>
		/// ランダム名前を取得
		/// </summary>
		/// <returns>ユーザ名</returns>
		public string GetRandomUserName()
        {
            string name = null;

            this.logger.LogTrace("Start");
            Random rand = new Random();
			UserInfo userInfo = this.model.UserInfos
				.OrderBy( _ => Guid.NewGuid() )
				.FirstOrDefault();
			this.logger.LogTrace( $"User Info is Null ... { userInfo is null}." );
			name = userInfo?.Name;
			this.logger.LogTrace( $"User Name is {name}" );
            
            this.logger.LogTrace("End");

            return name;
        }

        /// <summary>
		/// 全員のユーザIDを取得
		/// </summary>
		/// <returns>ユーザID</returns>
		public List<string> GetAllUserId()
        {
            this.logger.LogTrace("Start");
            List<string> userIds = this.model.UserInfos
               .Where(u => !string.IsNullOrEmpty(u.Id))
               .Select(u => u.Id)
               .ToList();

            this.logger.LogTrace("End");
            return userIds;
        }
    }

}
