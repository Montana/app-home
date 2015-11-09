using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Branch.Service.Halo4.Migrations
{
    public partial class UpdatedServiceRecordMatchModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ServiceRecordMatches");
            migrationBuilder.CreateTable(
                name: "ServiceRecordMatch",
                columns: table => new
                {
                    ServiceRecordId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecordMatch", x => new { x.ServiceRecordId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_ServiceRecordMatch_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRecordMatch_ServiceRecord_ServiceRecordId",
                        column: x => x.ServiceRecordId,
                        principalTable: "ServiceRecord",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ServiceRecordMatch");
            migrationBuilder.CreateTable(
                name: "ServiceRecordMatches",
                columns: table => new
                {
                    ServiceRecordId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecordMatches", x => new { x.ServiceRecordId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_ServiceRecordMatches_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRecordMatches_ServiceRecord_ServiceRecordId",
                        column: x => x.ServiceRecordId,
                        principalTable: "ServiceRecord",
                        principalColumn: "Id");
                });
        }
    }
}
