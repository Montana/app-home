using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Branch.Service.Halo5.Database;

namespace Branch.Service.Halo5.Migrations
{
    [DbContext(typeof(Halo5DbContext))]
    [Migration("20151115130418_CreatedProfileAssetModels")]
    partial class CreatedProfileAssetModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Branch.Service.Halo5.Database.Models.ProfileAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ImagePath");

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
