using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.TouristSpots {

	/// <summary>
	/// 観光地Service
	/// </summary>
	public interface ITouristSpotService {

		/// <summary>
		/// 観光地情報の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Show( JToken parameter );

	}

}
