using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.TouristSpots {

	/// <summary>
	/// 観光地Service
	/// </summary>
	public class TouristSpotService : ITouristSpotService {

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
		public TouristSpotService(
			ILogger<TouristSpotService> logger ,
			IMessageService messageService
		)
		{
			this.logger = logger;
			this.messageService = messageService;
		}

        /// <summary>
        /// 観光地情報を表示する
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        public async Task Show(JToken parameter) {
			this.logger.LogInformation("Start");
            
			string replyToken = this.GetReplyToken(parameter);
			this.logger.LogDebug($"Reply Token is {replyToken}");

            await this.messageService.CreateMessageBuilder()
            .AddTemplate("観光地情報の表示")
            .UseCarouselTemplateMessageBuilder()
            .AddColumn("丁子屋では、自然薯を筆頭に、こだわりの原材料で名物「とろろ汁」を堪能できます！")
            .SetTitle("丁子屋")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("江戸時代から受け継がれた「絞染」、「型染」の手法を用いて染め物づくりを体験できます！")
            .SetTitle("駿府匠宿　藍染　白ハンカチ")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("丸めた生地を回転台の上で回したり引きのばしたりして作ります！受取は2か月後になります！")
            .SetTitle("駿府匠宿　陶芸　手ひねり")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .BuildTemplate()
            .BuildMessage()
            .Reply(replyToken);

			this.logger.LogInformation("End");
        }

        /// <summary>
        /// リプライトークンを取得
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>リプライトークン</returns>
        private string GetReplyToken(JToken parameter)
        {
            JArray events = (JArray)parameter["events"];
            JObject firstEvent = (JObject)events[0];

            string replyToken = firstEvent["replyToken"].ToString();
            this.logger.LogDebug($"Reply Token is {replyToken}.");

            return replyToken;
        }
    }
}
