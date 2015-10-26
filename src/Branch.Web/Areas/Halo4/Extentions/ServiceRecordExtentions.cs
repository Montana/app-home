using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Branch.Web.Areas.Halo4.Extentions
{
	public static class ServiceRecordExtentions
	{
		public static string ToJavascriptArray(this IReadOnlyCollection<GameModeDetailsFull> gameModeDetails)
		{
			var javascriptObjectArray = new List<object>();

			foreach (var gameModeDetail in gameModeDetails)
			{
				javascriptObjectArray.Add(new
				{
					value = gameModeDetail.TotalGamesStarted,
					color = "#ccc",
					highlight = "#bbb",
					label = gameModeDetail.Name
				});
			}

			return JsonConvert.SerializeObject(javascriptObjectArray, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });
		}
	}
}
