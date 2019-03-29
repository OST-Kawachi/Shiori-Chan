using Microsoft.Extensions.Logging;
using ShioriChan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShioriChan.Repositories.Users {

	/// <summary>
	/// ユーザRepository
	/// </summary>
	public class UserRepository : IUserRepository {

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
			int maxSeq = this.model.UserInfos.Select( user => user.Seq ).Max();
			this.logger.LogTrace( $"Max User Seq is {maxSeq}" );
			this.model.UserInfos.Add( new UserInfo() {
				Seq = maxSeq + 1 ,
				Id = userId ,
				Name = "" ,
				RegisterUserSeq = maxSeq + 1 ,
				RegisterDatetime = DateTime.Now ,
				UpdateUserSeq = maxSeq + 1 ,
				UpdateDatetime = DateTime.Now ,
				Version = 0
			} );
			this.model.SaveChanges();
			return -1;
		}

	}

}
