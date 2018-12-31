using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Sample {

	/// <summary>
	/// サンプル用インタフェース
	/// 最終的には削除する
	/// </summary>
	public interface ISampleService {

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		void Execute( JToken parameter );

	}

}
