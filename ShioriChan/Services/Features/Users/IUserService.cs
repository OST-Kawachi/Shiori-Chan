using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Users {

	/// <summary>
	/// ユーザService
	/// </summary>
	public interface IUserService {

		/// <summary>
		/// メニューを表示する
		/// 登録されていなければURLを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ShowMenuAndUrlIfNotRegistered( JToken parameter );

		/// <summary>
		/// 申請する
		/// </summary>
		Task Apply();

		/// <summary>
		/// 承認待ちユーザ一覧取得
		/// </summary>
		Task GetAwaitingApprovalUsers();

		/// <summary>
		/// 承認する
		/// </summary>
		Task Approval();

		/// <summary>
		/// ランダムに名前を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ShowRandomly( JToken parameter );

	}

}
