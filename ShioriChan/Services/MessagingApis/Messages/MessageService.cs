using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// メッセージ作成クラス
	/// </summary>
	public class MessageService : IMessageService {

		/// <summary>
		/// ログ作成クラス
		/// </summary>
		private readonly ILoggerFactory loggerFactory;

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="loggerFactory">ログ作成クラス</param>
		public MessageService( ILoggerFactory loggerFactory ) {
			this.loggerFactory = loggerFactory;
			this.logger = this.loggerFactory.CreateLogger<MessageService>();
		}

		/// <summary>
		/// リプライを送信する
		/// </summary>
		/// <param name="replyToken">Webhookで受信する応答トークン</param>
		public async Task SendReply( string replyToken ) {
			this.logger.LogTrace( "Start" );

			// TODO 仮
			#region 仮

			JObject message = new JObject {
				{ "type" , "text" } ,
				{ "text" , "サンプル" }
			};

			JArray messages = new JArray {
				message
			};

			JObject requestParameter = new JObject {
				{ "replyToken" , replyToken } ,
				{ "messages" , messages }
			};

			StringContent content = new StringContent( requestParameter.ToString() );
			content.Headers.ContentType = new MediaTypeHeaderValue( "application/json" );
			this.logger.LogTrace( "Content is {content}" , content );

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + "" );

			try {
				this.logger.LogTrace( "Start Post Async" );
				HttpResponseMessage response = await client.PostAsync( "https://api.line.me/v2/bot/message/reply" , content ).ConfigureAwait( false );
				this.logger.LogTrace( "End Post Async" );
				string result = await response?.Content.ReadAsStringAsync();
				this.logger.LogTrace( "Post Async Result is {result}" , result );
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException ) {
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
				return;
			}
			catch( HttpRequestException ) {
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
				return;
			}
			catch( Exception ) {
				this.logger.LogError( "Exception" );
				client.Dispose();
				return;
			}

			#endregion

		}

		/// <summary>
		/// プッシュ通知を送信する
		/// </summary>
		/// <param name="to">送信先ID</param>
		[Obsolete( "未完成です" , true )]
		public async Task SendPush( string to ) { }

		/// <summary>
		/// 複数人宛にプッシュ通知を送信する
		/// </summary>
		/// <param name="toList">送信先リスト</param>
		[Obsolete( "未完成です" , true )]
		public async Task SendMulticast( List<string> toList ) { }
		
		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		[Obsolete( "未完成です" , true )]
		public async Task GetContent( string channelAccessToken , string messageId ) { }
		
	}

}
