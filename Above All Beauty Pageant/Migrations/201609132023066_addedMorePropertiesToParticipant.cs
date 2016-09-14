namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMorePropertiesToParticipant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Participants", "HairColor", c => c.String());
            AddColumn("dbo.Participants", "EyeColor", c => c.String());
            AddColumn("dbo.Participants", "Hobbies", c => c.String());
            AddColumn("dbo.Participants", "Sponsor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "Sponsor");
            DropColumn("dbo.Participants", "Hobbies");
            DropColumn("dbo.Participants", "EyeColor");
            DropColumn("dbo.Participants", "HairColor");
            DropColumn("dbo.Participants", "DOB");
        }
    }
}
