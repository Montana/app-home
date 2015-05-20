using System.Text;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Branch.Service.XboxLive.TagHelpers
{
	public class WatermarksTagHelper
		: TagHelper
	{
		[HtmlAttributeName("watermarks")]
		public string Watermarks { get; set; }

		[HtmlAttributeName("height")]
		public int Height { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var sb = new StringBuilder();

			sb.AppendFormat("<ul>");
			foreach (var watermark in Watermarks.Split('|'))
			{
				sb.AppendFormat("<li>");
					sb.AppendFormat("<img height=\"{0}\" src=\"http://dlassets.xboxlive.com/public/content/ppl/watermarks/launch/{1}.png\" />", Height, watermark);
				sb.AppendFormat("</li>");
			}
			sb.AppendFormat("</ul>");

			output.Content.Append(sb.ToString());
		}
	}
}
