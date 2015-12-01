using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Branch.Service.Halo5.Migrations
{
    public partial class AddedPlayerModelAndUpdatedServiceRecordModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ServiceTag = table.Column<string>(nullable: true),
                    SpartanRank = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Xp = table.Column<long>(nullable: false),
                    Xuid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });
            migrationBuilder.AddColumn<int>(
                name: "TotalDamage",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "TotalDeaths",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "TotalGamesStarted",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "TotalGamesWon",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "TotalKills",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalPlaytime",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "TotalDamage", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalDeaths", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalGamesStarted", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalGamesWon", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalKills", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalPlaytime", table: "ServiceRecord");
            migrationBuilder.DropTable("Player");
        }
    }
}
