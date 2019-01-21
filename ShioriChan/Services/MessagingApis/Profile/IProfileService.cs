using System;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Profile {

	/// <summary>
	/// プロフィール用インタフェース
	/// </summary>
	public interface IProfileService {

		/// <summary>
		/// プロフィールの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		Task<Profile> Get( string channelAccessToken , string userId );

	}

}
