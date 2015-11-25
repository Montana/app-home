using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Branch.Service.Halo5.Database;

namespace Branch.Service.Halo5.Migrations
{
    [DbContext(typeof(Halo5DbContext))]
    partial class Halo5DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-beta8-15964")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Branch.Service.Halo5.Database.Models.Authentication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnalyticsToken");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ExpiresAt");

                    b.Property<string>("Gamertag");

                    b.Property<string>("SpartanToken");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo5.Database.Models.GameVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ContentId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<Guid>("GameBaseVariantId");

                    b.Property<Guid>("GameVariantId");

                    b.Property<string>("IconUrl");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo5.Database.Models.MapVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ContentId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<Guid>("MapId");

                    b.Property<string>("MapImageUrl");

                    b.Property<Guid>("MapVariantId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo5.Database.Models.MatchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DocumentId");

                    b.Property<int>("Mode");

                    b.Property<int>("Start");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<long>("Xuid");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo5.Database.Models.ProfileAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Crop");

                    b.Property<string>("ImagePath");

                    b.Property<int>("Size");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<long>("Xuid");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo5.Database.Models.ServiceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DocumentId");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<long>("Xuid");

                    b.HasKey("Id");
                });
        }
    }
}
