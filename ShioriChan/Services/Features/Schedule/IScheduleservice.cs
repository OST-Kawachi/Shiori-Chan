using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Schedule {

	/// <summary>
	/// 部屋情報
	/// </summary>
	public interface IScheduleService {

		/// <summary>
		/// 通知する
		/// </summary>
		Task Notice();

		/// <summary>
		/// 表示する日付を選ぶ
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task ChooseDate( JToken parameter );

		/// <summary>
		/// 表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Show( JToken parameter );

		/// <summary>
		/// 変更するスケジュールを選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task SelectToChange( JToken parameter );

		/// <summary>
		/// スケジュールを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Update( JToken parameter );

	}

}