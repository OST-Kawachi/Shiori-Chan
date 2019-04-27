
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.Notifications;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Notifications {

	/// <summary>
	/// 通知Service
	/// </summary>
	public class NotificationService : INotificationService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// 通知Repository
		/// </summary>
		private readonly INotificationRepository notificationRepository;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="notificationRepository">通知rRepository</param>
		public NotificationService(
			ILogger<NotificationService> logger ,
			IMessageService messageService ,
			INotificationRepository notificationRepository
		) {
			this.logger = logger;
			this.messageService = messageService;
			this.notificationRepository = notificationRepository;
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
		/// ユーザIDを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ユーザID</returns>
		private string GetUserId( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken source = firstEvent[ "source" ];
			string userId = source[ "userId" ].ToString();
			this.logger.LogTrace( $"User Id is {userId}." );

			return userId;
		}

		/// <summary>
		/// メッセージを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>通知内容</returns>
		private string GetMessage( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken message = firstEvent[ "message" ];
			string text = message[ "text" ].ToString();
			this.logger.LogTrace( $"Text is {text}." );

			return text;
		}

		/// <summary>
		/// 登録する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Register( JToken parameter ) {
			this.logger.LogTrace( "Start" );
			string userId = this.GetUserId( parameter );
			string text = this.GetMessage( parameter );

			this.notificationRepository.Register( userId , text );
			this.logger.LogTrace( "End" );
		}

		/// <summary>
		/// 確認する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Confirm( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// プッシュ通知を送る
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Push( JToken parameter ) => throw new System.NotImplementedException();

	}

}
