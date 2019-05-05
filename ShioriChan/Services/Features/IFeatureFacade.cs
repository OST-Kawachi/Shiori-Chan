using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ShioriChan.Services.Features {

	/// <summary>
	/// しおりちゃん固有機能の窓口Interface
	/// </summary>
	public interface IFeatureFacade {

		/// <summary>
		/// 実行
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		Task Execute( JToken parameter );

	}

}
