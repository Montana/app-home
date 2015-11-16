using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Branch.Service.Halo5.Migrations
{
    public partial class UpdatedProfileAssetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Crop",
                table: "ProfileAsset",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "ProfileAsset",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Crop", table: "ProfileAsset");
            migrationBuilder.DropColumn(name: "Size", table: "ProfileAsset");
        }
    }
}
