using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {

	public static partial class MessageBuilderFactory {

		/// <summary>
		/// メッセージパラメータ
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class MessageParameter {

			/// <summary>
			/// ログ生成クラス
			/// </summary>
			public ILoggerFactory LoggerFactory { set; get; }

			/// <summary>
			/// チャンネルアクセストークン
			/// </summary>
			public string ChannelAccessToken { set; get; }

			/// <summary>
			/// メッセージ配列
			/// </summary>
			public JArray Messages { set; get; }

		}

	}

}
