using System.Collections.Generic;
using ShioriChan.Services.MessagingApis.Messages.Test;

namespace ShioriChan.Services.MessagingApis.Messages.Test {

	public interface IMessageSender {
		void Reply( string replyToken );
		void Push();
	}
    public interface IAddOnlyMessageBuilder {
        IMessageBuilder Add( string text );
	}
    public interface IMessageBuilder : IAddOnlyMessageBuilder {
		IAddOnlyQuickReplyBuilder AddQuickReply();
		IMessageSender Build();
    }
	public interface IAddOnlyQuickReplyBuilder {
		IQuickReplyBuilder AddItem();
	}
	public interface IQuickReplyBuilder : IAddOnlyQuickReplyBuilder {
        IBuildOnlyMessageBuilder BuildQuickReply();
	}
    public interface IBuildOnlyMessageBuilder  {
        IMessageSender Build();
    }
	
    public abstract class MessageBuilderBase {

		private class Parameter {
			public string ChannelAccessToken;
			public List<string> messages = new List<string>();
		}
        
		private Parameter parameter;//基本メンバー

		private MessageBuilderBase(Parameter parameter) => this.parameter = parameter ??  new Parameter();

		public static IAddOnlyMessageBuilder CreateMessageBuilder( string channelAccessToken )
			=> new MessageBuilder( new Parameter() { ChannelAccessToken = channelAccessToken });

		private class MessageBuilder : IMessageBuilder, IBuildOnlyMessageBuilder {
			private Parameter parameter;
			private object p;

			public MessageBuilder( Parameter parameter ){ }

			public IMessageSender Build() => new MessageSender( this.parameter );
			public IMessageBuilder Add( string text ) {
				this.parameter.messages.Add( text );
				return this;
			}
			public IAddOnlyQuickReplyBuilder AddQuickReply() => new QuickReplyBuilder(this.parameter);
		}

		private class QuickReplyBuilder : IQuickReplyBuilder {
			private Parameter parameter;
			public QuickReplyBuilder( Parameter parameter ) => this.parameter = parameter;
			public IQuickReplyBuilder AddItem() => this;
			public IBuildOnlyMessageBuilder BuildQuickReply() => new MessageBuilder( this.parameter );
		}


		private class MessageSender : IMessageSender {
			private Parameter parameter;
			public MessageSender( Parameter parameter ) => this.parameter = parameter;
			public void Reply( string replyToken ) { }
			public void Push() { }
		}

	}

}

namespace HogeHoge {
	public class Hoge {
		static void Main() {
			MessageBuilderBase.CreateMessageBuilder("").Add("").Add("").Build().Reply( "" );
			MessageBuilderBase.CreateMessageBuilder( "" ).Build(); // NG
			MessageBuilderBase.CreateMessageBuilder( "" ).Build().Add(); // NG
			MessageBuilderBase.CreateMessageBuilder( "" ).Add("").Reply(); // NG
			new MessageBuilderBase.MessageBuilder( null ); // NG
			new MessageBuilderBase.MessageSender( new MessageBuilderBase.Parameter() ); // NG

			// NG
			MessageBuilderBase.CreateMessageBuilder( "" )
				.AddQuickReply().AddItem().AddItem().BuildQuickReply()
				.Add("")
				.Add("")
				.Build().Reply( "" );
			// NG
			MessageBuilderBase.CreateMessageBuilder( "" )
				.Add( "" )
				.AddQuickReply().AddItem().AddItem().BuildQuickReply()
				.Add( "" )
				.Build().Reply( "" );
			// OK
			MessageBuilderBase.CreateMessageBuilder( "" )
				.Add( "" )
				.Add( "" )
				.AddQuickReply().AddItem().AddItem().BuildQuickReply()
				.Build().Reply( "" );
			// NG
			MessageBuilderBase.CreateMessageBuilder( "" )
				.AddQuickReply().AddItem().AddItem().BuildQuickReply()
				.Build().Reply( "" );

		}
	}
}