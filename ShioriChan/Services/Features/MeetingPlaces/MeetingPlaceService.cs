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
			this.logger.LogDebug( $"User Id is {userId}." );

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
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

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
			this.logger.LogDebug( $"Postback Data is {data}." );
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

			this.logger.LogDebug( $"Title is { title ?? "None" }" );
			this.logger.LogDebug( $"Address is { address ?? "None" }" );
			this.logger.LogDebug( $"Latitude is {latitude}" );
			this.logger.LogDebug( $"Longitude is {longitude}" );

			return (title, address, latitude, longitude);
		}

		/// <summary>
		/// 集合場所の登録
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public void Register( JToken parameter )
		{
			this.logger.LogInformation("Start");
			string userId = this.GetUserId( parameter );
			this.logger.LogDebug($"User Id is {userId}");

			if( !this.meetingPlaceRepository.IsAdmin( userId ))
			{
				this.logger.LogWarning("User is not Admin.");
				return;
			}

			(string title, string address, double latitude, double longitude)
				= this.GetLocation( parameter );
			this.logger.LogDebug($"Title is {title}");
			this.logger.LogDebug($"Address is {address}");
			this.logger.LogDebug($"Latitude is {latitude}");
			this.logger.LogDebug($"Longitude is {longitude}");

			this.meetingPlaceRepository.Register( userId , title , address , latitude , longitude );
			this.logger.LogInformation("End");
			return;
		}

		/// <summary>
		/// 集合場所の表示
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Show( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

			(string title, string address, double? latitude, double? longitude) = this.meetingPlaceRepository.GetLocation();

			if( string.IsNullOrEmpty( title ) ||
				string.IsNullOrEmpty( address ) ||
				!latitude.HasValue ||
				!longitude.HasValue ) {

				this.logger.LogWarning( "Title, Adress, Latitude or Longitude is Null or Empty" );
				return;
			}

			this.logger.LogTrace( $"Message Title is { title}" );
			this.logger.LogTrace( $"Message Adress is {address}" );
			this.logger.LogTrace( $"Message Latitude is {latitude.Value}" );
			this.logger.LogTrace( $"Message Longitude is {longitude.Value}" );

			if( latitude.HasValue && longitude.HasValue ) {
				string message = "次の集合場所は↓↓↓です！\n";
				await this.messageService
						.CreateMessageBuilder()
						.AddMessage( message )
						.AddLocation( title , address , latitude.Value , longitude.Value )
						.BuildMessage()
						.Reply( replyToken );
			}
			
			this.logger.LogInformation( "End" );
			return;
		}

	}

}
