using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Branch.Service.Halo4.Migrations
{
    public partial class AddedAuthentication : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    AnalyticsToken = table.Column(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column(type: "datetime2", nullable: false),
                    Gamertag = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false),
                    SpartanToken = table.Column(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.Id);
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Authentication");
        }
    }
}
