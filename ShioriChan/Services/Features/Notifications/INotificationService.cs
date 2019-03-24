using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Notifications {

	/// <summary>
	/// 通知Service
	/// </summary>
	public interface INotificationService {

		/// <summary>
		/// 登録する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Register( JToken parameter );

		/// <summary>
		/// 確認する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Confirm( JToken parameter );

		/// <summary>
		/// プッシュ通知を送る
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Push( JToken parameter );

	}

}
