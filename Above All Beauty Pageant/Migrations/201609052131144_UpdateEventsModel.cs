namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "LocationId_Id", c => c.Int());
            CreateIndex("dbo.Events", "LocationId_Id");
            AddForeignKey("dbo.Events", "LocationId_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "LocationId_Id", "dbo.Addresses");
            DropIndex("dbo.Events", new[] { "LocationId_Id" });
            DropColumn("dbo.Events", "LocationId_Id");
        }
    }
}
