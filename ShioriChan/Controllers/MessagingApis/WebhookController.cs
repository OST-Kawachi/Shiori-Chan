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
		/// 各機能の窓口
		/// </summary>
		private IFeatureFacade featureFacade = new FeatureFacade();

		/// <summary>
		/// テスト用Get
		/// </summary>
		/// <returns>必ずステータス200を返す</returns>
		[HttpGet]
		public StatusCodeResult Get() {
			this.featureFacade.Execute( JToken.Parse( "{ \"temp\t : \"temp\" }" ) );
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
