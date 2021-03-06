﻿using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;

namespace ShioriChan.Services.Features.Contacts {

	/// <summary>
	/// 連絡先Service
	/// </summary>
	public class ContactService : IContactService {

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
		/// <param name="contactRepository">メッセージService</param>
		public ContactService(
			ILogger<ContactService> logger ,
			IMessageService messageService
		)
		{
			this.logger = logger;
			this.messageService = messageService;
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
		/// 連絡先を表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task Show( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogDebug($"Reply Token is {replyToken}");
			await this.messageService.CreateMessageBuilder()
				.AddMessage( 
					"幹事の人や旅館の連絡先はこちら♪\n" +
					"\n" +
					"永井さん：090-7675-7323\n\n" +
					"本郷さん：080-3631-0147\n\n" +
					"伊藤さん：080-4542-1543\n\n" +
					"熊澤さん：090-4793-0846\n\n" +
					"\n" +
					"宿泊先\n" +
					"ヒルトン福岡シーホーク\n" +
					"〒810-8650\n" +
					"福岡県福岡市中央区地行浜2-2-3\n" +
					"TEL:092-844-8111"
				)
				.BuildMessage()
				.Reply( replyToken );
			
			this.logger.LogInformation( "End" );
		}

	}

}
