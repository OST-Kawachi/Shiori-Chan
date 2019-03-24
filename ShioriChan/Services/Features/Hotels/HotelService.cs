using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Hotels {

	/// <summary>
	/// 宿泊施設Service
	/// </summary>
	public class HotelService : IHotelService {

		/// <summary>
		/// 宿泊施設を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new NotImplementedException();

	}

}
