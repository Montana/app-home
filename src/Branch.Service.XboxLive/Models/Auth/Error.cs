using Newtonsoft.Json;

namespace Branch.Service.XboxLive.Models.Auth
{
	public class Error
	{
		public string Description { get; set; }
		
		public string Details { get; set; }
	}
}
