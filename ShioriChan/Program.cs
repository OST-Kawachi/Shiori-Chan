using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ShioriChan {

	/// <summary>
	/// アプリのマネージドエントリポイント
	/// </summary>
	public class Program {

		/// <summary>
		/// アプリのマネージドエントリポイント
		/// </summary>
		/// <param name="args">引数</param>
		public static void Main( string[] args )
			=> WebHost.CreateDefaultBuilder( args ).UseStartup<Startup>().Build().Run();

	}

}
