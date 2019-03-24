using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Users {

	/// <summary>
	/// ユーザService
	/// </summary>
	public class UserService : IUserService {

		/// <summary>
		/// メニューを表示する
		/// 登録されていなければURLを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task ShowMenuAndUrlIfNotRegistered( JToken parameter )
			=> null;

		/// <summary>
		/// 申請する
		/// </summary>
		public Task Apply() => throw new System.NotImplementedException();

		/// <summary>
		/// 承認待ちユーザ一覧取得
		/// </summary>
		public Task GetAwaitingApprovalUsers() => throw new System.NotImplementedException();

		/// <summary>
		/// 承認する
		/// </summary>
		public Task Approval() => throw new System.NotImplementedException();

		/// <summary>
		/// ランダムに名前を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task ShowRandomly( JToken parameter ) => throw new System.NotImplementedException();

	}

}
