using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Branch.Helpers.Services
{
	public enum HttpMethod
	{
		POST,
		GET,
		PUT,
		PATCH,
		DELETE
	}

	public class HttpManagerService
	{
		public async Task<T> ExecuteRequestAsync<T>(HttpMethod httpMethod, Uri requestUri,
			string userAgent = "Branch-vNext/1.0.0 (http;)", string accept = "application/json", Dictionary<string, string> headers = null, object payload = null)
			where T : class
		{
			using (var httpClient = new HttpClient(/*new ManagedHandler()*/))
			{
				// TODO: this properly

				var response = await httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
				var responseString = await response.Content.ReadAsStringAsync();
				var parsedResponse = JsonConvert.DeserializeObject<T>(responseString);
				return parsedResponse;
			}
		}
	}
}
