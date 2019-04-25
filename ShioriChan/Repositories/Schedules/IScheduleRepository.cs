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
        /// <param name="eventSeq">通知したスケジュールのイベント管理番号</param>
        void UpdateNotified(int eventSeq);
    }
}
