namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventsModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "LocationId_Id", "dbo.Addresses");
            DropForeignKey("dbo.Events", "Location_Id", "dbo.Addresses");
            DropIndex("dbo.Events", new[] { "Location_Id" });
            DropIndex("dbo.Events", new[] { "LocationId_Id" });
            RenameColumn(table: "dbo.Events", name: "Location_Id", newName: "LocationId");
            AlterColumn("dbo.Events", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "LocationId");
            AddForeignKey("dbo.Events", "LocationId", "dbo.Addresses", "Id", cascadeDelete: true);
            DropColumn("dbo.Events", "LocationId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "LocationId_Id", c => c.Int());
            DropForeignKey("dbo.Events", "LocationId", "dbo.Addresses");
            DropIndex("dbo.Events", new[] { "LocationId" });
            AlterColumn("dbo.Events", "LocationId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "LocationId", newName: "Location_Id");
            CreateIndex("dbo.Events", "LocationId_Id");
            CreateIndex("dbo.Events", "Location_Id");
            AddForeignKey("dbo.Events", "Location_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Events", "LocationId_Id", "dbo.Addresses", "Id");
        }
    }
}
