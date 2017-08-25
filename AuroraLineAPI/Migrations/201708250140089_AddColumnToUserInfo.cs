namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToUserInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "GotGift", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "GotGift");
        }
    }
}
