using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
		/// <param name="configuration"></param>
		public Startup( IConfiguration configuration ) => this.Configuration = configuration;
		
		/// <summary>
		/// コンテナにサービスを追加する
		/// </summary>
		/// <param name="services"></param>
		/// <remarks>Runtimeによって呼び出される</remarks>
		public void ConfigureServices( IServiceCollection services )
			=> services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );
		
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
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseMvc();
		}

	}

}
