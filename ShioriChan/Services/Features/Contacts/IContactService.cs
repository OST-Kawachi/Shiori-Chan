using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Contacts {

	/// <summary>
	/// 連絡先Service
	/// </summary>
	public interface IContactService {

		/// <summary>
		/// 連絡先を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Show( JToken parameter );

	}

}
