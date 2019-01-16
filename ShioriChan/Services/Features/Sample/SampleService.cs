using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Profile;
using ShioriChan.Services.MessagingApis.TalkRoom;

namespace ShioriChan.Services.Features.Sample {

	/// <summary>
	/// サンプル用クラス
	/// 最終的には削除する
	/// </summary>
	public class SampleService : ISampleService {

		/// <summary>
		/// トークルーム用Service
		/// </summary>
		private readonly ITalkRoomService talkRoomService;

		/// <summary>
		/// プロフィール用Service
		/// </summary>
		private readonly IProfileService profileService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="talkRoomService">トークルーム用Service</param>
		/// <param name="profileService">プロフィール用Service</param>
		public SampleService( ITalkRoomService talkRoomService , IProfileService profileService ) { 
			this.talkRoomService = talkRoomService;
			this.profileService = profileService;
		}

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public void Execute( JToken parameter ) {

			
			
		}

	}

}
