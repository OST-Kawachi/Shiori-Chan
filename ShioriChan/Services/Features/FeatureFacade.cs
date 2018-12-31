using Newtonsoft.Json.Linq;
using ShioriChan.Services.Features.Sample;

namespace ShioriChan.Services.Features {

	/// <summary>
	/// しおりちゃん固有機能の窓口Interface
	/// </summary>
	public class FeatureFacade : IFeatureFacade {

		/// <summary>
		/// サンプル用Service
		/// </summary>
		private readonly ISampleService sampleService = new SampleService();

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public void Execute( JToken parameter ) {

			// parameterを確認してどの機能を呼び出すか判断する
			if( !( parameter is null ) ) {
				this.sampleService.Execute( parameter );
			}

		}

	}

}
