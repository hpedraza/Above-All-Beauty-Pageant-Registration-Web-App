namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPaidPropToParticipantModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "paid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "paid");
        }
    }
}
