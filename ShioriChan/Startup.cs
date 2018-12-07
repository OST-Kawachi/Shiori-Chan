using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShioriChan {

	public class Startup {

		public IConfiguration Configuration { get; }

		public Startup( IConfiguration configuration ) => this.Configuration = configuration;
		
		/// <summary>
		/// コンテナにサービスを追加する
		/// </summary>
		/// <remarks>Runtimeによって呼び出される</remarks>
		public void ConfigureServices( IServiceCollection services ) => services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );
		
		/// <summary>
		/// HTTPリクエストのパイプラインを構成する
		/// </summary>
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
