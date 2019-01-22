using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.Profiles;
using ShioriChan.Services.MessagingApis.TalkRooms;
using System.Threading.Tasks;

namespace ShioriChan.Services.Features.Samples {

	/// <summary>
	/// サンプル用クラス
	/// 最終的には削除する
	/// </summary>
	public class SampleService : ISampleService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// トークルーム用Service
		/// </summary>
		private readonly ITalkRoomService talkRoomService;

		/// <summary>
		/// プロフィール用Service
		/// </summary>
		private readonly IProfileService profileService;

		/// <summary>
		/// メッセージ作成用Service
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="talkRoomService">トークルーム用Service</param>
		/// <param name="profileService">プロフィール用Service</param>
		/// <param name="messageService">メッセージ作成用Service</param>
		public SampleService(
			ILogger<SampleService> logger ,
			ITalkRoomService talkRoomService , 
			IProfileService profileService ,
			IMessageService messageService
		) {
			this.logger = logger;
			this.talkRoomService = talkRoomService;
			this.profileService = profileService;
			this.messageService = messageService;
		}

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Execute( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string replyToken = null;
			{
				JArray events = (JArray)parameter[ "events" ];
				foreach( JObject jObject in events ) {
					JValue jValue = (JValue)jObject[ "replyToken" ];
					replyToken = (string)jValue.Value;
					break;
				}
				this.logger.LogTrace( "Reply Token is {replyToken}." , replyToken );
			}

			string channelAccessToken = "1gDbkN0BwFl3S6D30NTO5NdhbmmwvIwBEcdHI7aOLgJsT3ZBNDI/N9rVCAscube+JJCy2VJTf4C9ZRPBOv/4rj91pfS7LFHEy4FoWWXp3uN9WOWydouIcNnR4XWjwN2dtCkJf4rhsBUCp5iUcYS0NQdB04t89/1O/w1cDnyilFU=";

			await this.messageService
				.SendReply(
					replyToken
				);

			this.logger.LogTrace( "End" );
		}

	}

}
