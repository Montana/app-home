using Microsoft.AspNet.Razor.TagHelpers;
using System;

namespace Branch.Web.TagHelpers
{
	[HtmlTargetElement("deliminate-number", Attributes = "integer", TagStructure = TagStructure.NormalOrSelfClosing)]
	public class DeliminateNumberTagHelper
		: TagHelper
	{
		public Int64 Integer { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "span";
			output.TagMode = TagMode.StartTagAndEndTag;
			output.Content.SetContent(Integer >= 1000 ? Integer.ToString("n0") : Integer.ToString("d"));
		}
	}
}

