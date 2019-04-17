using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Repositories.OAuthes;
using ShioriChan.Services.MessagingApis.OAuthes.ChannelAccessTokens;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.RichMenus
{

	/// <summary>
	/// リッチメニューService
	/// </summary>
	public class RichMenuService : IRichMenuService
	{

		private readonly ILogger logger;

		/// <summary>
		/// チャンネルアクセストークン発行クラス
		/// </summary>
		private readonly IChannelAccessTokenService channelAccessTokenService;

		/// <summary>
		/// 認証用Repository
		/// </summary>
		private readonly IOAuthRepository oAuthRepository;

		/// <summary>
		/// コンストラクタ　ログ
		/// </summary>
		/// <param name="logger"></param>
		public RichMenuService(
			ILogger<IRichMenuService> logger ,
			IChannelAccessTokenService channelAccessTokenService ,
			IOAuthRepository oAuthRepository
		)
		{
			this.logger = logger;
			this.channelAccessTokenService = channelAccessTokenService;
			this.oAuthRepository = oAuthRepository;
		}

		/// <summary>
		/// リッチメニュー作成
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リッチメニューID</returns>
		public async Task<string> Create( JToken parameter )
		{
			this.logger.LogTrace( $"Parameter is {parameter}" );

			string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
			this.logger.LogTrace( $"Channel Access Token is {channelAccessToken}" );
			if( string.IsNullOrEmpty( channelAccessToken ) )
			{
				ChannelAccessToken cat = this.channelAccessTokenService.Issue();
				channelAccessToken = cat.AccessToken;
				this.oAuthRepository.RegisterChannelAccessToken( channelAccessToken );
			}

			StringContent content = new StringContent( parameter.ToString() );
			content.Headers.ContentType = new MediaTypeHeaderValue( "application/json" );
			this.logger.LogTrace( "Content is {content}" , content );

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + channelAccessToken );

			string richMenuId = null;
			try
			{
				this.logger.LogTrace( "Start Post Async" );
				HttpResponseMessage response = await client.PostAsync( "https://api.line.me/v2/bot/richmenu" , content ).ConfigureAwait( false );
				this.logger.LogTrace( "End Post Async" );
				string result = await response?.Content.ReadAsStringAsync();
				this.logger.LogTrace( "Post Async Result is {result}" , result );
				JToken resultObject = JToken.Parse( result );
				richMenuId = resultObject[ "richMenuId" ].ToString();
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException )
			{
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
			}
			catch( HttpRequestException )
			{
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
			}
			catch( Exception )
			{
				this.logger.LogError( "Exception" );
				client.Dispose();
			}

			return richMenuId;
		}

		/// <summary>
		/// リッチメニューを削除する
		/// </summary>
		public async Task Delete( string richMenuId )
		{
			this.logger.LogTrace( $"Rech Menu Id is {richMenuId}" );

			string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
			this.logger.LogTrace( $"Channel Access Token is {channelAccessToken}" );
			if( string.IsNullOrEmpty( channelAccessToken ) )
			{
				ChannelAccessToken cat = this.channelAccessTokenService.Issue();
				channelAccessToken = cat.AccessToken;
				this.oAuthRepository.RegisterChannelAccessToken( channelAccessToken );
			}

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + channelAccessToken );

			try
			{
				this.logger.LogTrace( "Start Post Async" );
				HttpResponseMessage response = await client.DeleteAsync("https://api.line.me/v2/bot/richmenu/" + richMenuId).ConfigureAwait( false );
				this.logger.LogTrace( "End Delete Async" );
				string result = await response?.Content.ReadAsStringAsync();
				this.logger.LogTrace( "Delete Async Result is {result}" , result );
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException )
			{
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
				return;
			}
			catch( HttpRequestException )
			{
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
				return;
			}
			catch( Exception )
			{
				this.logger.LogError( "Exception" );
				client.Dispose();
				return;
			}

			return;
		}

		/// <summary>
		/// リッチメニューを取得する
		/// </summary>
		public async Task<Responce> Get( string richMenuId )
		{
			this.logger.LogTrace( $"Rich Menu Id is {richMenuId}" );

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + channelAccessToken );

			try
			{
				this.logger.LogTrace( "Start Post Async" );
				HttpResponseMessage response = await client.GetAsync( "https://api.line.me/v2/bot/richmenu/" + richMenuId ).ConfigureAwait( false );
				this.logger.LogTrace( "End Get Async" );
				string result = await response?.Content.ReadAsStringAsync();
				this.logger.LogTrace( "Get Async Result is {result}" , result );
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException )
			{
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
				return null;
			}
			catch( HttpRequestException )
			{
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
				return null;
			}
			catch( Exception )
			{
				this.logger.LogError( "Exception" );
				client.Dispose();
				return null;
			}
			return new Responce();
		}

		/// <summary>
		/// デフォルトのリッチメニューのIDを取得する
		/// </summary>
		public async Task<object> GetDefaultId()
		{

			string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
			this.logger.LogTrace( $"Channel Access Token is {channelAccessToken}" );
			if( string.IsNullOrEmpty( channelAccessToken ) )
			{
				ChannelAccessToken cat = this.channelAccessTokenService.Issue();
				channelAccessToken = cat.AccessToken;
				this.oAuthRepository.RegisterChannelAccessToken( channelAccessToken );
			}

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + channelAccessToken );

			object DefaultRichMenuId = null;
			try
			{
				this.logger.LogTrace( "Start Post Async" );
				HttpResponseMessage response = await client.GetAsync( "https://api.line.me/v2/bot/user/all/richmenu" ).ConfigureAwait( false );
				this.logger.LogTrace( "End Get Async" );
				string result = await response?.Content.ReadAsStringAsync();
				this.logger.LogTrace( "Get Async Result is {result}" , result );
				DefaultRichMenuId = response;
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException )
			{
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
				return null;
			}
			catch( HttpRequestException )
			{
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
				return null;
			}
			catch( Exception )
			{
				this.logger.LogError( "Exception" );
				client.Dispose();
				return null;
			}
			return DefaultRichMenuId;
		}

		/// <summary>
		/// ユーザのリッチメニューのIDを取得する
		/// </summary>
		public async Task<object> GetId( string userId )
		{
			this.logger.LogTrace( $" UserId is {userId}" );

			string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
			this.logger.LogTrace( $"Channel Access Token is {channelAccessToken}" );
			if( string.IsNullOrEmpty( channelAccessToken ) )
			{
				ChannelAccessToken cat = this.channelAccessTokenService.Issue();
				channelAccessToken = cat.AccessToken;
				this.oAuthRepository.RegisterChannelAccessToken( channelAccessToken );
			}

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + channelAccessToken );

			object UserRichMenuId = null;
			try
			{
				this.logger.LogTrace( "Start Post Async" );
				HttpResponseMessage response = await client.GetAsync( "https://api.line.me/v2/bot/user/" + userId + "/richmenu" ).ConfigureAwait( false );
				this.logger.LogTrace( "End Get Async" );
				string result = await response?.Content.ReadAsStringAsync();
				this.logger.LogTrace( "Get Async Result is {result}" , result );
				UserRichMenuId = response;
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException )
			{
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
				return null;
			}
			catch( HttpRequestException )
			{
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
				return null;
			}
			catch( Exception )
			{
				this.logger.LogError( "Exception" );
				client.Dispose();
				return null;
			}
			return UserRichMenuId;
		}

		/// <summary>
		/// リッチメニューのID一覧を取得する
		/// </summary>
		/// <returns></returns>
		public async Task<List<string>> GetIds()
		{
			string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
			this.logger.LogTrace( $"Channel Access Token is {channelAccessToken}" );
			if( string.IsNullOrEmpty( channelAccessToken ) )
			{
				ChannelAccessToken cat = this.channelAccessTokenService.Issue();
				channelAccessToken = cat.AccessToken;
				this.oAuthRepository.RegisterChannelAccessToken( channelAccessToken );
			}

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			client.DefaultRequestHeaders.Add( "Authorization" , "Bearer " + channelAccessToken );

			List<string> richMenus = new List<string>();
			try
			{
				this.logger.LogTrace( "Start Get Async" );
				HttpResponseMessage response = await client.GetAsync( "https://api.line.me/v2/bot/richmenu/list" ).ConfigureAwait( false );
				this.logger.LogTrace( "End Get Async" );
				string result = await response?.Content.ReadAsStringAsync();
				this.logger.LogTrace( "Get Async Result is {result}" , result );
				JToken resultToken = JToken.Parse(result);
				JArray richMenuIds = resultToken[ "richmenus" ] as JArray;
				foreach( JToken id in richMenuIds ) {
					richMenus.Add( id.ToString() );
				}
				//RichMenus = result; //TODO:Listに直す
				response.Dispose();
				client.Dispose();
			}
			catch( ArgumentNullException )
			{
				this.logger.LogError( "Argument Null Exception" );
				client.Dispose();
				return null;
			}
			catch( HttpRequestException )
			{
				this.logger.LogError( "Http Request Exception" );
				client.Dispose();
				return null;
			}
			catch( Exception )
			{
				this.logger.LogError( "Exception" );
				client.Dispose();
				return null;
			}

			return richMenus;
		}

		/// <summary>
		/// リッチメニューとユーザをリンクする
		/// </summary>
		public async Task LinkToUser( string richMenuId , string userId ) {
            this.logger.LogTrace($"Rech Menu Id is {richMenuId}");
            this.logger.LogTrace($"UserId is {userId}");

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }

			StringContent content = new StringContent( "" );
			content.Headers.ContentType = new MediaTypeHeaderValue( "application/json" );
			this.logger.LogTrace( "Content is {content}" , content );

			HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.PostAsync("https://api.line.me/v2/bot/user/" + userId +"/richmenu/" + richMenuId ,  content ).ConfigureAwait(false);
                this.logger.LogTrace("End Post Async");
                string result = await response?.Content.ReadAsStringAsync();
                this.logger.LogTrace("Post Async Result is {result}", result);
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return;
            }

            return;
        }

		/// <summary>
		/// リッチメニューとユーザのリンクを解除する
		/// </summary>
		public async Task Release( string userId ) {
            this.logger.LogTrace($"Rech Menu Id is {userId}");

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.DeleteAsync("https://api.line.me/v2/bot/user/" + userId + "/richmenu").ConfigureAwait(false);
                this.logger.LogTrace("End Delete Async");
                string result = await response?.Content.ReadAsStringAsync();
                this.logger.LogTrace("Post Async Result is {result}", result);
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return;
            }

            return;
        }

		/// <summary>
		/// デフォルトのリッチメニューを解除する
		/// </summary>
		public async Task ReleaseDefault() {

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.DeleteAsync("https://api.line.me/v2/bot/user/all/richmenu").ConfigureAwait(false);
                this.logger.LogTrace("End Delete Async");
                string result = await response?.Content.ReadAsStringAsync();
                this.logger.LogTrace("Post Async Result is {result}", result);
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return;
            }

            return;
        }

		/// <summary>
		/// デフォルトのリッチメニューを設定する
		/// </summary>
		public async Task SetDefault( string richMenuId ) {
            this.logger.LogTrace($"Rech Menu Id is {richMenuId}");

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }

            StringContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.logger.LogTrace("Content is {content}", content);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.PostAsync("https://api.line.me/v2/bot/user/all/richmenu/" + richMenuId, content).ConfigureAwait(false);
                this.logger.LogTrace("End Post Async");
                string result = await response?.Content.ReadAsStringAsync();
                this.logger.LogTrace("Post Async Result is {result}", result);
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return;
            }

            return;
        }

        /// <summary>
        /// リッチメニューと複数ユーザをリンクする
        /// </summary>
        public async Task LinkToBulkUser( List<string> userIds , string richMenuId )
        {
            this.logger.LogTrace($"Rech Menu Id is {richMenuId}");
            this.logger.LogTrace($"UserIds is {userIds}");

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }
			JObject parameter = new JObject {
				{ "userIds" , new JArray( userIds ) } ,
				{ "richMenuId" , richMenuId }
			};
			StringContent content = new StringContent( parameter.ToString() );
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.logger.LogTrace("Content is {content}", content);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.PostAsync("https://api.line.me/v2/bot/richmenu/bulk/link", content).ConfigureAwait(false);
                this.logger.LogTrace("End Post Async");
                string result = await response?.Content.ReadAsStringAsync();
                this.logger.LogTrace("Post Async Result is {result}", result);
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return;
            }

            return;
        }

        /// <summary>
        /// リッチメニューと複数ユーザのリンクを解除する
        /// </summary>
        public async Task BulkUnlink( List<string> userIds )
        {
            this.logger.LogTrace($"UserIds is {userIds}");

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }

            StringContent content = new StringContent(userIds.ToString());
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.logger.LogTrace("Content is {content}", content);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.PostAsync("https://api.line.me/v2/bot/user/all/richmenu" , content ).ConfigureAwait(false);
                this.logger.LogTrace("End Post Async");
                string result = await response?.Content.ReadAsStringAsync();
                this.logger.LogTrace("Post Async Result is {result}", result);
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return;
            }

            return;
        }

        /// <summary>
        /// リッチメニューの画像をアップロードする
        /// </summary>
        public void ContentUpload() { }//TODO:旧しおりちゃん見てやる

        /// <summary>
        /// リッチメニューの画像をダウンロードする
        /// </summary>
        public async Task<byte[]> ContentDownload( string richMenuId )
        {
            this.logger.LogTrace($"Rech Menu Id is {richMenuId}");

            string channelAccessToken = this.oAuthRepository.GetNewlyChannelAccessToken();
            this.logger.LogTrace($"Channel Access Token is {channelAccessToken}");
            if (string.IsNullOrEmpty(channelAccessToken))
            {
                ChannelAccessToken cat = this.channelAccessTokenService.Issue();
                channelAccessToken = cat.AccessToken;
                this.oAuthRepository.RegisterChannelAccessToken(channelAccessToken);
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            byte[] Content = null;
            try
            {
                this.logger.LogTrace("Start Post Async");
                HttpResponseMessage response = await client.GetAsync("https://api.line.me/v2/bot/richmenu/" + richMenuId + "/content").ConfigureAwait(false);
                this.logger.LogTrace("End Get Async");
                string result = await response?.Content.ReadAsStringAsync();
                this.logger.LogTrace("Get Async Result is {result}", result);
                //Content = byte.Parse(result); TODO:旧しおりちゃん見てやる
                response.Dispose();
                client.Dispose();
            }
            catch (ArgumentNullException)
            {
                this.logger.LogError("Argument Null Exception");
                client.Dispose();
                return null;
            }
            catch (HttpRequestException)
            {
                this.logger.LogError("Http Request Exception");
                client.Dispose();
                return null;
            }
            catch (Exception)
            {
                this.logger.LogError("Exception");
                client.Dispose();
                return null;
            }

            return Content;
        }


    }
}
