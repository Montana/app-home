using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Branch.Game.Halo4.Migrations
{
    public partial class AddedServiceRecords : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "ServiceRecord",
                columns: table => new
                {
                    CreatedAt = table.Column(type: "datetime2", nullable: false),
                    DocumentId = table.Column(type: "uniqueidentifier", nullable: false),
                    Gamertag = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false),
                    ServiceTag = table.Column(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecord", x => x.Id);
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("ServiceRecord");
        }
    }
}
