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
		/// <returns>指定した部屋番号のメンバー一覧</returns>
		List<RoomMember> GetRoomMembers( int roomSeq );

		/// <summary>
		/// 鍵を持っているメンバーを更新する
		/// </summary>
		/// <param name="roomNumber">部屋番号</param>
		/// <param name="userSeq">鍵を持っているユーザシーケンス</param>
		void UpdateHavingKeyUser( string roomNumber , int userSeq );
		
	}

}
