using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Menus {

	/// <summary>
	/// メニューService
	/// </summary>
	public class MenuService : IMenuService {

		/// <summary>
		/// メニューを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task ChangeMenu( JToken parameter )
			=> throw new System.NotImplementedException();

		/// <summary>
		/// メニュー画像を更新する
		/// </summary>
		public Task UpdateImage() => throw new System.NotImplementedException();

	}

}
