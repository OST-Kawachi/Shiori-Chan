using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Menus {

	/// <summary>
	/// メニューService
	/// </summary>
	public class MenuService : IMenuService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		public MenuService(
			ILogger<MenuService> logger ,
			IMessageService messageService
		)
		{
			this.logger = logger;
			this.messageService = messageService;
		}

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
