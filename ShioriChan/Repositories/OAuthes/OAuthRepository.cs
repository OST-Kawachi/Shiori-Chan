using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShioriChan.Entities;

namespace ShioriChan.Repositories.OAuthes {

	/// <summary>
	/// 認証用Repository
	/// </summary>
	public class OAuthRepository : IOAuthRepository {

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
		public OAuthRepository(
			ILogger<OAuthRepository> logger ,
			ModelCreator model
		)
		{
			this.logger = logger;
			this.model = model;
		}

		/// <summary>
		/// 最新のチャンネルアクセストークンを取得
		/// </summary>
		/// <returns>チャンネルアクセストークン</returns>
		public string GetNewlyChannelAccessToken()
		{
			this.logger.LogInformation( "Start" );
			List<AccessToken> accessTokens = this.model.AccessTokens
				.Where( at =>
					at.StartDateTime <= DateTime.Now &&
					DateTime.Now <= at.StartDateTime.AddDays( 30.0 )
				)
				.OrderByDescending( at => at.Seq )
				.ToList();

			this.logger.LogDebug( $"Access Tokens Count is {accessTokens.Count}" );
			if( accessTokens.Count == 0 ) {
				this.logger.LogDebug( "End" );
				return null;
			}
			string token = accessTokens[ 0 ].Token;
			this.logger.LogDebug( $"Access Token is {token}" );
			this.logger.LogInformation("End");
			return token;
		}

		/// <summary>
		/// チャンネルアクセストークンを登録する
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		public void RegisterChannelAccessToken( string channelAccessToken )
		{
			this.logger.LogInformation("Start");
			this.logger.LogDebug($"Channel Access Token is {channelAccessToken}");

			this.model.AccessTokens.Add( new AccessToken()
			{
				Seq = this.model.AccessTokens.Max( at => at.Seq ) + 1 ,
				Token = channelAccessToken ,
				StartDateTime = DateTime.Now ,
				RegisterUserSeq = 0 ,
				RegisterDatetime = DateTime.Now ,
				UpdateUserSeq = 0 ,
				UpdateDatetime = DateTime.Now ,
				Version = 0
			} );
			this.model.SaveChanges();
			this.logger.LogInformation("End");
		}

	}

}
