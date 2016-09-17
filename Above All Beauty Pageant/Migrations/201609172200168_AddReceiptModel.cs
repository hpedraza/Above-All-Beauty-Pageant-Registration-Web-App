namespace Above_All_Beauty_Pageant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReceiptModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParticipantId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.ParticipantId, cascadeDelete: true)
                .Index(t => t.ParticipantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "ParticipantId", "dbo.Participants");
            DropIndex("dbo.Receipts", new[] { "ParticipantId" });
            DropTable("dbo.Receipts");
        }
    }
}
