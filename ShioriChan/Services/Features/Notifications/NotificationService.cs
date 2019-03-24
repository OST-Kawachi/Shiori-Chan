using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Notifications {

	/// <summary>
	/// 通知Service
	/// </summary>
	public class NotificationService : INotificationService {

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
