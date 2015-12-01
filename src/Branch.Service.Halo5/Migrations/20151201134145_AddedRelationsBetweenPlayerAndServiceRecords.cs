using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Branch.Service.Halo5.Migrations
{
    public partial class AddedRelationsBetweenPlayerAndServiceRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecord_Player_PlayerId",
                table: "ServiceRecord",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ServiceRecord_Player_PlayerId", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "PlayerId", table: "ServiceRecord");
        }
    }
}
