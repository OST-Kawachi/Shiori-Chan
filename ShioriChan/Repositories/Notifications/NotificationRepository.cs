using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShioriChan.Entities;

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
		public void Register(string userId, string text){
				this.logger.LogTrace( "Start" );
				this.logger.LogTrace( $"userId is {userId}. " );
			    this.logger.LogTrace( $"text is {text}." );

			int userSeq = this.model.UserInfos.SingleOrDefault( u => u.Id.Equals( userId ) )?.Seq ?? -1;
			int seq = this.model.PushNotifications.Count() == 0 ?
				1 :
				this.model.PushNotifications.Max( pn => pn.Seq ) + 1;

			this.logger.LogTrace( $"Seq is {seq}." );

			PushNotification pushNotification = new PushNotification() {
				Seq = seq ,
				UserSeq = userSeq ,
				Status = 0 ,
				Text = text ,
				RegisterUserSeq = userSeq ,
				RegisterDatetime = DateTime.Now ,
				UpdateUserSeq = userSeq ,
				UpdateDatetime = DateTime.Now ,
				Version = 0

			};

			this.model.PushNotifications.Add( pushNotification );
				
			this.model.SaveChanges();
			this.logger.LogTrace( "End" );
		}

	}

}
