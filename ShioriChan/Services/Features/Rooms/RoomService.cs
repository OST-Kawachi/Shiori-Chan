using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.QuickReplies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShioriChan.Services.Features.Rooms {

	/// <summary>
	/// 部屋情報
	/// </summary>
	public class RoomService : IRoomService {

		// TODO 仮データ
		private class User {
			public int Seq { set; get; }
			public string Name { set; get; }
			public bool IsHavingKey { set; get; }
		}

		/// <summary>
		/// ログ
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// メッセージ用Service
		/// </summary>
		private readonly IMessageService messageService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		public RoomService(
			ILogger<FeatureFacade> logger ,
			IMessageService messageService
		) {
			this.logger = logger;
			this.messageService = messageService;
		}

		/// <summary>
		/// ユーザIDを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ユーザID</returns>
		private string GetUserId( JToken parameter )
			// TODO 仮　実際はパラメータより取得
			=> "";

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter )
			// TODO 仮　実際はパラメータより取得
			=> "";

		/// <summary>
		/// 自分の部屋番号を取得
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>自分の部屋番号</returns>
		private string GetMyRoomNumber( string userId )
			// TODO 仮　実際はDBより取得
			=> "202";

		/// <summary>
		/// 指定した部屋番号のメンバーを取得する
		/// </summary>
		/// <param name="roomNumber">部屋番号</param>
		/// <returns>指定した部屋番号のメンバー一覧</returns>
		private List<User> GetRoomMembers( string roomNumber ) {
			// TODO 仮　実際はDBより取得

			List<User> members = new List<User>();

			//ログ
			#region ログ
			this.logger.LogTrace( $"Members Count is { members.Count }" );
			members.ForEach( member => {
				this.logger.LogTrace( "====================" );
				this.logger.LogTrace( $"User Seq is {member.Seq}" );
				this.logger.LogTrace( $"User Name is {member.Name}" );
				this.logger.LogTrace( $"Having Key is {member.IsHavingKey}" );
			} );
			this.logger.LogTrace( "====================" );
			#endregion

			return members;
		}



		/// <summary>
		/// 同じ部屋のメンバーを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ChangeHavingKeyUser( JToken parameter ) {
			this.logger.LogTrace( "Start" );

			string userId = this.GetUserId( parameter );
			string replyToken = this.GetReplyToken( parameter );

			string myRoomNumber = this.GetMyRoomNumber( userId );
			if( string.IsNullOrEmpty( myRoomNumber ) ) {
				this.logger.LogError( "User Id Target Does Not Exist." );
				this.logger.LogTrace( "End" );
				return;
			}

			List<User> members = this.GetRoomMembers( myRoomNumber );

			// メンバー一覧にフロントを追加

			// 鍵を持っている人の名前
			string havingKeyUserName = "";

			// リプライ送信
			IAddOnlyQuickReplyBuilder quickReplyBuilder = this.messageService.CreateMessageBuilder()
				.AddMessage(
					$"{myRoomNumber}号室の情報です。\n" +
					$"今鍵を持っているのは{havingKeyUserName}です！\n" +
					"下のボタンでいつでも鍵を持っている人を切り替えれます！"
				)

				// TODO 仮 とりあえずtemplateが完成するまではQuickReplyで代用
				.AddMessage(
					$"{myRoomNumber}号室について\n" +
					$"{havingKeyUserName}がカギを持ってます"
				)
				.AddQuickReply();

			IQuickReplyBuilder buildableQuickReplyBuilder = null;
			foreach( User member in members ) {
				// 初回のみビルドできるインタフェースに変更する
				if( buildableQuickReplyBuilder is null ) {
					buildableQuickReplyBuilder = quickReplyBuilder.AddItem( "" ).UsePostbackAction(
						member.Name ,
						"changeHasKey=" + member.Seq + "&roomNumber=" + myRoomNumber ,
						member.Name + "がカギを持ってます"
					);
				}
				// 2回目以降はインスタンスを上書きしていく
				// TODO 上書きする必要があるのかどうか未確認
				else {
					buildableQuickReplyBuilder = buildableQuickReplyBuilder.AddItem("").UsePostbackAction(
						member.Name ,
						"changeHasKey=" + member.Seq + "&roomNumber=" + myRoomNumber ,
						member.Name + "がカギを持ってます"
					);
				}
			}
			await buildableQuickReplyBuilder
				.BuildQuickReply()
				.BuildMessage()
				.Reply( replyToken );
			
			this.logger.LogTrace( "End" );
			return;

		}

		/// <summary>
		/// 鍵を持っているメンバーを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ShowRoomMember( JToken parameter ) {
		}
		
	}

}

/*

	// フロント追加　鍵を持っているメンバーの名前を取得
	string havingKeyMember = "フロント";
	{
		bool isFlontHavingKey = true;
		foreach( Member member in members ) {
			if( member.isHavingKey ) {
				havingKeyMember = member.name + "さん";
				isFlontHavingKey = false;
				break;
			}
		}
		members.Add(
			new Member() {
				userSeq = -1 ,
				name = "フロント" ,
				isHavingKey = isFlontHavingKey
			}
		);
	}

	JObject replyRequestBody = new JObject();
	replyRequestBody[ "replyToken" ] = replyToken;

	JArray messages = new JArray();


	// secondMessage作成
	{
	
		JObject template = new JObject();
		template[ "type" ] = "carousel";

		// カラムにつくアクションの数は統一しなければならない
		int actionNumber;
		if( members.Count % 3 == 0 )
			actionNumber = 3;
		else if( members.Count % 2 == 0 )
			actionNumber = 2;
		else
			actionNumber = 1;

		JArray columns = new JArray();
		// 1カラムにアクション数分ボタンを表示
		for( int i = 0 ; i < members.Count / actionNumber + ( members.Count % actionNumber == 0 ? 0 : 1 ) ; i++ ) {
			JObject column = new JObject();
			column[ "text" ] = "鍵を持っている人を変更できます";
			JArray actions = new JArray();

			for( int j = i * actionNumber, count = 0 ; j < members.Count && count < actionNumber ; j++, count++ ) {
				JObject action = new JObject();
				action[ "type" ] = "postback";
				action[ "label" ] = members[ j ].name;
				action[ "displayText" ] = members[ j ].name + "がカギを持ってます";
				action[ "data" ] = "changeHasKey=" + members[ j ].userSeq + "&roomNumber=" + myRoomNumber;
				actions.Add( action );
			}
			column[ "actions" ] = actions;
			columns.Add( column );

		}
		template[ "columns" ] = columns;

		secondMessage[ "template" ] = template;

		messages.Add( secondMessage );

	}
	

	*/
