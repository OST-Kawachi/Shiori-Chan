using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Schedule {

	/// <summary>
	/// スケジュールService
	/// </summary>
	public class Scheduleservice : IScheduleService {

		/// <summary>
		/// 通知する
		/// </summary>
		public Task Notice() => throw new System.NotImplementedException();

		/// <summary>
		/// 表示する日付を選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task ChooseDate( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// 表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// 変更するスケジュールを選択する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task SelectToChange( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// スケジュールを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Update( JToken parameter ) => throw new System.NotImplementedException();

	}

}
