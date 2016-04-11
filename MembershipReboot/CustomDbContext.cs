using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrockAllen.MembershipReboot.Ef;

namespace MapHive.Identity.MembershipReboot
{
    public class CustomDbContext : MembershipRebootDbContext<CustomUserAccount, CustomGroup>
    {
        //Note: paramless constructor needed when adding migrations
        public CustomDbContext() { }

        public CustomDbContext(string connStrName)
            : base(connStrName)
        {
            // where "Configuration" comes from Migrations.Configuration
            // so migration take place first, which includes db create
            // and "Seed" method can be used to seed db with initiall data


            //NOTE:
            //it is important to have the conn string passed to the Db initializer, so the db is created properly!
            //otherwise it will not be able to create a db in the proper context!
            Database.SetInitializer<CustomDbContext>(new MigrateDatabaseToLatestVersion<CustomDbContext, Migrations.Configuration>(connStrName));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //need to override the schema for the object here as it defaults to dbo of course
            modelBuilder.HasDefaultSchema("mr");

            //TODO - need to workout what objects do actually get created! and maybe make their names more postgres like - lowercase. this way all the potential querries will be easier to write!

            base.OnModelCreating(modelBuilder);
        }
    }
}
