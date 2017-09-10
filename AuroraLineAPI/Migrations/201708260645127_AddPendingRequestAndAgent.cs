namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPendingRequestAndAgent : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Engageds", newName: "EngageRequests");
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(),
                        AgentState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PendingRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(),
                        IssusOpend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EngageRequests", "IssusOpend", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EngageRequests", "IssusOpend");
            DropTable("dbo.PendingRequests");
            DropTable("dbo.Agents");
            RenameTable(name: "dbo.EngageRequests", newName: "Engageds");
        }
    }
}
