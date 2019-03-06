using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;
using ShioriChan.Repositories.Rooms;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies;
using System;
using System.Collections.Generic;
using System.Linq;
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
		/// 部屋情報Repository
		/// </summary>
		private readonly RoomRepository roomRepository;
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="roomRepository">部屋情報Repository</param>
		public RoomService(
			ILogger<RoomService> logger ,
			IMessageService messageService,
			RoomRepository roomRepository
		) {
			this.logger = logger;
			this.messageService = messageService;
			this.roomRepository = roomRepository;
		}

		/// <summary>
		/// ユーザIDを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ユーザID</returns>
		private string GetUserId( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken source = firstEvent[ "source" ];
			string userId = source[ "userId" ].ToString();
			this.logger.LogTrace( $"User Id is {userId}." );

			return userId;
		}

		/// <summary>
		/// リプライトークンを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>リプライトークン</returns>
		private string GetReplyToken( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			string replyToken = firstEvent[ "replyToken" ].ToString();
			this.logger.LogTrace( $"Reply Token is {replyToken}." );

			return replyToken;
		}

		/// <summary>
		/// ポストバックデータを取得
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ポストバックデータ</returns>
		private string GetPostbackData( JToken parameter ) {
			JArray events = (JArray)parameter[ "events" ];
			JObject firstEvent = (JObject)events[ 0 ];

			JToken postback = firstEvent[ "postback" ];
			string data = postback[ "data" ].ToString();
			this.logger.LogTrace( $"Postback Data is {data}." );
			return data;
		}

		/// <summary>
		/// 自分の部屋番号を取得
		/// </summary>
		/// <param name="userId">ユーザID</param>
		/// <returns>自分の部屋番号</returns>
		private string GetMyRoomNumber( string userId ) {
			// TODO 仮　実際はDBより取得
			string roomNumber = "202";
			this.logger.LogTrace( $"Room Number is {roomNumber}." );
			return roomNumber;
		}

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
		/// 鍵を持っているメンバーを更新する
		/// </summary>
		/// <param name="roomNumber">部屋番号</param>
		/// <param name="userSeq">鍵を持っているユーザシーケンス</param>
		private void UpdateHavingKeyUser( string roomNumber , int userSeq ) {
			// TODO 実際はDBを更新
		}
		
		/// <summary>
		/// 同じ部屋のメンバーを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ShowRoomMember( JToken parameter ) {
			this.logger.LogTrace( "Start" );

			string userId = this.GetUserId( parameter );
			string replyToken = this.GetReplyToken( parameter );

			string myRoomNumber = this.GetMyRoomNumber( userId );
			if( string.IsNullOrEmpty( myRoomNumber ) ) {
				this.logger.LogError( "User Id Target Does Not Exist." );
				this.logger.LogTrace( "End" );
				return;
			}

			// メンバー一覧にフロントを追加
			List<User> members = this.GetRoomMembers( myRoomNumber );
			members.Add( new User() {
				Seq = -1 ,
				Name = "フロント" ,
				IsHavingKey = !members.Any( member => member.IsHavingKey == true ) // 鍵を持っているメンバーが一人でもいればフロントがカギを持っていることになる
			} );

			string havingKeyUserName = members.FirstOrDefault( member => member.IsHavingKey ).Name;
			this.logger.LogTrace( $"Having Key User Name is {havingKeyUserName}." );

			IAddOnlyItemOfQuickReply quickReplyBuilder = this.messageService.CreateMessageBuilder()
				.AddMessage(
					$"{myRoomNumber}号室の情報です。\n" +
					$"今鍵を持っているのは{havingKeyUserName}です！\n" +
					"下のボタンでいつでも鍵を持っている人を切り替えれます！"
				)
				.AddQuickReply();

			IBuildOrAddItemOfQuickReply buildableQuickReplyBuilder = null;
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
		public async Task ChangeHavingKeyUser( JToken parameter ) {
			this.logger.LogTrace( "Start" );

			string postbackData = this.GetPostbackData( parameter );

			string roomNumber = "";
			int userSeq = -1;
			{
				string[] keyValue = postbackData.Split( "&" );
				userSeq = int.Parse( keyValue[ 0 ].Split( "=" )[ 1 ] );
				roomNumber = keyValue[ 1 ].Split( "=" )[ 1 ];
			}
			this.logger.LogTrace( $"Room Number is {roomNumber}." );
			this.logger.LogTrace( $"User Seq is {userSeq}." );

			string replyToken = this.GetReplyToken( parameter );

			this.UpdateHavingKeyUser( roomNumber , userSeq );

			List<User> members = this.GetRoomMembers( roomNumber );
			string havingKeyUserName = members.First( member => member.IsHavingKey == true )?.Name;
			havingKeyUserName = havingKeyUserName is null ? "フロント" : havingKeyUserName + "さん";
			this.logger.LogTrace( $"Having Key User Name is {havingKeyUserName}." );

			await this.messageService.CreateMessageBuilder()
				.AddMessage( $"{havingKeyUserName}がカギを持ってるんですね！\n承知しました！" )
				.BuildMessage()
				.Reply( replyToken );

			this.logger.LogTrace( "End" );
			return;
		}

/*
this.logger.LogTrace( "Seq Show Start" );
try {
	DbSet<Room> rooms = this.roomRepository.Rooms;
	this.logger.LogTrace( "Rooms!" );
	List<Room> roomList = await rooms.ToListAsync();
	this.logger.LogTrace( "RoomList!" );
	this.logger.LogTrace( "Room List Count is " + roomList.Count );

	roomList.ForEach( room => this.logger.LogInformation( $"Seq is {room.Seq}" ) );
}
catch( Exception e ) {
	this.logger.LogError( "{e}" , e );
}
this.logger.LogTrace( "Seq Show End" );
*/


	}

}
