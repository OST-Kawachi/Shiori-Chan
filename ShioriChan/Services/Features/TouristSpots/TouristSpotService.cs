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
            string replyToken = this.GetReplyToken(parameter);

            await this.messageService.CreateMessageBuilder()
            .AddTemplate("観光地情報の表示")
            .UseCarouselTemplateMessageBuilder()
            .AddColumn("天満宮内の隠れたこだわりの茶屋。目の前の菖蒲池を眺めながらごゆっくりとおくつろぎ頂けるお食事処です！")
            .SetTitle("うぐいす茶屋(1日目昼食)")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("かわいらしいガラスの工芸品を扱う雑貨店。ネックレスやストラップ、グラスや置物などオリジナル商品が豊富です！")
            .SetTitle("びいどろ太宰府店")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("太宰府天満宮参道沿いの3つ目の鳥居前にある、１階にジェラートのお店VITOと京雑貨のお店スーベニールの2階にあるお店です！")
            .SetTitle("MATCH屋　WAOWAO")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("菅原道真公の御墓所の上にご社殿を造営し、その御神霊を永久にお祀りしている神社です！")
            .SetTitle("太宰府天満宮")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("古くからアジアとの結びつきが強い九州ならではの展示で国宝や重要文化財などを鑑賞できます！")
            .SetTitle("九州国立博物館")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("「縁結び」「方除け」「厄除」の神様として信仰されている玉依姫命をお祀りしています！")
            .SetTitle("竈門神社")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("柳川藩主立花家の邸宅です！")
            .SetTitle("柳川藩主立花邸　御花")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .AddColumn("博多の食文化として定着した辛子明太子！そんな辛子明太子づくりを体験できます！")
            .SetTitle("はねや総本家")
            .AddAction()
            .UseMessageColumnAction("すごい！", "すごい！")
            .BuildColumnAction()
            .BuildTemplate()
            .BuildMessage()
            .Reply(replyToken);
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
            this.logger.LogTrace($"Reply Token is {replyToken}.");

            return replyToken;
        }
    }
}
