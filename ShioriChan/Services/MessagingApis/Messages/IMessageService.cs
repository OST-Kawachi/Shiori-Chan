using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// メッセージ作成クラス
	/// </summary>
	public interface IMessageService {
		
		/// <summary>
		/// リプライを送信する
		/// </summary>
		/// <param name="replyToken">Webhookで受信する応答トークン</param>
		Task SendReply( string replyToken );

		/// <summary>
		/// プッシュ通知を送信する
		/// </summary>
		/// <param name="to">送信先ID</param>
		[Obsolete( "未完成です" , true )]
		Task SendPush( string to );

		/// <summary>
		/// 複数人宛にプッシュ通知を送信する
		/// </summary>
		/// <param name="toList">送信先リスト</param>
		[Obsolete( "未完成です" , true )]
		Task SendMulticast( List<string> toList );

		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		[Obsolete( "未完成です" , true )]
		Task GetContent( string channelAccessToken , string messageId );

	}
}
