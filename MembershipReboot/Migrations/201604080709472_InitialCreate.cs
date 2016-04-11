namespace MapHive.Identity.MembershipReboot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "mr.Groups",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ID = c.Guid(nullable: false),
                        Tenant = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 100),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "mr.GroupChilds",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ParentKey = c.Int(nullable: false),
                        ChildGroupID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("mr.Groups", t => t.ParentKey, cascadeDelete: true)
                .Index(t => t.ParentKey);
            
            CreateTable(
                "mr.UserAccounts",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ID = c.Guid(nullable: false),
                        Tenant = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 254),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        IsAccountClosed = c.Boolean(nullable: false),
                        AccountClosed = c.DateTime(),
                        IsLoginAllowed = c.Boolean(nullable: false),
                        LastLogin = c.DateTime(),
                        LastFailedLogin = c.DateTime(),
                        FailedLoginCount = c.Int(nullable: false),
                        PasswordChanged = c.DateTime(),
                        RequiresPasswordReset = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 254),
                        IsAccountVerified = c.Boolean(nullable: false),
                        LastFailedPasswordReset = c.DateTime(),
                        FailedPasswordResetCount = c.Int(nullable: false),
                        MobileCode = c.String(maxLength: 100),
                        MobileCodeSent = c.DateTime(),
                        MobilePhoneNumber = c.String(maxLength: 20),
                        MobilePhoneNumberChanged = c.DateTime(),
                        AccountTwoFactorAuthMode = c.Int(nullable: false),
                        CurrentTwoFactorAuthStatus = c.Int(nullable: false),
                        VerificationKey = c.String(maxLength: 100),
                        VerificationPurpose = c.Int(),
                        VerificationKeySent = c.DateTime(),
                        VerificationStorage = c.String(maxLength: 100),
                        HashedPassword = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "mr.UserClaims",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ParentKey = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("mr.UserAccounts", t => t.ParentKey, cascadeDelete: true)
                .Index(t => t.ParentKey);
            
            CreateTable(
                "mr.LinkedAccountClaims",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ParentKey = c.Int(nullable: false),
                        ProviderName = c.String(nullable: false, maxLength: 30),
                        ProviderAccountID = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("mr.UserAccounts", t => t.ParentKey, cascadeDelete: true)
                .Index(t => t.ParentKey);
            
            CreateTable(
                "mr.LinkedAccounts",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ParentKey = c.Int(nullable: false),
                        ProviderName = c.String(nullable: false, maxLength: 30),
                        ProviderAccountID = c.String(nullable: false, maxLength: 100),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("mr.UserAccounts", t => t.ParentKey, cascadeDelete: true)
                .Index(t => t.ParentKey);
            
            CreateTable(
                "mr.PasswordResetSecrets",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ParentKey = c.Int(nullable: false),
                        PasswordResetSecretID = c.Guid(nullable: false),
                        Question = c.String(nullable: false, maxLength: 150),
                        Answer = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("mr.UserAccounts", t => t.ParentKey, cascadeDelete: true)
                .Index(t => t.ParentKey);
            
            CreateTable(
                "mr.TwoFactorAuthTokens",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ParentKey = c.Int(nullable: false),
                        Token = c.String(nullable: false, maxLength: 100),
                        Issued = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("mr.UserAccounts", t => t.ParentKey, cascadeDelete: true)
                .Index(t => t.ParentKey);
            
            CreateTable(
                "mr.UserCertificates",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        ParentKey = c.Int(nullable: false),
                        Thumbprint = c.String(nullable: false, maxLength: 150),
                        Subject = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("mr.UserAccounts", t => t.ParentKey, cascadeDelete: true)
                .Index(t => t.ParentKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("mr.UserCertificates", "ParentKey", "mr.UserAccounts");
            DropForeignKey("mr.TwoFactorAuthTokens", "ParentKey", "mr.UserAccounts");
            DropForeignKey("mr.PasswordResetSecrets", "ParentKey", "mr.UserAccounts");
            DropForeignKey("mr.LinkedAccounts", "ParentKey", "mr.UserAccounts");
            DropForeignKey("mr.LinkedAccountClaims", "ParentKey", "mr.UserAccounts");
            DropForeignKey("mr.UserClaims", "ParentKey", "mr.UserAccounts");
            DropForeignKey("mr.GroupChilds", "ParentKey", "mr.Groups");
            DropIndex("mr.UserCertificates", new[] { "ParentKey" });
            DropIndex("mr.TwoFactorAuthTokens", new[] { "ParentKey" });
            DropIndex("mr.PasswordResetSecrets", new[] { "ParentKey" });
            DropIndex("mr.LinkedAccounts", new[] { "ParentKey" });
            DropIndex("mr.LinkedAccountClaims", new[] { "ParentKey" });
            DropIndex("mr.UserClaims", new[] { "ParentKey" });
            DropIndex("mr.GroupChilds", new[] { "ParentKey" });
            DropTable("mr.UserCertificates");
            DropTable("mr.TwoFactorAuthTokens");
            DropTable("mr.PasswordResetSecrets");
            DropTable("mr.LinkedAccounts");
            DropTable("mr.LinkedAccountClaims");
            DropTable("mr.UserClaims");
            DropTable("mr.UserAccounts");
            DropTable("mr.GroupChilds");
            DropTable("mr.Groups");
        }
    }
}
