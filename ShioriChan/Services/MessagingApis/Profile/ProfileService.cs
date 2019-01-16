using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Profile {

	/// <summary>
	/// プロフィール用クラス
	/// </summary>
	public class ProfileService : IProfileService {

		/// <summary>
		/// プロフィールの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="userId">ユーザID</param>
		[Obsolete( "未完成です" , true )]
		public async Task<Profile> Get( string channelAccessToken , string userId ) {

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" ,	"Bearer " + channelAccessToken );
			
			try {
				HttpResponseMessage response = await client.GetAsync( "https://api.line.me/v2/bot/profile/" + userId ).ConfigureAwait( false );
				string result = await response?.Content.ReadAsStringAsync();
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException ) {
				client.Dispose();
				return null;
			}
			catch( HttpRequestException ) {
				client.Dispose();
				return null;
			}
			catch( Exception ) {
				client.Dispose();
				return null;
			}

			return new Profile( "a" , "b" , "c" , "d" );

		}

	}

}
