using ShioriChan.Services.MessagingApis.Messages.Builders.Templates;
using ShioriChan.Services.MessagingApis.Messages.Senders;

namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// メッセージBuilder
	/// </summary>
	public partial class MessageBuilder : IMessageBuilder , IBuildOnlyMessageBuilder , ISettableVideoImagemapMessageBuilder, ISettableExternalLinkImageMapMessageBuilder {

		/// <summary>
		/// 送信用Parameter
		/// </summary>
		private MessageParameter parameter;

		/// <summary>
		/// コンストラクタ
		/// 直接インスタンスを生成してほしくないのでprivateにする
		/// </summary>
		/// <param name="parameter">送信用Parameter</param>
		private MessageBuilder( MessageParameter parameter ) => this.parameter = parameter;

		/// <summary>
		/// メッセージBuilder生成
		/// </summary>
		/// <param name="channelAccessToken">チャンネルアクセストークン</param>
		/// <returns>メッセージの追加のみができるMessageBuilder</returns>
		public static IAddOnlyMessageBuilder CreateMessageBuilder( string channelAccessToken )
			=> new MessageBuilder( new MessageParameter() { channelAccessToken = channelAccessToken } );

		/// <summary>
		/// クイックリプライ追加
		/// </summary>
		/// <returns>Item追加のみができるQuickReplyBuilder</returns>
		public IAddOnlyQuickReplyBuilder AddQuickReply()
			=> new QuickReplyBuilder( this.parameter );

		/// <summary>
		/// テキストメッセージ追加
		/// </summary>
		/// <param name="text">テキスト本文</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		public IMessageBuilder AddMessage( string text )
			=> this;

		/// <summary>
		/// スタンプメッセージ追加
		/// </summary>
		/// <param name="packageId">スタンプセットのパッケージID</param>
		/// <param name="stickerId">スタンプID</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		public IMessageBuilder AddSticker( string packageId , string stickerId )
			=> this;

		/// <summary>
		/// 画像メッセージ追加
		/// </summary>
		/// <param name="originalContentUrl">画像のURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		public IMessageBuilder AddImage( string originalContentUrl , string previewImageUrl )
			=> this;

		/// <summary>
		/// 動画メッセージ追加
		/// </summary>
		/// <param name="originalContentUrl">動画ファイルのURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		public IMessageBuilder AddVideo( string originalContentUrl , string previewImageUrl )
			=> this;

		/// <summary>
		/// 音声メッセージ追加
		/// </summary>
		/// <param name="originalContentUrl">音声ファイルのURL</param>
		/// <param name="duration">音声ファイルの長さ</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		public IMessageBuilder AddAudio( string originalContentUrl , int duration )
			=> this;

		/// <summary>
		/// 位置情報メッセージ追加
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <param name="address">住所</param>
		/// <param name="latitude">緯度</param>
		/// <param name="longitude">経度</param>
		/// <returns>ビルド可能な自身の子クラス</returns>
		public IMessageBuilder AddLocation(
			string title ,
			string address ,
			double latitude ,
			double longitude
		)
			=> this;

		/// <summary>
		/// イメージマップメッセージ追加
		/// </summary>
		/// <param name="baseUrl">画像のベースURL</param>
		/// <param name="altText">代替テキスト</param>
		/// <param name="baseSizeWidth">基本画像の幅</param>
		/// <param name="baseSizeHeight">基本画像の高さ</param>
		/// <returns>ビルド可能でイメージマップで動画を再生できる自身の子クラス</returns>
		public ISettableVideoImagemapMessageBuilder AddImagemap(
			string baseUrl ,
			string altText ,
			int baseSizeWidth ,
			int baseSizeHeight
		)
			=> this;

		/// <summary>
		/// イメージマップで動画を再生する
		/// </summary>
		/// <param name="originalContentUrl">動画ファイルのURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <param name="areaX">動画領域の位置</param>
		/// <param name="areaY">動画領域の位置</param>
		/// <param name="areaWidth">動画領域の幅</param>
		/// <param name="areaHeight">動画領域の高さ</param>
		/// <returns>イメージマップで動画再生後にラベルを表示できるMessageBuilder</returns>
		public ISettableExternalLinkImageMapMessageBuilder SetVideo(
			string originalContentUrl ,
			string previewImageUrl ,
			int areaX ,
			int areaY ,
			int areaWidth ,
			int areaHeight
		)
			=> this;

		/// <summary>
		/// 動画再生後にラベルを表示する
		/// </summary>
		/// <param name="url">ウェブページのURL</param>
		/// <param name="label">ラベル</param>
		/// <returns>送信可能なメッセージBuilder</returns>
		public IMessageBuilder SetExternalLink( string url , string label )
			=> this;

		/// <summary>
		/// テンプレート追加
		/// </summary>
		/// <param name="altText">代替テキスト</param>
		/// <param name="templateBuilder">テンプレートBuilder</param>
		/// <returns>テンプレート選択のみ可能なTemplateBuilder</returns>
		public ISelectOnlyTemplateMessageBuilder AddTemplate( string altText )
			=> new TemplateMessageBuilder( this.parameter );

		/// <summary>
		/// Flexメッセージ追加
		/// </summary>
		/// <param name="altText">代替テキスト</param>
		/// <returns>Flex用Builder</returns>
		public IMessageBuilder AddFlexMessage( string altText )
			=> this;

		/// <summary>
		/// メッセージのBuild
		/// </summary>
		/// <returns>メッセージ送信クラス</returns>
		public IMessageSender BuildMessage()
			=> new MessageSender( this.parameter );

	}

}
