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
            .AddColumn("天満宮内の隠れたこだわりの茶屋です！")
            .SetTitle("うぐいす茶屋(1日目昼食)")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "http://uguisu-chaya.com/")
            .BuildColumnAction()
            .AddColumn("かわいらしいガラスの工芸品を扱う雑貨店です！")
            .SetTitle("びいどろ太宰府店")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "http://www.folcart.com/shop_info/20110910000033_711.html")
            .BuildColumnAction()
            .AddColumn("太宰府天満宮参道沿いの3つ目の鳥居前にあるジェラートと京雑貨のお店です！")
            .SetTitle("MATCH屋　WAOWAO")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "http://dazaifu-navi.com/store_guide.php?shop_id=45")
            .BuildColumnAction()
            .AddColumn("菅原道真公の御墓所の上にご社殿を造営し、その御神霊を永久にお祀りしている神社です！")
            .SetTitle("太宰府天満宮")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "https://www.dazaifutenmangu.or.jp/")
            .BuildColumnAction()
            .AddColumn("古くからアジアとの結びつきが強い九州ならではの展示で国宝や重要文化財などを鑑賞できます！")
            .SetTitle("九州国立博物館")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "https://www.kyuhaku.jp/")
            .BuildColumnAction()
            .AddColumn("「縁結び」「方除け」「厄除」の神様として信仰されている玉依姫命をお祀りしています！")
            .SetTitle("竈門神社")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "https://kamadojinja.or.jp/")
            .BuildColumnAction()
            .AddColumn("柳川藩主立花家の邸宅です！")
            .SetTitle("柳川藩主立花邸　御花")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "http://www.ohana.co.jp/")
            .BuildColumnAction()
            .AddColumn("柳川の川下りは、お堀めぐりです。七曲り、七めぐりして下っていきます！")
            .SetTitle("柳川下り")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "http://kawakudari.com/couese")
            .BuildColumnAction()
            .AddColumn("うなぎの蒲焼きと、旨味の濃いタレを混ぜ込んだご飯を蒸篭で一緒に蒸し上げた逸品です！")
            .SetTitle("鰻せいろ蒸し(二日目昼食)")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "https://gurutabi.gnavi.co.jp/a/a_2175/")
            .BuildColumnAction()
            .AddColumn("博多の食文化として定着した辛子明太子づくりを体験できます！")
            .SetTitle("はねや総本家")
            .AddAction()
            .UseUriColumnAction("詳しくはこちら！", "http://hakatahaneya.com/")
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
