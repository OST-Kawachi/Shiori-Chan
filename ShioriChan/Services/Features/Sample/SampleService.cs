using System;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features.Sample {

	/// <summary>
	/// サンプル用クラス
	/// 最終的には削除する
	/// </summary>
	public class SampleService : ISampleService {

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public void Execute( JToken parameter )
			=> throw new NotImplementedException();

	}

}
