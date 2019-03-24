using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Menus {

	/// <summary>
	/// メニューService
	/// </summary>
	public interface IMenuService {

		/// <summary>
		/// メニューを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ChangeMenu( JToken parameter );

		/// <summary>
		/// メニュー画像を更新する
		/// </summary>
		/// <returns></returns>
		Task UpdateImage();

	}

}
