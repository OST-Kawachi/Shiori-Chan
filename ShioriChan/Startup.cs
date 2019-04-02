using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShioriChan.Repositories;
using ShioriChan.Repositories.MeetingPlaces;
using ShioriChan.Repositories.Notifications;
using ShioriChan.Repositories.OAuthes;
using ShioriChan.Repositories.Participants;
using ShioriChan.Repositories.RollCalls;
using ShioriChan.Repositories.Rooms;
using ShioriChan.Repositories.Schedules;
using ShioriChan.Repositories.Users;
using ShioriChan.Services.Features;
using ShioriChan.Services.Features.Contacts;
using ShioriChan.Services.Features.Hotels;
using ShioriChan.Services.Features.MeetingPlaces;
using ShioriChan.Services.Features.Menus;
using ShioriChan.Services.Features.Notifications;
using ShioriChan.Services.Features.Participants;
using ShioriChan.Services.Features.RollCalls;
using ShioriChan.Services.Features.Rooms;
using ShioriChan.Services.Features.Schedule;
using ShioriChan.Services.Features.TouristSpots;
using ShioriChan.Services.Features.Users;
using ShioriChan.Services.MessagingApis.Groups;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.OAuthes.ChannelAccessTokens;
using ShioriChan.Services.MessagingApis.OAuthes.LinkTokens;
using ShioriChan.Services.MessagingApis.Profiles;
using ShioriChan.Services.MessagingApis.RichMenus;
using ShioriChan.Services.MessagingApis.TalkRooms;
using ShioriChan.Settings;

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
		public void ConfigureServices( IServiceCollection services )
		{

			// 必須ではないCookieに対するユーザーの同意が特定のリクエストに必要かどうかを決定する
			services.Configure<CookiePolicyOptions>(
				options => {
					options.CheckConsentNeeded = context => true;
					options.MinimumSameSitePolicy = SameSiteMode.None;
				}
			);

			services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );

			// Serviceクラス、Repositoryクラスに関して依存関係をシングルトンとして挿入
			// TODO AddTransientにしないとViewが表示されない・・・？
			{

				// 共通部
				services.AddSingleton<IFeatureFacade , FeatureFacade>();

				// Repositories
				services.AddTransient<IMeetingPlaceRepository , MeetingPlaceRepository>();
				services.AddTransient<INotificationRepository , NotificationRepository>();
				services.AddTransient<IOAuthRepository , OAuthRepository>();
				services.AddTransient<IParticipantRepository , ParticipantRepository>();
				services.AddTransient<IRollCallRepository , RollCallRepository>();
				services.AddTransient<IRoomRepository , RoomRepository>();
				services.AddTransient<IScheduleRepository , ScheduleRepository>();
				services.AddTransient<IUserRepository , UserRepository>();

				// Features
				services.AddTransient<IContactService , ContactService>();
				services.AddTransient<IHotelService , HotelService>();
				services.AddTransient<IMeetingPlaceService , MeetingPlaceService>();
				services.AddTransient<IMenuService , MenuService>();
				services.AddTransient<INotificationService , NotificationService>();
				services.AddTransient<IParticipantService , ParticipantService>();
				services.AddTransient<IRollCallService , RollCallService>();
				services.AddTransient<IRoomService , RoomService>();
				services.AddTransient<IScheduleService , ScheduleService>();
				services.AddTransient<ITouristSpotService , TouristSpotService>();
				services.AddTransient<IUserService , UserService>();

				// MessagingApis
				services.AddTransient<IGroupService , GroupService>();
				services.AddTransient<IMessageService , MessageService>();
				services.AddTransient<IChannelAccessTokenService , ChannelAccessTokenService>();
				services.AddTransient<ILinkTokenService , LinkTokenService>();
				services.AddTransient<IProfileService , ProfileService>();
				services.AddTransient<IRichMenuService , RichMenuService>();
				services.AddTransient<ITalkRoomService , TalkRoomService>();

			}

			// 設定ファイルのバインド
			services.Configure<MessagingApiSetting>( this.Configuration.GetSection( "MessagingApi" ) );

			// DBContextを登録
			services.AddDbContext<ModelCreator>(
				options => options.UseSqlServer(
					this.Configuration.GetConnectionString( "Database" )
				)
			);

		}

		/// <summary>
		/// HTTPリクエストのパイプラインを構成する
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		/// <remarks>Runtimeによって呼び出される</remarks>
		public void Configure( IApplicationBuilder app , IHostingEnvironment env )
		{
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
			app.UseMvc();

		}

	}

}