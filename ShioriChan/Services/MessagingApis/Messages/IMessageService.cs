﻿using ShioriChan.Services.MessagingApis.Messages.BuilderFactories;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using System;
using System.Threading.Tasks;

namespace ShioriChan.Services.MessagingApis.Messages {

	/// <summary>
	/// メッセージ作成クラス
	/// </summary>
	public interface IMessageService {

		/// <summary>
		/// メッセージBuilder作成
		/// </summary>
		/// <returns>メッセージBuilder</returns>
		IAddOnlyMessageOfMessageBuilder CreateMessageBuilder();
		
		/// <summary>
		/// コンテンツの取得
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <param name="messageId">メッセージID</param>
		Task<byte[]> GetContent( string messageId );

        /// <summary>
        /// 追加メッセージの上限数取得
        /// </summary>
        /// <returns></returns>
        Task<object> GetMessageLimit();

        /// <summary>
        /// 当月のメッセージ利用状況を取得する
        /// </summary>
        /// <returns></returns>
        Task<object> GetMessageStatus();

        /// <summary>
        /// 送信済み応答メッセージ数を取得
        /// </summary>
        /// <returns></returns>
        Task<object> GetSentReplyMessageCount( DateTime replyDate );
	}

}
