namespace MapHive.Identity.IdentityServer.Migrations.ScopeConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "idsrv_scopes.Scopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DisplayName = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Required = c.Boolean(nullable: false),
                        Emphasize = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        IncludeAllClaimsForUser = c.Boolean(nullable: false),
                        ClaimsRule = c.String(maxLength: 200),
                        ShowInDiscoveryDocument = c.Boolean(nullable: false),
                        AllowUnrestrictedIntrospection = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "idsrv_scopes.ScopeClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        AlwaysIncludeInIdToken = c.Boolean(nullable: false),
                        Scope_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_scopes.Scopes", t => t.Scope_Id)
                .Index(t => t.Scope_Id);
            
            CreateTable(
                "idsrv_scopes.ScopeSecrets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1000),
                        Expiration = c.DateTimeOffset(precision: 7),
                        Type = c.String(maxLength: 250),
                        Value = c.String(nullable: false, maxLength: 250),
                        Scope_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_scopes.Scopes", t => t.Scope_Id)
                .Index(t => t.Scope_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("idsrv_scopes.ScopeSecrets", "Scope_Id", "idsrv_scopes.Scopes");
            DropForeignKey("idsrv_scopes.ScopeClaims", "Scope_Id", "idsrv_scopes.Scopes");
            DropIndex("idsrv_scopes.ScopeSecrets", new[] { "Scope_Id" });
            DropIndex("idsrv_scopes.ScopeClaims", new[] { "Scope_Id" });
            DropTable("idsrv_scopes.ScopeSecrets");
            DropTable("idsrv_scopes.ScopeClaims");
            DropTable("idsrv_scopes.Scopes");
        }
    }
}
