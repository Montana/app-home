using System.Text;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.TagHelpers
{
	[HtmlTargetElement("csr-asset", Attributes = nameof(SkillRank))]
	[HtmlTargetElement("csr-asset", Attributes = nameof(Height))]
	[HtmlTargetElement("csr-asset", Attributes = nameof(Gamertag))]
	public class CsrAssetTagHelper
		: TagHelper
	{
		private const string SkillRankAttributeName = "skill-rank";
		private const string HeightAttributeName = "height";
		private const string GamertagAttributeName = "gamertag";
		
		public SkillRankDetailsFull SkillRank { get; set; }
		
		public int Height { get; set; }
		
		public string Gamertag { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "img";
			output.Attributes["alt"] = "Player's CSR rating";
			output.Attributes["height"] = Height.ToString();
			output.Attributes["src"] = $"https://assets.halowaypoint.com/games/h4/csr/v1/large/{SkillRank?.CurrentSkillRank ?? 0}.png";

			if (SkillRank != null)
			{
				output.PreContent.SetContent($"<a href=\"#{Gamertag}/{SkillRank.PlaylistId}-{SkillRank.PlaylistName}\">");
				output.PostContent.SetContent("</a>");
			}
		}
	}
}
