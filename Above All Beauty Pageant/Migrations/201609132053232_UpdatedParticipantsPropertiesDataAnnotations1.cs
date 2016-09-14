namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedParticipantsPropertiesDataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "FavoriteColor", c => c.String(nullable: false));
            AddColumn("dbo.Participants", "FavoriteFood", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "FavoriteFood");
            DropColumn("dbo.Participants", "FavoriteColor");
        }
    }
}
