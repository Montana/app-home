using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
			string userAgent = "Branch-vNext", string userAgentVersion = "1.0", string accept = "application/json", Dictionary<string, string> headers = null, object payload = null)
			where T : class
		{
			if (headers == null)
				headers = new Dictionary<string, string>();

			using (var httpClient = new HttpClient(/*new ManagedHandler()*/))
			{
				// TODO: this properly
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
				httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(
					new ProductHeaderValue(userAgent, userAgentVersion)));

				foreach (var header in headers)
					httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);

				try
				{
					HttpResponseMessage response = null;
					switch (httpMethod)
					{
						case HttpMethod.POST:
							response = await httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
							break;

						case HttpMethod.GET:
							response = await httpClient.GetAsync(requestUri);
							break;
					}

					var responseString = await response.Content.ReadAsStringAsync();
					var parsedResponse = JsonConvert.DeserializeObject<T>(responseString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

					return parsedResponse;
				}
				catch (JsonReaderException)
				{
					throw;
				}
				catch
				{
					return null;
				}
			}
		}
	}
}
