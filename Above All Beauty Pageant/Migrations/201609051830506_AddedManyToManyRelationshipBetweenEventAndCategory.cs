namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManyToManyRelationshipBetweenEventAndCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventCategories", "EventId", "dbo.Events");
            DropIndex("dbo.EventCategories", new[] { "EventId" });
            DropColumn("dbo.EventCategories", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventCategories", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.EventCategories", "EventId");
            AddForeignKey("dbo.EventCategories", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
