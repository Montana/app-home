using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Branch.Web.Areas.Halo4.Extentions
{
	public static class ServiceRecordExtentions
	{
		public static string ToJavascriptArray(this IReadOnlyCollection<GameModeDetailsFull> gameModeDetails, string[] colours)
		{
			var javascriptObjectArray = new List<object>();

			var index = 0;
			foreach (var gameModeDetail in gameModeDetails)
			{
				javascriptObjectArray.Add(new
				{
					value = gameModeDetail.TotalGamesStarted,
					color = colours[index],
					label = gameModeDetail.Name
				});

				index++;
			}

			return JsonConvert.SerializeObject(javascriptObjectArray, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });
		}
	}
}
