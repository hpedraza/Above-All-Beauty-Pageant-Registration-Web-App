namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedParticipantsPropertiesDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Participants", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participants", "LastName", c => c.String());
            AlterColumn("dbo.Participants", "FirstName", c => c.String());
        }
    }
}
