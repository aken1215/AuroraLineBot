namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAuroraLine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        LineID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        EMail = c.String(),
                        JobTitle = c.String(),
                    })
                .PrimaryKey(t => t.LineID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfoes");
        }
    }
}
