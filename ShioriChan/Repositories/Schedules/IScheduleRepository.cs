using System.Collections.Generic;
using ShioriChan.Entities;

namespace ShioriChan.Repositories.Schedules {

	/// <summary>
	/// スケジュールRepository
	/// </summary>
	public interface IScheduleRepository {

		/// <summary>
		/// スケジュール一覧を取得する
		/// </summary>
		/// <returns>スケジュール情報</returns>
		dynamic GetScheduleList();
	}

}
