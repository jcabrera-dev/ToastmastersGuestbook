namespace ToastmastersGuestBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSocialNetwork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialNetwork",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Guest", "SocialMediaId", c => c.Int());
            CreateIndex("dbo.Guest", "SocialMediaId");
            AddForeignKey("dbo.Guest", "SocialMediaId", "dbo.SocialNetwork", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guest", "SocialMediaId", "dbo.SocialNetwork");
            DropIndex("dbo.Guest", new[] { "SocialMediaId" });
            DropColumn("dbo.Guest", "SocialMediaId");
            DropTable("dbo.SocialNetwork");
        }
    }
}
