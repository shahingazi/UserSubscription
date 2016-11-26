namespace VoiceOverIp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmailUniqueKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.User", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Email" });
        }
    }
}
