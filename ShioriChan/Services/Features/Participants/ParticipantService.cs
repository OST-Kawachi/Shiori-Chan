using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;
using ShioriChan.Repositories.Participants;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Participants {

	/// <summary>
	/// 参加者Service
	/// </summary>
	public class ParticipantService : IParticipantService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// 参加者Repository
		/// </summary>
		private readonly IParticipantRepository participantRepository;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="participantRepository">参加者Repository</param>
		public ParticipantService(
			ILogger<ParticipantService> logger ,
			IMessageService messageService ,
			IParticipantRepository participantRepository
		) {
			this.logger = logger;
			this.messageService = messageService;
			this.participantRepository = participantRepository;
		}
		
		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			string replyToken = firstEvent[ "replyToken" ].ToString();
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

			return replyToken;
		}

		/// <summary>
		/// 参加者一覧を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Show( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

			// 参加者リストからイベントが社員旅行のメンバーを取得する
			List<UserInfo> participants = this.participantRepository.GetParticipantNames();

			string message = "参加者の一覧を表示します\n" +
				"\n" +
				"1日目イベント\n" +
				"A:藍染・白ハンカチ\n" +
				"B:陶芸・てひねり\n" +
				"C:サンドブラスト\n" +
				"D:竹千筋細工・小鈴\n" +
				"\n" +
				"2日目イベント\n" +
				"a:清水港ベイクルーズ\n" +
				"b:久能山東照宮\n";
			for( int i = 0 ; i < participants.Count ; i++ ) {
				if( i != 0 ) {
					message += "\n";
				}
				message += participants[ i ].Name;
				this.logger.LogDebug( $"participants[{i}] Name is {participants[ i ].Name}" );
				this.logger.LogDebug( $"participants[{i}] FirstScheduleName is {participants[ i ].FirstScheduleName}" );
				this.logger.LogDebug( $"participants[{i}] econdScheduleName is {participants[ i ].SecondScheduleName}" );
				for( int j = 0 ; j < 7 - participants[ i ].Name.Length ; j++ ) {
					message += "　";
				}
				message += "1日目:";
				message += string.IsNullOrEmpty( participants[ i ].FirstScheduleName ) ? "ー" : participants[ i ].FirstScheduleName;
				message += " ";
				message += "2日目:";
				message += string.IsNullOrEmpty( participants[ i ].SecondScheduleName ) ? "ー" : participants[ i ].SecondScheduleName;
			}
			this.logger.LogDebug( $"message Length is {message.Length}" );
			await this.messageService
					.CreateMessageBuilder()
					.AddMessage( message )
					.BuildMessage()
					.Reply( replyToken );

			this.logger.LogInformation( "End" );
		}

	}

}