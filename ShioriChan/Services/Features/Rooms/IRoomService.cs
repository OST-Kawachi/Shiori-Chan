using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ShioriChan.Services.Features.Rooms {

	/// <summary>
	/// 部屋情報
	/// </summary>
	public interface IRoomService {

		/// <summary>
		/// 同じ部屋のメンバーを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ShowRoomMember( JToken parameter );

		/// <summary>
		/// 鍵を持っているメンバーを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ChangeHavingKeyUser( JToken parameter );

	}

}
