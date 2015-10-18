using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Branch.Service.XboxLive.Database;

namespace Branch.Service.XboxLive.Migrations
{
	[DbContext(typeof(XboxLiveDbContext))]
	partial class XboxLiveDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Annotation("ProductVersion", "7.0.0-beta8-15964")
				.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Branch.Service.XboxLive.Database.Models.Authentication", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<DateTime>("CreatedAt");

					b.Property<DateTime>("ExpiresAt");

					b.Property<string>("Gamertag");

					b.Property<string>("Token");

					b.Property<DateTime>("UpdatedAt");

					b.Property<string>("UserHash");

					b.Property<long>("Xuid");

					b.HasKey("Id");
				});
		}
	}
}
