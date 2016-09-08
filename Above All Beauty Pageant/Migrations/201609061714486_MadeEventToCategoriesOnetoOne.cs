namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeEventToCategoriesOnetoOne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventsCategories", "CategoryId", "dbo.EventCategories");
            DropForeignKey("dbo.EventsCategories", "EventId", "dbo.Events");
            DropIndex("dbo.EventsCategories", new[] { "EventId" });
            DropIndex("dbo.EventsCategories", new[] { "CategoryId" });
            AddColumn("dbo.EventCategories", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.EventCategories", "EventId");
            AddForeignKey("dbo.EventCategories", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            DropTable("dbo.EventsCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventsCategories",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.CategoryId });
            
            DropForeignKey("dbo.EventCategories", "EventId", "dbo.Events");
            DropIndex("dbo.EventCategories", new[] { "EventId" });
            DropColumn("dbo.EventCategories", "EventId");
            CreateIndex("dbo.EventsCategories", "CategoryId");
            CreateIndex("dbo.EventsCategories", "EventId");
            AddForeignKey("dbo.EventsCategories", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EventsCategories", "CategoryId", "dbo.EventCategories", "Id", cascadeDelete: true);
        }
    }
}
