﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShioriChan.Entities;
using ShioriChan.Repositories.Rooms;
using ShioriChan.Services.MessagingApis.Messages;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShioriChan.Services.Features.Rooms {

	/// <summary>
	/// 部屋情報
	/// </summary>
	public class RoomService : IRoomService {

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
		private readonly IRoomRepository roomRepository;
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="logger">ログ</param>
		/// <param name="messageService">メッセージService</param>
		/// <param name="roomRepository">部屋情報Repository</param>
		public RoomService(
			ILogger<RoomService> logger ,
			IMessageService messageService,
			IRoomRepository roomRepository
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
			this.logger.LogDebug( $"User Id is {userId}." );

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
			this.logger.LogDebug( $"Reply Token is {replyToken}." );

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
			this.logger.LogDebug( $"Postback Data is {data}." );
			return data;
		}

		/// <summary>
		/// 同じ部屋のメンバーを表示する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ShowRoomMember( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string userId = this.GetUserId( parameter );
			string replyToken = this.GetReplyToken( parameter );
			this.logger.LogDebug($"User Id is {userId}");
			this.logger.LogDebug($"Reply Token is {replyToken}");

			Room myRoom = this.roomRepository.GetMyRoom( userId );
			string myRoomNumber = myRoom?.Number;
			if( string.IsNullOrEmpty( myRoomNumber ) ) {
				this.logger.LogError( "User Id Target Does Not Exist." );
				this.logger.LogTrace( "End" );
				return;
			}
			this.logger.LogDebug( $"My Room Number is {myRoomNumber}" );

			(List<UserInfo> members , int? havingKeyUserSeq ) = this.roomRepository.GetRoomMembers( myRoom.Seq );
			this.logger.LogDebug( $"Members Count is {members.Count}" );
			this.logger.LogDebug( $"Having Key User Seq is { havingKeyUserSeq ?? -1 }" );

			string havingKeyUserName = members.FirstOrDefault( member => havingKeyUserSeq.HasValue && havingKeyUserSeq.Value == member.Seq )?.Name ?? "フロント";
			if( !"フロント".Equals( havingKeyUserName ) ) {
				havingKeyUserName += "さん";
			}
			this.logger.LogDebug( $"Having Key User Name is {havingKeyUserName}" );

			IAddOnlyItemOfQuickReply quickReplyBuilder = this.messageService.CreateMessageBuilder()
				.AddMessage(
					$"{myRoomNumber}号室の情報です。\n" +
					$"今鍵を持っているのは{havingKeyUserName}です！\n" +
					"下のボタンでいつでも鍵を持っている人を切り替えれます！"
				)
				.AddQuickReply();

			IBuildOrAddItemOfQuickReply buildableQuickReplyBuilder = null;
			foreach( UserInfo member in members ) {
				// 初回のみビルドできるインタフェースに変更する
				buildableQuickReplyBuilder = buildableQuickReplyBuilder is null
					? quickReplyBuilder.AddItem( null ).UsePostbackAction(
						member.Name ,
						"changeHasKey=" + member.Seq + "&roomNumber=" + myRoom.Seq ,
						member.Name + "さんがカギを持ってます"
					)
					: buildableQuickReplyBuilder.AddItem( null ).UsePostbackAction(
						member.Name ,
						"changeHasKey=" + member.Seq + "&roomNumber=" + myRoom.Seq ,
						member.Name + "さんがカギを持ってます"
					);
			}
			// フロントの追加
			buildableQuickReplyBuilder = buildableQuickReplyBuilder.AddItem( null ).UsePostbackAction(
				"フロント" ,
				"changeHasKey=" + -1 + "&roomNumber=" + myRoom.Seq ,
				"フロントにカギを預けてます"
			);

			await buildableQuickReplyBuilder
				.BuildQuickReply()
				.BuildMessage()
				.Reply( replyToken );
			
			this.logger.LogInformation( "End" );
			return;

		}

		/// <summary>
		/// 鍵を持っているメンバーを変更する
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public async Task ChangeHavingKeyUser( JToken parameter ) {
			this.logger.LogInformation( "Start" );

			string postbackData = this.GetPostbackData( parameter );
			this.logger.LogDebug($"Postback Data is {postbackData}");

			int roomSeq = -1;
			int? userSeq = -1;
			{
				string[] keyValue = postbackData.Split( "&" );
				userSeq = int.Parse( keyValue[ 0 ].Split( "=" )[ 1 ] );
				roomSeq = int.Parse( keyValue[ 1 ].Split( "=" )[ 1 ] );
			}
			this.logger.LogDebug( $"Room Seq is {roomSeq}." );
			this.logger.LogDebug( $"User Seq is {userSeq}." );

			string replyToken = this.GetReplyToken( parameter );

			this.roomRepository.UpdateHavingKeyUser( roomSeq , userSeq == -1 ? null : userSeq );
			string havingKeyUserName = "フロント";

			if( userSeq != -1 ) {
				(List<UserInfo>users , int? havingKeyUserSeq) = this.roomRepository.GetRoomMembers( roomSeq );
				havingKeyUserName = users
					.FirstOrDefault( user => user.Seq == havingKeyUserSeq.Value )
					.Name + "さん";
			}

			this.logger.LogDebug( $"Having Key User Name is {havingKeyUserName}." );

			await this.messageService.CreateMessageBuilder()
				.AddMessage( $"{havingKeyUserName}がカギを持ってるんですね！\n承知しました！" )
				.BuildMessage()
				.Reply( replyToken );

			this.logger.LogInformation( "End" );
			return;
		}
		
	}

}
