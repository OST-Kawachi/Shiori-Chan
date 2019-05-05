using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.RollCalls;
using ShioriChan.Services.MessagingApis.Messages;
using static ShioriChan.Controllers.RollCalls.RollCallsController;

namespace ShioriChan.Services.Features.RollCalls {

	/// <summary>
	/// 点呼Service
	/// </summary>
	public class RollCallService : IRollCallService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// 点呼Repository
		/// </summary>
		private readonly IRollCallRepository rollCallRepository;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="rollCallRepository">点呼Repository</param>
		public RollCallService(
			ILogger<RollCallService> logger ,
			IMessageService messageService ,
			IRollCallRepository rollCallRepository
		) {
			this.logger = logger;
			this.messageService = messageService;
			this.rollCallRepository = rollCallRepository;
		}

		/// <summary>
		/// ユーザIDを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ユーザID</returns>
		private string GetUserId( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken source = firstEvent[ "source" ];
			string userId = source[ "userId" ].ToString();
			this.logger.LogTrace( $"User Id is {userId}." );

			return userId;
		}

		/// <summary>
		/// 返事をする
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Reply( JToken parameter ) {
			string userId = this.GetUserId( parameter );
			await this.rollCallRepository.TellIAmThere( userId );
		}

		/// <summary>
		/// 受付を開始する
		/// </summary>
		public async Task Notify() {
			await this.rollCallRepository.Reset();
			List<string> toList = this.rollCallRepository.GetParticipantIds();
			await this.messageService.CreateMessageBuilder()
				.AddTemplate( "点呼" )
				.UseButtonTemplate( "点呼を受け付けます！\n集合場所に来たら下のボタンを押してください！" )
				.SetAction()
				.UsePostbackAction( "いるよ！" , "roll-call-reply" )
				.SetDisplayText( "いるよ！")
				.BuildTemplate()
				.BuildMessage()
				.Multicast( toList );
		}

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		public Task<List<Status>> GetStatuses()
			=> this.rollCallRepository.GetStatuses();

	}

}
