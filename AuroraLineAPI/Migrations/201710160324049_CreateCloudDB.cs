namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCloudDB : DbMigration
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
                "dbo.Conversations",
                c => new
                    {
                        Sno = c.Int(nullable: false, identity: true),
                        LineID = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Sno);
            
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
                        SNO = c.Int(nullable: false, identity: true),
                        LineID = c.String(),
                        Name = c.String(),
                        Mobile = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SNO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfoes");
            DropTable("dbo.PendingRequests");
            DropTable("dbo.EngageRequests");
            DropTable("dbo.Conversations");
            DropTable("dbo.Agents");
        }
    }
}
