namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Address");
        }
    }
}
