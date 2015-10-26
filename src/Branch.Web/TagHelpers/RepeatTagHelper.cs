using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Branch.Web.TagHelpers
{
	public class RepeatTagHelper
		: TagHelper
	{
		public int Count { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (Count <= 0)
				return;

			for (var i = 0; i < Count; i++)
			{
				var content = await context.GetChildContentAsync();
				output.Content.Append(content);
			}
		}
	}
}
