namespace ShioriChan.Repositories.MeetingPlaces {

	/// <summary>
	/// 集合場所Repository
	/// </summary>
	public interface IMeetingPlaceRepository {

		/// <summary>
		/// 集合場所を登録する
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <param name="title">タイトル</param>
		/// <param name="address">住所</param>
		/// <param name="latitude">緯度</param>
		/// <param name="longitude">経度</param>
		void Register( string userId , string title , string address , double latitude , double longitude );

	}

}
