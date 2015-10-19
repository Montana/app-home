using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Branch.Service.Halo4.Migrations
{
    public partial class ChangedServiceRecordTableToUseXuidNotGamertag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Gamertag", table: "ServiceRecord");
            migrationBuilder.AddColumn<long>(
                name: "Xuid",
                table: "ServiceRecord",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Xuid", table: "ServiceRecord");
            migrationBuilder.AddColumn<string>(
                name: "Gamertag",
                table: "ServiceRecord",
                nullable: true);
        }
    }
}
