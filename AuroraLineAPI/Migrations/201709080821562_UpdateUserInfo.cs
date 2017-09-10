namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Mobile", c => c.String());
            AddColumn("dbo.UserInfoes", "ServiceDPT", c => c.String());
            AddColumn("dbo.UserInfoes", "Status", c => c.String());
            DropColumn("dbo.UserInfoes", "JobTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "JobTitle", c => c.String());
            DropColumn("dbo.UserInfoes", "Status");
            DropColumn("dbo.UserInfoes", "ServiceDPT");
            DropColumn("dbo.UserInfoes", "Mobile");
        }
    }
}
