using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySteamApp.API.Core.Models
{
    public class GetOwnedGamesRequest : IValidatableObject
    {
		[Required]
		public string SteamId { get; set; }
		public int? Include_AppInfo { get; set; }
		public int? Include_Played_Free_Games { get; set; }
		public int[] Appids_Filter { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Include_AppInfo != null && (Include_AppInfo < 0 || Include_AppInfo > 1))
			{
				yield return new ValidationResult("If 'include_appinfo' is included it must be a 1 or a 0", new[] { "Include_AppInfo" });
			}

			if (Include_Played_Free_Games != null && (Include_Played_Free_Games < 0 || Include_Played_Free_Games > 1))
			{
				yield return new ValidationResult("If 'include_played_free_games' is included in must be a 1 or a 0", new[] { "Include_Played_Free_Games" });
			}
			
			//throw new NotImplementedException();
		}
	}
}
