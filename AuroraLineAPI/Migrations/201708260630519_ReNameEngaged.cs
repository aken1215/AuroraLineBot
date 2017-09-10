namespace AuroraLineAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReNameEngaged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Engaggeds", newName: "Engageds");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Engageds", newName: "Engaggeds");
        }
    }
}
