namespace MapHive.Identity.MembershipReboot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeTo_9_0_0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("mr.UserAccounts", "AccountApproved", c => c.DateTime());
            AddColumn("mr.UserAccounts", "AccountRejected", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("mr.UserAccounts", "AccountRejected");
            DropColumn("mr.UserAccounts", "AccountApproved");
        }
    }
}
