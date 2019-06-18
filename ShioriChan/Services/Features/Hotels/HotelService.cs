using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Hotels {

	/// <summary>
	/// 宿泊施設Service
	/// </summary>
	public class HotelService : IHotelService {

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
		public HotelService(
			ILogger<HotelService> logger ,
			IMessageService messageService
		) {
			this.logger = logger;
			this.messageService = messageService;
		}

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			string replyToken = firstEvent[ "replyToken" ].ToString();
			this.logger.LogTrace( $"Reply Token is {replyToken}." );

			return replyToken;
		}

		/// <summary>
		/// 宿泊施設を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Show( JToken parameter ) {
			this.logger.LogTrace( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogTrace( $"Reply Token is {replyToken}." );
			string url = "https://www.hiltonfukuokaseahawk.jp/img/tops/index/hotel_slide/hotel_img_1.jpg";
			await this.messageService
				.CreateMessageBuilder()
				.AddMessage( "今回宿泊するホテルはこちら！" )
				.AddTemplate( "ホテル情報" )
				.UseButtonTemplate( "オシャレです～＞＜" )
				.SetImageAspectRatio( "rectangle" )
				.SetImageBackgroundColor( "#FFFFFF" )
				.SetImageSize( "cover" )
				.SetThumbnailImageUrl( url )
				.SetTitle( "ヒルトン福岡シーホーク" )
				.SetAction()
				.UseUriAction( "ホテルのサイトはこちら♪" , "https://www.hiltonfukuokaseahawk.jp/")
				.BuildTemplate()
				.BuildMessage()
				.Reply( replyToken );

			this.logger.LogTrace( "End" );
			return;
		}
	}

}
