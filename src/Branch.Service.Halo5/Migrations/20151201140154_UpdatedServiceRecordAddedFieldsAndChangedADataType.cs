using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Branch.Service.Halo5.Migrations
{
    public partial class UpdatedServiceRecordAddedFieldsAndChangedADataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ServiceRecord_Player_PlayerId", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalGamesStarted", table: "ServiceRecord");
            migrationBuilder.AlterColumn<double>(
                name: "TotalDamage",
                table: "ServiceRecord",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "TotalGamesCompleted",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "TotalGamesLost",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "TotalGamesTied",
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
            migrationBuilder.DropColumn(name: "TotalGamesCompleted", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalGamesLost", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "TotalGamesTied", table: "ServiceRecord");
            migrationBuilder.AlterColumn<int>(
                name: "TotalDamage",
                table: "ServiceRecord",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "TotalGamesStarted",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecord_Player_PlayerId",
                table: "ServiceRecord",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
