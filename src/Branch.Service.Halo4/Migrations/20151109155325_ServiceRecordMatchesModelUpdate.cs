using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Branch.Service.Halo4.Migrations
{
    public partial class ServiceRecordMatchesModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Match_ServiceRecord_ServiceRecordId", table: "Match");
            migrationBuilder.DropForeignKey(name: "FK_ServiceRecord_Match_MatchId", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "MatchId", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "ServiceRecordId", table: "Match");
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ServiceRecordMatches");
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "ServiceRecord",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "ServiceRecordId",
                table: "Match",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Match_ServiceRecord_ServiceRecordId",
                table: "Match",
                column: "ServiceRecordId",
                principalTable: "ServiceRecord",
                principalColumn: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecord_Match_MatchId",
                table: "ServiceRecord",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id");
        }
    }
}
