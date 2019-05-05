using System.Collections.Generic;
using ShioriChan.Entities;

namespace ShioriChan.Repositories.Users
{

	/// <summary>
	/// ユーザRepository
	/// </summary>
	public interface IUserRepository
	{

		/// <summary>
		/// 登録済みかどうか
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>登録済みかどうか</returns>
		bool IsRegisterd( string userId );

		/// <summary>
		/// ユーザIDのみ承認待ちテーブルに登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>承認待ちテーブル管理番号</returns>
		int RegisterOnlyUserIdInWaitingApproval( string userId );

		/// <summary>
		/// ユーザIDを元に名前を登録するのみ承認待ちテーブルに登録する
		/// </summary>
		/// <param name="seq">管理番号</param>
		/// <param name="userName">ユーザ名</param>
		/// <returns>承認待ちテーブル管理番号</returns>
		void RegisterWaitingApproval( int seq , string userName );

		/// <summary>
		/// プッシュ通知が送られてくる管理者メンバーを取得
		/// </summary>
		/// <returns>ユーザID</returns>
		List<string> GetPushedAdminMembers();

		/// <summary>
		/// 未登録ユーザ一覧取得
		/// </summary>
		/// <returns>未登録ユーザ一覧</returns>
		List<UserInfo> GetUnregisteredUsers();

		/// <summary>
		/// 承認待ちユーザ一覧取得
		/// </summary>
		/// <returns>承認待ちユーザ一覧</returns>
		List<WaitedApprovalUser> GetWaitingApprovalUsers();

		/// <summary>
		/// 承認
		/// </summary>
		/// <param name="unRegisteredUserSeq">ユーザ管理番号</param>
		/// <param name="waitingApprovalUserSeq">承認待ちユーザ管理番号</param>
		void Approval( int unRegisteredUserSeq , int waitingApprovalUserSeq );

		/// <summary>
		/// ユーザ情報取得
		/// </summary>
		/// <param name="seq">管理番号</param>
		/// <returns>ユーザ情報</returns>
		UserInfo GetUser( int seq );

        /// <summary>
        /// ランダム名前を取得
        /// </summary>
        /// <returns>ユーザ名</returns>
        string GetRandomUserName();

        /// <summary>
        /// 全員のユーザIDを取得
        /// </summary>
        /// <returns>ユーザID</returns>
        List<string> GetAllUserId();
    }

}
