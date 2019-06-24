using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static ShioriChan.Controllers.RollCalls.RollCallsController;

namespace ShioriChan.Services.Features.RollCalls {

	/// <summary>
	/// 点呼Service
	/// </summary>
	public interface IRollCallService {

		/// <summary>
		/// 返事をする
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		void Reply( JToken parameter );

		/// <summary>
		/// 受付を開始する
		/// </summary>
		Task Notify();

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		List<Status> GetStatuses();

	}

}
