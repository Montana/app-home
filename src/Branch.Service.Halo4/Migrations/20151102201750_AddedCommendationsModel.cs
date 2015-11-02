using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Branch.Service.Halo4.Migrations
{
    public partial class AddedCommendationsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commendations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DocumentId = table.Column<string>(nullable: true),
                    ServiceRecordId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commendations", x => x.Id);
                });
            migrationBuilder.AddColumn<int>(
                name: "CommendationsId",
                table: "ServiceRecord",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecord_Commendations_CommendationsId",
                table: "ServiceRecord",
                column: "CommendationsId",
                principalTable: "Commendations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ServiceRecord_Commendations_CommendationsId", table: "ServiceRecord");
            migrationBuilder.DropColumn(name: "CommendationsId", table: "ServiceRecord");
            migrationBuilder.DropTable("Commendations");
        }
    }
}
