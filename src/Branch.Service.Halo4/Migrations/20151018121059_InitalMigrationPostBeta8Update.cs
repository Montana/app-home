using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Branch.Service.Halo4.Migrations
{
    public partial class InitalMigrationPostBeta8Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnalyticsToken = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ExpiresAt = table.Column<DateTime>(nullable: false),
                    Gamertag = table.Column<string>(nullable: true),
                    SpartanToken = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ServiceRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DocumentId = table.Column<string>(nullable: true),
                    Gamertag = table.Column<string>(nullable: true),
                    ServiceTag = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecord", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "GameHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DocumentId = table.Column<string>(nullable: true),
                    GameMode = table.Column<int>(nullable: true),
                    ServiceRecordId = table.Column<int>(nullable: false),
                    StartAt = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameHistory_ServiceRecord_ServiceRecordId",
                        column: x => x.ServiceRecordId,
                        principalTable: "ServiceRecord",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Authentication");
            migrationBuilder.DropTable("GameHistory");
            migrationBuilder.DropTable("ServiceRecord");
        }
    }
}
