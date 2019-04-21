using System.Collections.Generic;
using System.Threading.Tasks;
using static ShioriChan.Controllers.RollCalls.RollCallsController;

namespace ShioriChan.Repositories.RollCalls {

	/// <summary>
	/// 点呼Repository
	/// </summary>
	public interface IRollCallRepository {

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		Task<List<Status>> GetStatuses();

	}

}
