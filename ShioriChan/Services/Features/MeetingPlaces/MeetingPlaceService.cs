using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.MeetingPlaces;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.MeetingPlaces {

	/// <summary>
	/// 集合場所Service
	/// </summary>
	public class MeetingPlaceService : IMeetingPlaceService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// メッセージ用Service
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// 集合場所Repository
		/// </summary>
		private readonly IMeetingPlaceRepository meetingPlaceRepository;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="meetingPlaceRepository">集合場所Repository</param>
		public MeetingPlaceService(
			ILogger<MeetingPlaceService> logger ,
			IMessageService messageService ,
			IMeetingPlaceRepository meetingPlaceRepository
		)
		{
			this.logger = logger;
			this.messageService = messageService;
			this.meetingPlaceRepository = meetingPlaceRepository;
		}

		/// <summary>
		/// ユーザIDを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ユーザID</returns>
		private string GetUserId( JToken parameter )
		{
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken source = firstEvent[ "source" ];
			string userId = source[ "userId" ].ToString();
			this.logger.LogTrace( $"User Id is {userId}." );

			return userId;
		}

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter )
		{
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			string replyToken = firstEvent[ "replyToken" ].ToString();
			this.logger.LogTrace( $"Reply Token is {replyToken}." );

			return replyToken;
		}

		/// <summary>
		/// ポストバックデータを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ポストバックデータ</returns>
		private string GetPostbackData( JToken parameter )
		{
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken postback = firstEvent[ "postback" ];
			string data = postback[ "data" ].ToString();
			this.logger.LogTrace( $"Postback Data is {data}." );
			return data;
		}

		/// <summary>
		/// 位置情報を取得する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>タイトル、住所、緯度、経度</returns>
		private (
			string title,
			string address,
			double latitude,
			double longitude
		) GetLocation( JToken parameter )
		{
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken message = firstEvent[ "message" ];
			string title = message[ "title" ]?.ToString();
			string address = message[ "address" ]?.ToString();
			double latitude = double.Parse( message[ "latitude" ].ToString() );
			double longitude = double.Parse( message[ "longitude" ].ToString() );

			this.logger.LogTrace( $"Title is { title ?? "None" }" );
			this.logger.LogTrace( $"Address is { address ?? "None" }" );
			this.logger.LogTrace( $"Latitude is {latitude}" );
			this.logger.LogTrace( $"Longitude is {longitude}" );

			return (title, address, latitude, longitude);
		}

		/// <summary>
		/// 集合場所の登録
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Register( JToken parameter )
		{

			string userId = this.GetUserId( parameter );
			(string title, string address, double latitude, double longitude)
				= this.GetLocation( parameter );

			this.meetingPlaceRepository.Register( userId , title , address , latitude , longitude );
			return;
		}

		/// <summary>
		/// 集合場所の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Show( JToken parameter )
		{


			return;
		}

	}

}
