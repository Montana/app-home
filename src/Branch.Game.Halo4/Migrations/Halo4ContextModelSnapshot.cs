using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Branch.Game.Halo4.Database;

namespace Branch.Game.Halo4.Migrations
{
    [ContextType(typeof(Halo4DbContext))]
    partial class Halo4ContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("Branch.Game.Halo4.Database.Models.Authentication", b =>
                    {
                        b.Property<string>("AnalyticsToken")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<DateTime>("CreatedAt")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<DateTime>("ExpiresAt")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("Gamertag")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 4)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("SpartanToken")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<DateTime>("UpdatedAt")
                            .Annotation("OriginalValueIndex", 6);
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}
