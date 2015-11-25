using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Branch.Service.XboxLive.Database;

namespace Branch.Service.XboxLive.Migrations
{
    [DbContext(typeof(XboxLiveDbContext))]
    [Migration("20151018134350_RemovedAuthenticationTablesMovedToXuidService")]
    partial class RemovedAuthenticationTablesMovedToXuidService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-beta8-15964")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
