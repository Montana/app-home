using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Branch.Service.Xuid.Database;

namespace Branch.Service.Xuid.Migrations
{
    [DbContext(typeof(XuidDbContext))]
    [Migration("20151019103438_AddedXuidCacheTable")]
    partial class AddedXuidCacheTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Branch.Service.Xuid.Database.Models.Authentication", b =>
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

            modelBuilder.Entity("Branch.Service.Xuid.Database.Models.XuidCache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ExpiresAt");

                    b.Property<string>("Gamertag");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<long>("Xuid");

                    b.HasKey("Id");
                });
        }
    }
}