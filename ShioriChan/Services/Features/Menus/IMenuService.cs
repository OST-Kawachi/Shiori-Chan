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
		/// メニューを変更する
		/// </summary>
		/// <param name="replyToken">リプライトークン</param>
		/// <param name="userId">ユーザID</param>
		/// <param name="menuId">メニューID</param>
		Task ChangeMenu( string replyToken , string userId , string menuId );

		/// <summary>
		/// メニュー画像を更新する
		/// </summary>
		/// <returns></returns>
		Task UpdateImage();

		/// <summary>
		/// メニューとユーザをリンクさせる
		/// </summary>
		Task Link();

	}

}
