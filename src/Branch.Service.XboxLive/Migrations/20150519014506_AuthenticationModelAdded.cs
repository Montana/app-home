using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Branch.Service.XboxLive.Migrations
{
    public partial class AuthenticationModelAdded : Migration
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
                    CreatedAt = table.Column(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column(type: "datetime2", nullable: false),
                    Gamertag = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false),
                    Token = table.Column(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column(type: "datetime2", nullable: false),
                    UserHash = table.Column(type: "nvarchar(max)", nullable: true),
                    Xuid = table.Column(type: "bigint", nullable: false)
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
