using ShioriChan.Entities;
using System.Collections.Generic;

namespace ShioriChan.Repositories.Schedules {

	/// <summary>
	/// スケジュールRepository
	/// </summary>
	public interface IScheduleRepository {

		/// <summary>
		/// 通知する予定の名称を取得
		/// </summary>
		/// <return>メッセージ</return>
		Schedule GetSchedule();

		/// <summary>
		/// 全員のユーザIDを取得
		/// </summary>
		/// <returns>ユーザID</returns>
		List<string> GetAllUserId();

		/// <summary>
		/// 通知済みであることを更新する
		/// </summary>
		/// <param name="eventSeq">通知したスケジュールの管理番号</param>
		void UpdateNotified( int scheduleSeq );

		/// <summary>
		/// スケジュール一覧を取得する
		/// </summary>
		/// <returns>スケジュール情報</returns>
		List<(int, string, string)> GetSchedulesForSelectToChange();

		/// <summary>
		/// スケジュール一覧を表示する
		/// </summary>
		/// <param name="isFirst">初日かどうか</param>
		/// <returns>スケジュール情報</returns>
		List<(string name, string startTime)> GetSchedules( bool isFirst );

		/// <summary>
		/// スケジュールを更新する
		/// </summary>
		/// <param name="seq">スケジュール管理番号</param>
		/// <param name="dateTime">日時</param>
		/// <returns>更新されたスケジュール</returns>
		Schedule UpdateSchedule( int seq , string dateTime );

	}

}
