namespace ToastmastersGuestBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuestSignin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestSignin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateSignin = c.DateTime(nullable: false),
                        GuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guest", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.GuestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestSignin", "GuestId", "dbo.Guest");
            DropIndex("dbo.GuestSignin", new[] { "GuestId" });
            DropTable("dbo.GuestSignin");
        }
    }
}
