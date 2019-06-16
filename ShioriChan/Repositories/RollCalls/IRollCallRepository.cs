using System.Collections.Generic;
using static ShioriChan.Controllers.RollCalls.RollCallsController;

namespace ShioriChan.Repositories.RollCalls {

	/// <summary>
	/// 点呼Repository
	/// </summary>
	public interface IRollCallRepository {

		/// <summary>
		/// 点呼に返事をする
		/// </summary>
		/// <param name="userId">ユーザID</param>
		void TellIAmThere( string userId );

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		List<Status> GetStatuses();

		/// <summary>
		/// 点呼リセット
		/// </summary>
		void Reset();

		/// <summary>
		/// 参加者Id一覧取得
		/// </summary>
		/// <returns>参加者Id一覧</returns>
		List<string> GetParticipantIds();

	}

}
