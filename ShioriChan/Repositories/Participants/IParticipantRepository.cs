using System.Collections.Generic;
using ShioriChan.Entities;

namespace ShioriChan.Repositories.Participants {

	/// <summary>
	/// 参加者Repository
	/// </summary>
	public interface IParticipantRepository {
	
	/// <summary>
		/// 参加者一覧取得
		/// </summary>
		/// <returns>参加者一覧</returns>
		List<UserInfo> GetParticipantNames();
	}

}
