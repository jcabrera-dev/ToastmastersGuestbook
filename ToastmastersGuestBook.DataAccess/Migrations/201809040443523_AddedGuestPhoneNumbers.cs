namespace ToastmastersGuestBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuestPhoneNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestPhoneNumber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        GuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guest", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.GuestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestPhoneNumber", "GuestId", "dbo.Guest");
            DropIndex("dbo.GuestPhoneNumber", new[] { "GuestId" });
            DropTable("dbo.GuestPhoneNumber");
        }
    }
}
