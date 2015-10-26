using System.Text;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Branch.Web.TagHelpers
{
	public enum AreaTypes
	{
		XboxLive,
		HaloReach,
		Halo4,
		Halo5Guardians
	}

	public class AreaSwitcherTagHelper
		: TagHelper
	{
		public string Gamertag { get; set; }

		public AreaTypes ActiveAreaType { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var sb = new StringBuilder();

			sb.AppendFormat("<article class=\"area-switcher\">");
				sb.AppendFormat("<div class=\"container\">");
					sb.AppendFormat("<div class=\"selector-nav\">");
						sb.AppendFormat("<ul class=\"nav-of-bar\">");
							sb.AppendFormat("<li class=\"{0}\">", ActiveAreaType == AreaTypes.XboxLive ? "active" : "");
								sb.AppendFormat("<a class=\"plain\" href=\"/Xbox/{0}/\">Xbox</a>", Gamertag);
							sb.AppendFormat("</li>");
							sb.AppendFormat("<li class=\"{0}\">", ActiveAreaType == AreaTypes.HaloReach ? "active" : "");
								sb.AppendFormat("<a class=\"plain\" href=\"/Xbox/{0}/Reach\">Halo: Reach</a>", Gamertag);
							sb.AppendFormat("</li>");
							sb.AppendFormat("<li class=\"{0}\">", ActiveAreaType == AreaTypes.Halo4 ? "active" : "");
								sb.AppendFormat("<a class=\"plain\" href=\"/Xbox/{0}/Halo4\">Halo 4</a>", Gamertag);
							sb.AppendFormat("</li>");
							sb.AppendFormat("<li class=\"{0}\">", ActiveAreaType == AreaTypes.Halo5Guardians ? "active" : "");
								sb.AppendFormat("<a class=\"plain\" href=\"/Xbox/{0}/Halo5\">Halo 5</a>", Gamertag);
							sb.AppendFormat("</li>");
						sb.AppendFormat("</ul>");
					sb.AppendFormat("</div>");
				sb.AppendFormat("</div>");
			sb.AppendFormat("</article>");

			output.Content.Append(sb.ToString());
		}
	}
}
