namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedUniqueKeyBetweenCategoryAndEventIdInEventCategoryTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EventCategories", new[] { "EventId" });
            CreateIndex("dbo.EventCategories", new[] { "Category", "EventId" }, unique: true, name: "KEY");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EventCategories", "KEY");
            CreateIndex("dbo.EventCategories", "EventId");
        }
    }
}
