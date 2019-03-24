using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Participants {

	/// <summary>
	/// 参加者Service
	/// </summary>
	public interface IParticipantService {

		/// <summary>
		/// 参加者を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Show( JToken parameter );

	}

}
