
using ShioriChan.Services.MessagingApis.Messages.Senders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	public partial class MessageBuilder {

		/// <summary>
		/// MessageSender
		/// 実装は隠したいのでprivateとする
		/// </summary>
		private class MessageSender : IMessageSender {

			/// <summary>
			/// 送信用Parameter
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// 直接インスタンス生成してほしくないのでprivateとする
			/// </summary>
			/// <param name="parameter">送信用パラメータ</param>
			public MessageSender( MessageParameter parameter ) => this.parameter = parameter;

			/// <summary>
			/// 送信
			/// </summary>
			/// <param name="replyToken">リプライトークン</param>
			public Task Reply( string replyToken ) => null;

			/// <summary>
			/// プッシュ通知
			/// </summary>
			/// <param name="to">対象者ID</param>
			public Task Push( string to ) => null;

			/// <summary>
			/// 複数人プッシュ通知
			/// </summary>
			/// <param name="toList">対象者ID一覧</param>
			public Task Multicast( List<string> toList ) => null;

			/*
			/// <summary>
			/// リプライを送信する
			/// </summary>
			/// <param name="builder">ビルド可能メッセージBuilder</param>
			public async Task SendReply( MessageBuilder.BuildableMessageBuilder builder ) {
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

			*/

		}

	}


}
