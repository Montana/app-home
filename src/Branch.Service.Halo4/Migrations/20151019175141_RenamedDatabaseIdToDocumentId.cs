using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Branch.Service.Halo4.Migrations
{
    public partial class RenamedDatabaseIdToDocumentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DatabaseId", table: "Metadata");
            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Metadata",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DocumentId", table: "Metadata");
            migrationBuilder.AddColumn<string>(
                name: "DatabaseId",
                table: "Metadata",
                nullable: true);
        }
    }
}
