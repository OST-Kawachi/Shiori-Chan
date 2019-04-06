using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;

namespace ShioriChan.Services.Features.Users
{

	/// <summary>
	/// ユーザService
	/// </summary>
	public interface IUserService
	{

		/// <summary>
		/// メニューを表示する
		/// 登録されていなければURLを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ShowMenuAndUrlIfNotRegistered( JToken parameter );

		/// <summary>
		/// 申請する
		/// </summary>
		/// <param name="seq">管理番号</param>
		/// <param name="name">ユーザ名</param>
		void Apply( int seq , string name );

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
		/// 承認する
		/// </summary>
		Task Approval( int unRegisteredUserSeq , int waitingApprovalUserSeq );

		/// <summary>
		/// ランダムに名前を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ShowRandomly( JToken parameter );

	}

}
