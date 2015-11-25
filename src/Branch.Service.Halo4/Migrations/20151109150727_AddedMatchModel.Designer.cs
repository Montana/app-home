using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Branch.Service.Halo4.Database;

namespace Branch.Service.Halo4.Migrations
{
    [DbContext(typeof(Halo4DbContext))]
    [Migration("20151109150727_AddedMatchModel")]
    partial class AddedMatchModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-beta8-15964")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.Authentication", b =>
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

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.Commendations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DocumentId");

                    b.Property<int>("ServiceRecordId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.GameHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DocumentId");

                    b.Property<int?>("GameMode");

                    b.Property<int>("ServiceRecordId");

                    b.Property<int>("StartAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DocumentId");

                    b.Property<int>("GameMode");

                    b.Property<string>("MatchId");

                    b.Property<int?>("ServiceRecordId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.Metadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DocumentId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.ServiceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommendationsId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DocumentId");

                    b.Property<int?>("MatchId");

                    b.Property<string>("ServiceTag");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<long>("Xuid");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.GameHistory", b =>
                {
                    b.HasOne("Branch.Service.Halo4.Database.Models.ServiceRecord")
                        .WithMany()
                        .HasForeignKey("ServiceRecordId");
                });

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.Match", b =>
                {
                    b.HasOne("Branch.Service.Halo4.Database.Models.ServiceRecord")
                        .WithMany()
                        .HasForeignKey("ServiceRecordId");
                });

            modelBuilder.Entity("Branch.Service.Halo4.Database.Models.ServiceRecord", b =>
                {
                    b.HasOne("Branch.Service.Halo4.Database.Models.Commendations")
                        .WithOne()
                        .HasForeignKey("Branch.Service.Halo4.Database.Models.ServiceRecord", "CommendationsId");

                    b.HasOne("Branch.Service.Halo4.Database.Models.Match")
                        .WithMany()
                        .HasForeignKey("MatchId");
                });
        }
    }
}
