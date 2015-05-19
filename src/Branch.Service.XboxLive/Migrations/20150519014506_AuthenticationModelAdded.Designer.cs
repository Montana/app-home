using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Branch.Service.XboxLive.Database;

namespace Branch.Service.XboxLive.Migrations
{
    [ContextType(typeof(XboxLiveDbContext))]
    partial class AuthenticationModelAdded
    {
        public override string Id
        {
            get { return "20150519014506_AuthenticationModelAdded"; }
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
                
                builder.Entity("Branch.Service.XboxLive.Database.Models.Authentication", b =>
                    {
                        b.Property<DateTime>("CreatedAt")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<DateTime>("ExpiresAt")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Gamertag")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Token")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<DateTime>("UpdatedAt")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<string>("UserHash")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<long>("Xuid")
                            .Annotation("OriginalValueIndex", 7);
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}
