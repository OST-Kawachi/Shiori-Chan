using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Hotels {

	/// <summary>
	/// 宿泊施設Service
	/// </summary>
	public interface IHotelService {

		/// <summary>
		/// 宿泊施設を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Show( JToken parameter );

	}

}
