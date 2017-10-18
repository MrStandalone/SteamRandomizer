using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySteamApp.API.Common;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using MySteamApp.API.Core.Interfaces;
using MySteamApp.API.Core.Models;
using Newtonsoft.Json;

namespace MySteamApp.API.Core.Controllers
{
	[Route("api/[controller]")]
    public class PlayerServiceController : Controller//, IPlayerService
    {
		private IHttpClient _httpClient;
		
		public PlayerServiceController(IHttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		[HttpGet("GetOwnedGames")]
		public async Task<IActionResult> GetOwnedGamesAsync(GetOwnedGamesRequest model)
		{
			//Are we missing any required parameters and is the data supplied valid?
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
				Uri uri = new Uri("https://api.steampowered.com/IPlayerService/GetOwnedGames/v1" +
					string.Format("?key={0}&format={1}&input_json={2}", Config.ApiKey,
																	"json",
																	JsonConvert.SerializeObject(model)));
				
				using (var response = await _httpClient.GetAsync(uri))
				{
					if (response.IsSuccessStatusCode)
					{
						return Ok(await response.Content.ReadAsStringAsync());
					}
					else
					{
						return StatusCode(503, "Derp Derp Derp");
					}
				}
			}
		}

		/// <summary>
		/// Return a list of games owned by the player, underscores in parameter names to match up with Steam Web API
		/// TODO - Ensure response codes are appropriate
		/// TODO - Make testable
		/// </summary>
		/// <param name="steamId">The player we're asking about</param>
		/// <param name="includeAppInfo">DEFAULT: FALSE - Do we want addition details (name, icon, etc) about each game</param>
		/// <param name="includePlayedFreeGames">DEFAULT: FALSE - Do we want to include free games the player has playedt</param>
		/// <param name="appidsFilter">DEFAULT: NULL - If supplied an array of ids then the results will be restricted to the supplied ids</param>
		/// <returns>JSON formatted string</returns>
		/*[HttpGet("GetOwnedGames")]
		public async Task<HttpResponseMessage> GetOwnedGamesAsync(string steamId, int include_AppInfo = 0, int include_Played_Free_Games = 0, int[] appids_Filter = null)
		{
			//TODO - Keep track of errors and return them as part of the JSON Api Error Object

			if (string.IsNullOrEmpty(steamId))
				//TODO - Return JSON Api Error Object 
				return "Requires steamid parameter";

			var jsonArgs = new JObject()
			{
				new JProperty("steamid", steamId),
				new JProperty("include_appinfo", include_AppInfo),
				new JProperty("include_played_free_games", include_Played_Free_Games),
				new JProperty("appids_filter", new JArray(appids_Filter))
			};

			Uri uri = new Uri("https://api.steampowered.com/IPlayerService/GetOwnedGames/v1" +
				string.Format("?key={0}&format={1}&input_json={2}", Config.ApiKey,
																	"json",
																	jsonArgs.ToString()));

			HttpResponseMessage response;
			try
			{
				response = await _httpClient.GetAsync(uri);
			}
			//Should never occur, but better safe than sorry
			catch (ArgumentNullException nullExc)
			{
				//TODO - Return JSON Api Error Object
				return "Argument Null Exception";
			}
			catch (HttpRequestException reqExc)
			{
				//TODO - Return JSON Api Error Object
				return "Http Request Exception";
			}

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsStringAsync();
			}
			else
			{
				return "Something went wrong with this request";
			}
		}*/
	}
}