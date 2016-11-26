namespace VoiceOverIp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identifier = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceIncVatAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CallMinutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSubscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubscriptionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SubscriptionId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSubscription", "UserId", "dbo.User");
            DropForeignKey("dbo.UserSubscription", "SubscriptionId", "dbo.Subscription");
            DropIndex("dbo.UserSubscription", new[] { "UserId" });
            DropIndex("dbo.UserSubscription", new[] { "SubscriptionId" });
            DropTable("dbo.UserSubscription");
            DropTable("dbo.User");
            DropTable("dbo.Subscription");
        }
    }
}
