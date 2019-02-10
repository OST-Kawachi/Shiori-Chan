namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public static partial class MessageBuilderFactory {

		/// <summary>
		/// メッセージパラメータ
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class MessageParameter {

			/// <summary>
			/// チャンネルアクセストークン
			/// </summary>
			public string channelAccessToken;

			public string replyToken;

			public class QuickReply {

				// datetimepickerだったら使う項目
				public string initial;

				public string max;

				public string min;

			}

			public QuickReply q;

		}

	}
}
