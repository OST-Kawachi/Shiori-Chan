using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShioriChan.Repositories.Rooms;
using ShioriChan.Services.Features;
using ShioriChan.Services.Features.Rooms;
using ShioriChan.Services.Features.Samples;
using ShioriChan.Services.MessagingApis.Groups;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.OAuthes.ChannelAccessTokens;
using ShioriChan.Services.MessagingApis.OAuthes.LinkTokens;
using ShioriChan.Services.MessagingApis.Profiles;
using ShioriChan.Services.MessagingApis.RichMenus;
using ShioriChan.Services.MessagingApis.TalkRooms;

namespace ShioriChan {

	/// <summary>
	/// 起動時設定クラス
	/// </summary>
	public class Startup {

		/// <summary>
		/// Configuration
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="configuration">Configuration</param>
		public Startup( IConfiguration configuration ) => this.Configuration = configuration;

		/// <summary>
		/// コンテナにサービスを追加する
		/// </summary>
		/// <remarks>Runtimeによって呼び出される</remarks>
		/// <param name="services">Service</param>
		public void ConfigureServices( IServiceCollection services ) {

			// 必須ではないCookieに対するユーザーの同意が特定のリクエストに必要かどうかを決定する
			services.Configure<CookiePolicyOptions>( options => {
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			} );

			services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );

			// Serviceクラスに関して依存関係を挿入
			// Service自体はシングルトンとして追加
			{

				// 共通部
				services.AddSingleton<IFeatureFacade , FeatureFacade>();

				// Repositories
				services.AddSingleton<IRoomRepository , RoomRepository>();

				// Features
				services.AddSingleton<ISampleService , SampleService>();
				services.AddSingleton<IRoomService , RoomService>();

				// MessagingApis
				services.AddSingleton<IGroupService , GroupService>();
				services.AddSingleton<IMessageService , MessageService>();
				services.AddSingleton<IChannelAccessTokenService , ChannelAccessTokenService>();
				services.AddSingleton<ILinkTokenService , LinkTokenService>();
				services.AddSingleton<IProfileService , ProfileService>();
				services.AddSingleton<IRichMenuService , RichMenuService>();
				services.AddSingleton<ITalkRoomService , TalkRoomService>();

			}

		}

		/// <summary>
		/// HTTPリクエストのパイプラインを構成する
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		/// <remarks>Runtimeによって呼び出される</remarks>
		public void Configure( IApplicationBuilder app , IHostingEnvironment env ) {
			if( env.IsDevelopment() ) {
				app.UseDeveloperExceptionPage();
			}
			else {
				app.UseExceptionHandler( "/Home/Error" );
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseMvc( routes => {
				routes.MapRoute(
					name: "default" ,
					template: "{controller=Tops}/{action=Index}/{id?}" );
			} );

		}

	}

}
