using System.Text;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Area.Halo4.TagHelpers
{
	[HtmlTargetElement("csr-asset", Attributes = SkillRankAttributeName)]
	[HtmlTargetElement("csr-asset", Attributes = HeightAttributeName)]
	[HtmlTargetElement("csr-asset", Attributes = GamertagAttributeName)]
	public class CsrAssetTagHelper
		: TagHelper
	{
		private const string SkillRankAttributeName = "skill-rank";
		private const string HeightAttributeName = "height";
		private const string GamertagAttributeName = "gamertag";

		[HtmlAttributeName(SkillRankAttributeName)]
		public SkillRankDetailsFull SkillRank { get; set; }

		[HtmlAttributeName(HeightAttributeName)]
		public int Height { get; set; }

		[HtmlAttributeName(GamertagAttributeName)]
		public string Gamertag { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var sb = new StringBuilder();

			if (SkillRank != null)
				sb.Append($"<a href=\"#{Gamertag}/{SkillRank.PlaylistId}-{SkillRank.PlaylistName}\">");

			sb.Append($"<img alt=\"Player's CSR rating\" height=\"{Height}\" src=\"https://assets.halowaypoint.com/games/h4/csr/v1/large/{SkillRank?.CurrentSkillRank ?? 0}.png\" />");

			if (SkillRank != null)
				sb.Append($"</a>");

			output.Content.Append(sb.ToString());

			base.Process(context, output);
		}
	}
}
