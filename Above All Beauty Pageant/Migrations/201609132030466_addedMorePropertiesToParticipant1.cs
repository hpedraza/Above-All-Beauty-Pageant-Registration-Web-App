namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMorePropertiesToParticipant1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "HairColor", c => c.String(nullable: false));
            AlterColumn("dbo.Participants", "EyeColor", c => c.String(nullable: false));
            AlterColumn("dbo.Participants", "Hobbies", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participants", "Hobbies", c => c.String());
            AlterColumn("dbo.Participants", "EyeColor", c => c.String());
            AlterColumn("dbo.Participants", "HairColor", c => c.String());
        }
    }
}
