namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEngageds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Engageds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.String(),
                        CustomerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Engaggeds");
        }
    }
}
