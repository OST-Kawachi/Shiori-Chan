using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
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
		)
		{
			this.logger = logger;
			this.messageService = messageService;
			this.participantRepository = participantRepository;
		}

		/// <summary>
		/// 参加者一覧を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new System.NotImplementedException();

	}

}
