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
		)
		{
			this.logger = logger;
			this.messageService = messageService;
			this.notificationRepository = notificationRepository;
		}

		/// <summary>
		/// 登録する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Register( JToken parameter ) => throw new System.NotImplementedException();

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
