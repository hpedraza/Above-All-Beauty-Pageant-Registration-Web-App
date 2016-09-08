namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TookOffListOFEventsFromUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Events", "ApplicationUser_Id");



        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "ApplicationUser_Id");
            AddForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");

        }
    }
}
