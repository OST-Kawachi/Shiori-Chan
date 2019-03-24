using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Hotels {

	/// <summary>
	/// 宿泊施設Service
	/// </summary>
	public class HotelService : IHotelService {

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// メッセージService
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		public HotelService(
			ILogger<HotelService> logger ,
			IMessageService messageService
		)
		{
			this.logger = logger;
			this.messageService = messageService;
		}

		/// <summary>
		/// 宿泊施設を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public Task Show( JToken parameter ) => throw new NotImplementedException();

	}

}
