﻿using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders;
using ShioriChan.Services.MessagingApis.Messages.BuilderFactories.Builders.QuickReplies;

namespace ShioriChan.Services.MessagingApis.Messages.BuilderFactories {
	public static partial class MessageBuilderFactory {

		/// <summary>
		/// QuickReply用Builder
		/// MessageBuilderFactory内でしか使わないのでprivateとする
		/// </summary>
		private class QuickReplyBuilder :
			IBuildOrAddItemOfQuickReply,
			ISelectOnlyActionOfQuickReply,
			ISettableDatepickerActionOfQuickReply 
		{

			/// <summary>
			/// 送信用Parameter
			/// </summary>
			private readonly MessageParameter parameter;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="parameter">送信用Parameter</param>
			public QuickReplyBuilder( MessageParameter parameter )
				=> this.parameter = parameter;

			/// <summary>
			/// アイテムの追加
			/// </summary>
			/// <param name="imageUrl">ボタンの先頭に表示するアイコン</param>
			/// <returns>QuickReplyのアクション設定クラス</returns>
			public ISelectOnlyActionOfQuickReply AddItem( string imageUrl )
				=> this;

			/// <summary>
			/// ポストバックアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <param name="data">データ</param>
			/// <param name="displayText">表示テキスト</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UsePostbackAction( string label , string data , string displayText )
				=> this;

			/// <summary>
			/// メッセージアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseMessageAction( string label , string text )
				=> this;

			/// <summary>
			/// 日時選択アクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <param name="data">データ</param>
			/// <param name="mode">モード</param>
			/// <returns>任意項目について設定可能なQuickReply用Builder</returns>
			public ISettableDatepickerActionOfQuickReply UseDatepickerAction( string label , string data , string mode )
				=> this;

			/// <summary>
			/// カメラアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseCameraAction( string label )
				=> this;

			/// <summary>
			/// カメラロールアクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseCameraRoll( string label )
				=> this;

			/// <summary>
			/// 位置情報アクションを使用する
			/// </summary>
			/// <param name="label">ラベル</param>
			/// <returns>ビルド可能なQuickReply用Builder</returns>
			public IBuildOrAddItemOfQuickReply UseLocation( string label )
				=> this;

			/// <summary>
			/// 日付または時刻の初期値設定
			/// </summary>
			/// <param name="initial">日付または時刻の初期値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionOfQuickReply SetInitial( string initial )
				=> this;

			/// <summary>
			/// 選択可能な日付または時刻の最大値設定
			/// </summary>
			/// <param name="max">選択可能な日付または時刻の最大値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionOfQuickReply SetMax( string max )
				=> this;

			/// <summary>
			/// 選択可能な日付または時刻の最小値設定
			/// </summary>
			/// <param name="min">選択可能な日付または時刻の最小値</param>
			/// <returns>自身のBuilderクラス</returns>
			public ISettableDatepickerActionOfQuickReply SetMin( string min ) {

				this.parameter.q.min = min;

				return this;
			}

			/// <summary>
			/// QuickReplyのBuild
			/// </summary>
			/// <returns>ビルドしかできないMessageBuilder</returns>
			public IBuildOnlyOfMessageBuilder BuildQuickReply() => new MessageBuilder( this.parameter );

		}

	}

}
