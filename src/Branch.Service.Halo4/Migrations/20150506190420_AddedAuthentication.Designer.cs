using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Branch.Service.Halo4.Database;

namespace Branch.Service.Halo4.Migrations
{
    [ContextType(typeof(Halo4DbContext))]
    partial class AddedAuthentication
    {
        public override string Id
        {
            get { return "20150506190420_AddedAuthentication"; }
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
                
                builder.Entity("Branch.Service.Halo4.Database.Models.Authentication", b =>
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
