using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.Features {

	/// <summary>
	/// しおりちゃん固有機能の窓口Interface
	/// </summary>
	public interface IFeatureFacade {

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		void Execute( JToken parameter );

	}

}
