using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Branch.Game.Halo4.Database;

namespace Branch.Game.Halo4.Migrations
{
    [ContextType(typeof(Halo4DbContext))]
    partial class GameHistoryModels
    {
        public override string Id
        {
            get { return "20150514155235_GameHistoryModels"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta4-12943"; }
        }
        
        public override IModel Target
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
                
                builder.Entity("Branch.Game.Halo4.Database.Models.GameHistory", b =>
                    {
                        b.Property<int>("Count")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<DateTime>("CreatedAt")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("DocumentId")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("GameMode")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 4)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<int>("ServiceRecordId")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<int>("StartAt")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<DateTime>("UpdatedAt")
                            .Annotation("OriginalValueIndex", 7);
                        b.Key("Id");
                    });
                
                builder.Entity("Branch.Game.Halo4.Database.Models.ServiceRecord", b =>
                    {
                        b.Property<DateTime>("CreatedAt")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("DocumentId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Gamertag")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("ServiceTag")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<DateTime>("UpdatedAt")
                            .Annotation("OriginalValueIndex", 5);
                        b.Key("Id");
                    });
                
                builder.Entity("Branch.Game.Halo4.Database.Models.GameHistory", b =>
                    {
                        b.ForeignKey("Branch.Game.Halo4.Database.Models.ServiceRecord", "ServiceRecordId");
                    });
                
                return builder.Model;
            }
        }
    }
}
