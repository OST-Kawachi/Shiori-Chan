using System;
using System.Collections.Generic;
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

		/// <summary>
		/// 通知メッセージ取得
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>通知メッセージ</returns>
		public string GetMessage( string userId ) {
			this.logger.LogTrace( "Start" );
			this.logger.LogTrace( $"User Id is {userId}" );

			int userSeq = this.model.UserInfos
				.SingleOrDefault( u => userId.Equals( u.Id ) )?
				.Seq ?? -1;

			this.logger.LogTrace( $"User Seq is {userSeq}" );

			if( userSeq == -1 ) {
				this.logger.LogWarning( "User Seq is Undefined" );
				return null;
			}

			PushNotification pushNotification = this.model.PushNotifications
				.Where( pn => pn.UserSeq == userSeq && pn.Status == 0 )
				.OrderByDescending( pn => pn.Seq )
				.First();

			this.logger.LogTrace( $"Message is {pushNotification.Text}" );
			this.logger.LogTrace( "End" );
			return pushNotification.Text;
		}

		/// <summary>
		/// ユーザID一覧を取得
		/// </summary>
		/// <returns>ユーザID一覧</returns>
		public List<string> GetUserIds() {
			this.logger.LogTrace( "Start" );
			List<string> userIds = this.model.UserInfos
				.Where( u => !string.IsNullOrEmpty( u.Id ) )
				.Select( u => u.Id )
				.ToList();

			this.logger.LogTrace( "End" );
			return userIds;
		}

		/// <summary>
		/// 指定のユーザのステータスを通知済みに変更する
		/// </summary>
		/// <param name="userId">ユーザId</param>
		public void UpdateUserStatus( string userId ) {
			this.logger.LogTrace( "Start" );

			int userSeq = this.model.UserInfos
				.SingleOrDefault( u => userId.Equals( u.Id ) )?
				.Seq ?? -1;

			this.logger.LogTrace( $"User Seq is {userSeq}" );

			if( userSeq == -1 ) {
				this.logger.LogWarning( "User Seq is Undefined" );
				return;
			}

			this.model.PushNotifications
				.Where( pn => pn.UserSeq == userSeq )
				.ToList()
				.ForEach( pn => pn.Status = 1 );

			this.model.SaveChanges();
			this.logger.LogTrace( "End" );
		}

	}

}
