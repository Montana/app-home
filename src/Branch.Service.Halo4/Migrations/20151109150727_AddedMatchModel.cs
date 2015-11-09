using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Branch.Service.Halo4.Migrations
{
    public partial class AddedMatchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DocumentId = table.Column<string>(nullable: true),
                    GameMode = table.Column<int>(nullable: false),
                    MatchId = table.Column<string>(nullable: true),
                    ServiceRecordId = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_ServiceRecord_ServiceRecordId",
                        column: x => x.ServiceRecordId,
                        principalTable: "ServiceRecord",
                        principalColumn: "Id");
                });
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "ServiceRecord",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecord_Match_MatchId",
                table: "ServiceRecord",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ServiceRecord_Match_MatchId", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "MatchId", table: "ServiceRecord");
            migrationBuilder.DropTable("Match");
        }
    }
}
