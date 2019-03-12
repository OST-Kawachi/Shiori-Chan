using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.MeetingPlaces {

	/// <summary>
	/// 集合場所Service
	/// </summary>
	public interface IMeetingPlaceService {

		/// <summary>
		/// 集合場所の登録
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		void Register( JToken parameter );

		/// <summary>
		/// 集合場所の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Show( JToken parameter );

	}

}
