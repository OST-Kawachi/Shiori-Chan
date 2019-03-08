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

			public string to;

			public string[] toList;

			public class Message {

				public class QuickReply {
					public class Item {
						public string type;
						public string imageUrl;
						public class Action {
							public string type;
							public string label;
							public string data;
							public string displayText;
							public string text;
							public string uri;
							public class AltUri {
								public string desktop;
							}
							public AltUri altUri;
							// 日時選択アクションから
						}
						public Action action;
					}
					public Item[] items;
				}
				public QuickReply quickReply;
			}
			public Message[] messages;

		}

	}
}
