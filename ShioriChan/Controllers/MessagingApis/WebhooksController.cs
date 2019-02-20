using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.Features;
using System.IO;
using System.Threading.Tasks;

namespace ShioriChan.Controllers.MessagingApis {

	/// <summary>
	/// LINE BotからWebhookで送信されるApiの受け口用Controller
	/// </summary>
	[Route( "shiori-chan" )]
	[ApiController]
	public class WebhooksController : ControllerBase {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// Webhookで送られてくるMessagingApiのパラメータから判断して
		/// 何のイベントを実行するかを決める窓口
		/// </summary>
		private readonly IFeatureFacade featureFacade;

		/// <summary>
		/// コンストラクタ
		/// 依存性が挿入されたServiceクラスを取得する
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="featureFacade">何のイベントを実行するかを決める窓口</param>
		public WebhooksController( ILogger<WebhooksController> logger , IFeatureFacade featureFacade ) {
			this.logger = logger;
			this.featureFacade = featureFacade;
		}
		
		/// <summary>
		/// Webhookの受け口
		/// </summary>
		/// <returns>必ずステータス200を返す</returns>
		[Route("api")]
		[HttpPost]
		public async Task<StatusCodeResult> Post() {
			this.logger.LogTrace( "Start" );

			// TODO リクエストボディをJTokenの形で受け取れれば必要ない変換処理
			string request = null;
			{
				using( StreamReader streamReader = new StreamReader( this.Request.Body ) ) {
					request = streamReader.ReadToEnd();
				}
				this.logger.LogInformation( "Request is {request}." , request );
			}

			await this.featureFacade.Execute( JToken.Parse( request ) );

			this.logger.LogTrace( "End" );
			return this.Ok();
		}

	}

}
