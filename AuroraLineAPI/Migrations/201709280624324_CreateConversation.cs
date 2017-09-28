namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateConversation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Sno = c.Int(nullable: false, identity: true),
                        LineID = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Sno);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Conversations");
        }
    }
}
