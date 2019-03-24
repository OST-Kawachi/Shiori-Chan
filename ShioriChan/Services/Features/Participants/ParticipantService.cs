using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Participants {

	/// <summary>
	/// 参加者Service
	/// </summary>
	public class ParticipantService : IParticipantService {

		/// <summary>
		/// 参加者一覧を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new System.NotImplementedException();

	}

}
