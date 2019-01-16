using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.Features;

namespace ShioriChan.Controllers.MessagingApis {

	/// <summary>
	/// LINE BotからWebhookで送信されるApiの受け口用Controller
	/// </summary>
	[Route( "shiori-chan/api/" )]
	[ApiController]
	public class WebhookController : ControllerBase {

		/// <summary>
		/// Webhookで送られてくるMessagingApiのパラメータから判断して
		/// 何のイベントを実行するかを決める窓口
		/// </summary>
		private readonly IFeatureFacade featureFacade;

		/// <summary>
		/// コンストラクタ
		/// 依存性が挿入されたServiceクラスを取得する
		/// </summary>
		/// <param name="featureFacade">何のイベントを実行するかを決める窓口</param>
		public WebhookController( IFeatureFacade featureFacade )
			=> this.featureFacade = featureFacade;

		/// <summary>
		/// テスト用Get
		/// </summary>
		/// <returns>必ずステータス200を返す</returns>
		[HttpGet]
		public StatusCodeResult Get() {
			this.featureFacade.Execute( JToken.Parse( "{ \"temp\" : \"temp\" }" ) );
			return this.Ok();
		}

		/// <summary>
		/// Webhookの受け口
		/// </summary>
		/// <returns>必ずステータス200を返す</returns>
		[HttpPost]
		public StatusCodeResult Post() {
			this.featureFacade.Execute( JToken.Parse( "{ \"temp\t : \"temp\" }" ) );
			return this.Ok();
		}

	}

}
