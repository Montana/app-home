using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Branch.Service.XboxLive.Database;

namespace Branch.Service.XboxLive.Migrations
{
	[DbContext(typeof(XboxLiveDbContext))]
	[Migration("20151016122956_InitalMigrationPostBeta8Upgrade")]
	partial class InitalMigrationPostBeta8Upgrade
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasAnnotation("ProductVersion", "7.0.0-beta8-15964")
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
