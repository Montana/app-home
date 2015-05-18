using System;
using System.Net;
using System.Threading.Tasks;
using Branch.Helpers.Services;
using Xunit;

namespace Branch.Helpers.Test.Services
{
	public class HttpManagerServiceTests
	{
		[Fact]
		public async Task Execute_get_request()
		{
			var httpManagerService = new HttpManagerService();
			var response = await httpManagerService.ExecuteRequestAsync(HttpMethod.GET, new Uri("http://google.com"));

			Assert.Equal(response.StatusCode, HttpStatusCode.OK);
		}
	}
}
