namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventsModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Location_Id", "dbo.Addresses");
            DropIndex("dbo.Events", new[] { "Location_Id" });
            AlterColumn("dbo.Events", "EventName", c => c.String());
            AlterColumn("dbo.Events", "Location_Id", c => c.Int());
            CreateIndex("dbo.Events", "Location_Id");
            AddForeignKey("dbo.Events", "Location_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Location_Id", "dbo.Addresses");
            DropIndex("dbo.Events", new[] { "Location_Id" });
            AlterColumn("dbo.Events", "Location_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "EventName", c => c.String(nullable: false));
            CreateIndex("dbo.Events", "Location_Id");
            AddForeignKey("dbo.Events", "Location_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
