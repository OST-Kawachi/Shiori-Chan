
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Senders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public static partial class MessageBuilderFactory {

		/// <summary>
		/// MessageSender
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class MessageSender : IMessageSender {

			/// <summary>
			/// 送信用Parameter
			/// </summary>
			private readonly MessageParameter parameter;

			private readonly ILogger logger;

			/// <summary>
			/// コンストラクタ
			/// 直接インスタンス生成してほしくないのでprivateとする
			/// </summary>
			/// <param name="parameter">送信用パラメータ</param>
			public MessageSender( MessageParameter parameter ) {
				this.parameter = parameter;
				this.logger = this.parameter.LoggerFactory.CreateLogger<MessageSender>();
			}

			/// <summary>
			/// 送信
			/// </summary>
			/// <param name="replyToken">リプライトークン</param>
			public async Task Reply( string replyToken ) {
				JObject parameter = new JObject{
					{ "replyToken" , replyToken } ,
					{ "messages" , this.parameter.Messages }
				};
				this.logger.LogTrace( $"Parameter is {parameter}" );

				StringContent content = new StringContent( parameter.ToString() );
				content.Headers.ContentType = new MediaTypeHeaderValue( "application/json" );
				this.logger.LogTrace( "Content is {content}" , content );

				HttpClient client = new HttpClient();
				client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
				client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + this.parameter.ChannelAccessToken );

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

			}

			/// <summary>
			/// プッシュ通知
			/// </summary>
			/// <param name="to">対象者ID</param>
			public Task Push( string to ) {
				JObject parameter = new JObject{
					{ "to" , to } ,
					{ "messages" , this.parameter.Messages }
				};
				this.logger.LogTrace( $"Parameter is {parameter}" );


				return null;
			}

			/// <summary>
			/// 複数人プッシュ通知
			/// </summary>
			/// <param name="toList">対象者ID一覧</param>
			public Task Multicast( List<string> toList ) {
				JArray to = new JArray();
				toList.ForEach( t => to.Add( t ) );
				JObject parameter = new JObject{
					{ "to" , to } ,
					{ "messages" , this.parameter.Messages }
				};
				this.logger.LogTrace( $"Parameter is {parameter}" );


				return null;
			}

		}

	}
}
