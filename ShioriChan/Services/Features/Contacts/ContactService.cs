using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Contacts {

	/// <summary>
	/// 連絡先Service
	/// </summary>
	public class ContactService : IContactService {

		/// <summary>
		/// 連絡先を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new System.NotImplementedException();

	}

}
