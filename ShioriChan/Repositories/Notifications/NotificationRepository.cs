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

		/// <summary>
		/// メッセージを登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <param name="Text">リプライメッセージ</param>
		void Register(string userId, string text){
				this.logger.LogTrace( "Start" );
				this.logger.LogTrace( $"userId is {userId}. " );
			    this.logger.LogTrace( $"text is {text}." );

			　　this.model.PushNotifications.Add(new PushNotification(){
		            //ｄｓ
					Seq = this.model.PushNotifications.Max( at => at.Seq ) + 1 ,
					UserSeq = ,
					Status = 0,
					Text = text,
					RegisterUserSeq = 0,
					RegisterDatetime =  DateTime.Now,
					UpdateUserSeq =0 ,
					UpdateDatetime =  DateTime.Now,
					Version = 0
				});
				
			
			this.model.SaveChanges();
		}


	}

}
