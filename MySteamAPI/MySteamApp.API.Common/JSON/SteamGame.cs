using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = GettingStarted.FromJson(jsonString);
//

namespace MySteamApp.API.Common.JSON
{
	public partial class GetOwnedGamesResponse
	{
		[JsonProperty("game_count")]
		public long GameCount { get; set; }

		[JsonProperty("games")]
		public List<SteamGame> Games { get; set; }
	}

	public partial class SteamGame
	{
		[JsonProperty("img_logo_url")]
		public string ImgLogoUrl { get; set; }

		[JsonProperty("has_community_visible_stats")]
		public bool? HasCommunityVisibleStats { get; set; }

		[JsonProperty("appid")]
		public long Appid { get; set; }

		[JsonProperty("img_icon_url")]
		public string ImgIconUrl { get; set; }

		[JsonProperty("playtime_2weeks")]
		public long? Playtime2weeks { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("playtime_forever")]
		public long PlaytimeForever { get; set; }
	}
}
