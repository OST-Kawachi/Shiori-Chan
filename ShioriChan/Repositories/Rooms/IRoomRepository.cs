using ShioriChan.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShioriChan.Repositories.Rooms {

	/// <summary>
	/// 部屋情報Repository
	/// </summary>
	public interface IRoomRepository {

		/// <summary>
		/// 部屋番号取得
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>部屋情報</returns>
		Task<Room> GetMyRoom( string userId );

		/// <summary>
		/// 指定した部屋のメンバーを取得する
		/// </summary>
		/// <param name="roomSeq">部屋管理番号</param>
		/// <returns>指定した部屋番号のメンバー一覧と鍵を持っているユーザの管理番号</returns>
		Task<(List<UserInfo>, int?)> GetRoomMembers( int roomSeq );

		/// <summary>
		/// 鍵を持っているメンバーを更新する
		/// </summary>
		/// <param name="roomSeq">部屋管理番号</param>
		/// <param name="userSeq">鍵を持っているユーザ管理番号</param>
		void UpdateHavingKeyUser( int roomSeq , int? userSeq );
		
	}

}
