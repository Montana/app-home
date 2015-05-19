using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Branch.Service.Halo4.Migrations
{
    public partial class Update : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "DocumentId",
                table: "ServiceRecord",
                type: "nvarchar(max)",
                nullable: true);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "DocumentId",
                table: "ServiceRecord",
                type: "uniqueidentifier",
                nullable: false);
        }
    }
}
