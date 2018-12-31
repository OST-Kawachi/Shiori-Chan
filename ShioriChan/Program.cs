using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ShioriChan {

	/// <summary>
	/// エントリポイント用クラス
	/// </summary>
	public class Program {

		/// <summary>
		/// エントリポイント
		/// </summary>
		/// <param name="args"></param>
		public static void Main( string[] args )
			=> WebHost.CreateDefaultBuilder( args ).UseStartup<Startup>().Build().Run();

	}

}
