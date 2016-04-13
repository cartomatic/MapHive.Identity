namespace MapHive.Identity.IdentityServer.Migrations.ClientConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "idsrv_clients.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                        ClientId = c.String(nullable: false, maxLength: 200),
                        ClientName = c.String(nullable: false, maxLength: 200),
                        ClientUri = c.String(maxLength: 2000),
                        LogoUri = c.String(),
                        RequireConsent = c.Boolean(nullable: false),
                        AllowRememberConsent = c.Boolean(nullable: false),
                        AllowAccessTokensViaBrowser = c.Boolean(nullable: false),
                        Flow = c.Int(nullable: false),
                        AllowClientCredentialsOnly = c.Boolean(nullable: false),
                        LogoutUri = c.String(),
                        LogoutSessionRequired = c.Boolean(nullable: false),
                        RequireSignOutPrompt = c.Boolean(nullable: false),
                        AllowAccessToAllScopes = c.Boolean(nullable: false),
                        IdentityTokenLifetime = c.Int(nullable: false),
                        AccessTokenLifetime = c.Int(nullable: false),
                        AuthorizationCodeLifetime = c.Int(nullable: false),
                        AbsoluteRefreshTokenLifetime = c.Int(nullable: false),
                        SlidingRefreshTokenLifetime = c.Int(nullable: false),
                        RefreshTokenUsage = c.Int(nullable: false),
                        UpdateAccessTokenOnRefresh = c.Boolean(nullable: false),
                        RefreshTokenExpiration = c.Int(nullable: false),
                        AccessTokenType = c.Int(nullable: false),
                        EnableLocalLogin = c.Boolean(nullable: false),
                        IncludeJwtId = c.Boolean(nullable: false),
                        AlwaysSendClientClaims = c.Boolean(nullable: false),
                        PrefixClientClaims = c.Boolean(nullable: false),
                        AllowAccessToAllGrantTypes = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClientId, unique: true);
            
            CreateTable(
                "idsrv_clients.ClientCorsOrigins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Origin = c.String(nullable: false, maxLength: 150),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "idsrv_clients.ClientCustomGrantTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrantType = c.String(nullable: false, maxLength: 250),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "idsrv_clients.ClientScopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Scope = c.String(nullable: false, maxLength: 200),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "idsrv_clients.ClientClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 250),
                        Value = c.String(nullable: false, maxLength: 250),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "idsrv_clients.ClientSecrets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false, maxLength: 250),
                        Type = c.String(maxLength: 250),
                        Description = c.String(maxLength: 2000),
                        Expiration = c.DateTimeOffset(precision: 7),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "idsrv_clients.ClientIdPRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Provider = c.String(nullable: false, maxLength: 200),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "idsrv_clients.ClientPostLogoutRedirectUris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uri = c.String(nullable: false, maxLength: 2000),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "idsrv_clients.ClientRedirectUris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uri = c.String(nullable: false, maxLength: 2000),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("idsrv_clients.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("idsrv_clients.ClientRedirectUris", "Client_Id", "idsrv_clients.Clients");
            DropForeignKey("idsrv_clients.ClientPostLogoutRedirectUris", "Client_Id", "idsrv_clients.Clients");
            DropForeignKey("idsrv_clients.ClientIdPRestrictions", "Client_Id", "idsrv_clients.Clients");
            DropForeignKey("idsrv_clients.ClientSecrets", "Client_Id", "idsrv_clients.Clients");
            DropForeignKey("idsrv_clients.ClientClaims", "Client_Id", "idsrv_clients.Clients");
            DropForeignKey("idsrv_clients.ClientScopes", "Client_Id", "idsrv_clients.Clients");
            DropForeignKey("idsrv_clients.ClientCustomGrantTypes", "Client_Id", "idsrv_clients.Clients");
            DropForeignKey("idsrv_clients.ClientCorsOrigins", "Client_Id", "idsrv_clients.Clients");
            DropIndex("idsrv_clients.ClientRedirectUris", new[] { "Client_Id" });
            DropIndex("idsrv_clients.ClientPostLogoutRedirectUris", new[] { "Client_Id" });
            DropIndex("idsrv_clients.ClientIdPRestrictions", new[] { "Client_Id" });
            DropIndex("idsrv_clients.ClientSecrets", new[] { "Client_Id" });
            DropIndex("idsrv_clients.ClientClaims", new[] { "Client_Id" });
            DropIndex("idsrv_clients.ClientScopes", new[] { "Client_Id" });
            DropIndex("idsrv_clients.ClientCustomGrantTypes", new[] { "Client_Id" });
            DropIndex("idsrv_clients.ClientCorsOrigins", new[] { "Client_Id" });
            DropIndex("idsrv_clients.Clients", new[] { "ClientId" });
            DropTable("idsrv_clients.ClientRedirectUris");
            DropTable("idsrv_clients.ClientPostLogoutRedirectUris");
            DropTable("idsrv_clients.ClientIdPRestrictions");
            DropTable("idsrv_clients.ClientSecrets");
            DropTable("idsrv_clients.ClientClaims");
            DropTable("idsrv_clients.ClientScopes");
            DropTable("idsrv_clients.ClientCustomGrantTypes");
            DropTable("idsrv_clients.ClientCorsOrigins");
            DropTable("idsrv_clients.Clients");
        }
    }
}
