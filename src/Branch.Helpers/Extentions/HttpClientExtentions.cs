using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Branch.Helpers.Extentions
{
	public static class HttpClientExtentions
	{
		public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string magic, Uri requestUri, StringContent content)
		{
			var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content };
			return client.SendAsync(request);
		}

		public static Task<HttpResponseMessage> DeleteAsync(this HttpClient client, Uri requestUri)
		{
			var request = new HttpRequestMessage(new HttpMethod("DELETE"), requestUri);
			return client.SendAsync(request);
		}
	}
}
