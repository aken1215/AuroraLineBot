namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserInfoGotGift : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.UserInfoes", "GotGift");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "GotGift", c => c.Boolean(nullable: false));
            AlterColumn("dbo.UserInfoes", "Status", c => c.String());
        }
    }
}
