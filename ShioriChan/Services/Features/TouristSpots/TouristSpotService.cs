using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.TouristSpots {

	/// <summary>
	/// 観光地Service
	/// </summary>
	public class TouristSpotService : ITouristSpotService {

		/// <summary>
		/// 観光地情報を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new NotImplementedException();

	}

}
