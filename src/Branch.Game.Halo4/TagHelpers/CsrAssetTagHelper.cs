using System.Text;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Halo.Core.DataContracts;

namespace Branch.Game.Halo4.TagHelpers
{
	public class CsrAssetTagHelper
		: TagHelper
	{
		public SkillRankDetailsFull SkillRank { get; set; }

		public int Height { get; set; }

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
		}
	}
}
