using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MapHive.Identity.IdentityServer.Migrations
{
    /// <summary>
    /// Some db contexts used to generate customised migration scripts
    /// </summary>

    public class OperationalDbContext : IdentityServer3.EntityFramework.OperationalDbContext
    {
        public const string Schema = "idsrv_ops";

        public OperationalDbContext()
        {
        }

        public OperationalDbContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //just remap schema
            modelBuilder.HasDefaultSchema(Schema);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ScopeConfigurationDbContext : IdentityServer3.EntityFramework.ScopeConfigurationDbContext
    {
        public const string Schema = "idsrv_scopes";

        public ScopeConfigurationDbContext()
        {
        }

        public ScopeConfigurationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //just remap schema
            modelBuilder.HasDefaultSchema(Schema);
        }
    }

    public class ClientConfigurationDbContext : IdentityServer3.EntityFramework.ClientConfigurationDbContext
    {
        public const string Schema = "idsrv_clients";

        public ClientConfigurationDbContext()
        {
        }

        public ClientConfigurationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //just remap schema
            modelBuilder.HasDefaultSchema(Schema);
        }
    }
}