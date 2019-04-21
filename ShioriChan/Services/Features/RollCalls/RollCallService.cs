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
		/// 返事をする
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Reply( JToken parameter ) => throw new System.NotImplementedException();

		/// <summary>
		/// 受付を開始する
		/// </summary>
		public Task StartAcception() => throw new System.NotImplementedException();

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		public Task<List<Status>> GetStatuses()
			=> this.rollCallRepository.GetStatuses();

	}

}
