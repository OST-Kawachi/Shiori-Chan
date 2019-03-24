using Microsoft.Extensions.Logging;

namespace ShioriChan.Repositories.Notifications {

	/// <summary>
	/// 通知Repository
	/// </summary>
	public class NotificationRepository : INotificationRepository {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// データモデル
		/// </summary>
		private readonly ModelCreator model;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="model">データモデル</param>
		public NotificationRepository(
			ILogger<NotificationRepository> logger ,
			ModelCreator model
		)
		{
			this.logger = logger;
			this.model = model;
		}

	}

}
