namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tookOutLocationIdInEventModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "LocationId", "dbo.Addresses");
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropColumn("dbo.Events", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "LocationId");
            AddForeignKey("dbo.Events", "LocationId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
