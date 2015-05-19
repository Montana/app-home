using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Branch.Service.Halo4.Migrations
{
    public partial class MadeGameHistoryModeNullable : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "GameMode",
                table: "GameHistory",
                type: "int",
                nullable: true);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "GameMode",
                table: "GameHistory",
                type: "int",
                nullable: false);
        }
    }
}
