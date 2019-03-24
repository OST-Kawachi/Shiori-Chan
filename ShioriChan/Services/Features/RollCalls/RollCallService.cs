using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.RollCalls {

	/// <summary>
	/// 点呼Service
	/// </summary>
	public class RollCallService : IRollCallService {

		/// <summary>
		/// 返事をする
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Reply( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// 受付を開始する
		/// </summary>
		public Task StartAcception() => throw new System.NotImplementedException();

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		public Task GetStatuses() => throw new System.NotImplementedException();

	}

}
