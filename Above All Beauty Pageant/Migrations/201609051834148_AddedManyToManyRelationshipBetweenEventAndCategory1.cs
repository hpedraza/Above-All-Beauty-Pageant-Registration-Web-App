namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManyToManyRelationshipBetweenEventAndCategory1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventsCategories",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.CategoryId })
                .ForeignKey("dbo.EventCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventsCategories", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventsCategories", "CategoryId", "dbo.EventCategories");
            DropIndex("dbo.EventsCategories", new[] { "CategoryId" });
            DropIndex("dbo.EventsCategories", new[] { "EventId" });
            DropTable("dbo.EventsCategories");
        }
    }
}
