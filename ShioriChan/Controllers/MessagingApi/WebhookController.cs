using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ShioriChan.Controllers.MessagingApi {

	/// <summary>
	/// LINE BotからWebhookで送信されるApiの受け口用Controller
	/// </summary>
	[Route( "shiori-chan/api/" )]
	[ApiController]
	public class WebhookController : ControllerBase {

		[HttpGet]
		public ActionResult<IEnumerable<string>> Get() => new string[] { "value1" , "value2" };


		[HttpPost]
		public void Post( [FromBody] string value ) {
		}

	}

}
