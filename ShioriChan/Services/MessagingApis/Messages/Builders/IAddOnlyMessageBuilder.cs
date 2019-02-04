using ShioriChan.Services.MessagingApis.Messages.Builders.Imagemaps;
using ShioriChan.Services.MessagingApis.Messages.Builders.Templates;

namespace ShioriChan.Services.MessagingApis.Messages.Builders {

	/// <summary>
	/// メッセージの追加のみができるMessageBuilder
	/// </summary>
	public interface IAddOnlyMessageBuilder {

		/// <summary>
		/// テキストメッセージ追加
		/// </summary>
		/// <param name="text">テキスト本文</param>
		/// <returns>MessageBuilder</returns>
		IMessageBuilder AddMessage( string text );

		/// <summary>
		/// スタンプメッセージ追加
		/// </summary>
		/// <param name="packageId">スタンプセットのパッケージID</param>
		/// <param name="stickerId">スタンプID</param>
		/// <returns>MessageBuilder</returns>
		IMessageBuilder AddSticker( string packageId , string stickerId );

		/// <summary>
		/// 画像メッセージ追加
		/// </summary>
		/// <param name="originalContentUrl">画像のURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <returns>MessageBuilder</returns>
		IMessageBuilder AddImage( string originalContentUrl , string previewImageUrl );

		/// <summary>
		/// 動画メッセージ追加
		/// </summary>
		/// <param name="originalContentUrl">動画ファイルのURL</param>
		/// <param name="previewImageUrl">プレビュー画像のURL</param>
		/// <returns>MessageBuilder</returns>
		IMessageBuilder AddVideo( string originalContentUrl , string previewImageUrl );

		/// <summary>
		/// 音声メッセージ追加
		/// </summary>
		/// <param name="originalContentUrl">音声ファイルのURL</param>
		/// <param name="duration">音声ファイルの長さ</param>
		/// <returns>MessageBuilder</returns>
		IMessageBuilder AddAudio( string originalContentUrl , int duration );

		/// <summary>
		/// 位置情報メッセージ追加
		/// </summary>
		/// <param name="title">タイトル</param>
		/// <param name="address">住所</param>
		/// <param name="latitude">緯度</param>
		/// <param name="longitude">経度</param>
		/// <returns>MessageBuilder</returns>
		IMessageBuilder AddLocation( string title , string address , double latitude , double longitude );

		/// <summary>
		/// イメージマップメッセージ追加
		/// </summary>
		/// <param name="baseUrl">画像のベースURL</param>
		/// <param name="altText">代替テキスト</param>
		/// <param name="baseSizeWidth">基本画像の幅</param>
		/// <param name="baseSizeHeight">基本画像の高さ</param>
		/// <returns>MessageBuilder</returns>
		ISettableVideoImagemapMessageBuilder AddImagemap( string baseUrl , string altText , int baseSizeWidth , int baseSizeHeight );

		/// <summary>
		/// テンプレート追加
		/// </summary>
		/// <param name="altText">代替テキスト</param>
		/// <param name="templateBuilder">テンプレートBuilder</param>
		/// <returns>テンプレート用Builder</returns>
		ISelectOnlyTemplateMessageBuilder AddTemplate( string altText );
		
		/// <summary>
		/// Flexメッセージ追加
		/// </summary>
		/// <param name="altText">代替テキスト</param>
		/// <returns>Flex用Builder</returns>
		IMessageBuilder AddFlexMessage( string altText );

	}

}
