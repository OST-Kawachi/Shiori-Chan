using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.RichMenus {

	/// <summary>
	/// リッチメニューService
	/// </summary>
	public interface IRichMenuService {

		/// <summary>
		/// リッチメニュー作成
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リッチメニューID</returns>
		Task<string> Create( JToken parameter );

		/// <summary>
		/// リッチメニューのID一覧を取得する
		/// </summary>
		/// <returns></returns>
		Task<List<string>> GetIds();

		/// <summary>
		/// リッチメニューを取得する
		/// </summary>
		Task<Responce> Get( string richMenuId );

		/// <summary>
		/// リッチメニューを削除する
		/// </summary>
		Task Delete( string richMenuId);

		/// <summary>
		/// デフォルトのリッチメニューを設定する
		/// </summary>
		Task SetDefault( string richMenuId );

		/// <summary>
		/// デフォルトのリッチメニューのIDを取得する
		/// </summary>
		Task<object> GetDefaultId();

		/// <summary>
		/// デフォルトのリッチメニューを解除する
		/// </summary>
		Task ReleaseDefault();

		/// <summary>
		/// リッチメニューとユーザをリンクする
		/// </summary>
		Task LinkToUser( string richMenuId , string userId );

		/// <summary>
		/// ユーザのリッチメニューのIDを取得する
		/// </summary>
		Task<object> GetId( string userId );

		/// <summary>
		/// リッチメニューとユーザのリンクを解除する
		/// </summary>
		Task Release( string userId );

        /// <summary>
        /// リッチメニューと複数ユーザーをリンクする
        /// </summary>
        Task LinkToBulkUser( List<string> userIds, string richMenuId );

        /// <summary>
        /// リッチメニューと複数ユーザのリンクを解除する
        /// </summary>
        Task BulkUnlink( List<string> userIds );

        /// <summary>
        /// リッチメニューの画像をアップロードする
        /// </summary>
        void ContentUpload();

        /// <summary>
        /// リッチメニューの画像をダウンロードする
        /// </summary>
        Task<byte[]> ContentDownload( string richMenuId );
    }

}
