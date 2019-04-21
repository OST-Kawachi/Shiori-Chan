using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static ShioriChan.Controllers.RollCalls.RollCallsController;

namespace ShioriChan.Repositories.RollCalls {

	/// <summary>
	/// 点呼Repository
	/// </summary>
	public class RollCallRepository : IRollCallRepository {
		private const string None = "－";
		private const string Ng = "×";
		private const string Ok = "〇";

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// DBモデル
		/// </summary>
		private readonly ModelCreator model;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		public RollCallRepository(
			ILogger<RollCallRepository> logger ,
			ModelCreator model
		) {
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 点呼の状況を取得する
		/// </summary>
		public async Task<List<Status>> GetStatuses()
			=> this.model.Participants
				.Where( p => p.EventSeq == 0 )
				.Select( p => new Status {
					UserSeq = p.UserSeq ,
					RollCall = p.RollCall.HasValue ? p.RollCall.Value ? Ok : Ng : None ,
					Name = this.model.UserInfos
						.Single( u => u.Seq == p.UserSeq )
						.Name
				} )
			.ToList();

	}

}