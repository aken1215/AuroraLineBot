namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserInfo : DbMigration
    {
        public override void Up()
        {
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
                "dbo.EngageRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.String(),
                        CustomerId = c.String(),
                        IssusOpend = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        LineID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Mobile = c.String(),
                        EMail = c.String(),
                        ServiceDPT = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfoes");
            DropTable("dbo.PendingRequests");
            DropTable("dbo.EngageRequests");
            DropTable("dbo.Agents");
        }
    }
}
