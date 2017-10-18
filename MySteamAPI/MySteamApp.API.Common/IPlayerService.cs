using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MySteamApp.API.Common
{
    public interface IPlayerService
    {
		/// <summary>
		/// Return a list of games owned by the player
		/// </summary>
		/// <param name="steamId">The player we're asking about</param>
		/// <param name="includeAppInfo">DEFAULT: FALSE - Do we want addition details (name, icon, etc) about each game</param>
		/// <param name="includePlayedFreeGames">DEFAULT: FALSE - Do we want to include free games the player has playedt</param>
		/// <param name="appidsFilter">DEFAULT: NULL - If supplied an array of ids then the results will be restricted to the supplied ids</param>
		/// <returns>JSON formatted string</returns>
		Task<string> GetOwnedGamesAsync(string steamId, int includeAppInfo, int includePlayedFreeGames, int[] appidsFilter);
    }
}
