using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Branch.Game.Halo4.Migrations
{
    public partial class GameHistoryModels : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "GameHistory",
                columns: table => new
                {
                    Count = table.Column(type: "int", nullable: false),
                    CreatedAt = table.Column(type: "datetime2", nullable: false),
                    DocumentId = table.Column(type: "nvarchar(max)", nullable: true),
                    GameMode = table.Column(type: "int", nullable: false),
                    Id = table.Column(type: "int", nullable: false),
                    ServiceRecordId = table.Column(type: "int", nullable: false),
                    StartAt = table.Column(type: "int", nullable: false),
                    UpdatedAt = table.Column(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameHistory_ServiceRecord_ServiceRecordId",
                        columns: x => x.ServiceRecordId,
                        referencedTable: "ServiceRecord",
                        referencedColumn: "Id");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("GameHistory");
        }
    }
}
