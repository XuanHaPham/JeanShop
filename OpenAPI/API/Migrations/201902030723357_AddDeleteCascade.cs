namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeleteCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventVolunteerType", "EventID", "dbo.Event");
            DropForeignKey("dbo.OrganizationMember", "AccountID", "dbo.Account");
            DropForeignKey("dbo.NewsComment", "NewsID", "dbo.News");
            DropIndex("dbo.EventVolunteerType", new[] { "EventID" });
            AlterColumn("dbo.EventVolunteerType", "EventID", c => c.Int(nullable: false));
            CreateIndex("dbo.EventVolunteerType", "EventID");
            AddForeignKey("dbo.EventVolunteerType", "EventID", "dbo.Event", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrganizationMember", "AccountID", "dbo.Account", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NewsComment", "NewsID", "dbo.News", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsComment", "NewsID", "dbo.News");
            DropForeignKey("dbo.OrganizationMember", "AccountID", "dbo.Account");
            DropForeignKey("dbo.EventVolunteerType", "EventID", "dbo.Event");
            DropIndex("dbo.EventVolunteerType", new[] { "EventID" });
            AlterColumn("dbo.EventVolunteerType", "EventID", c => c.Int());
            CreateIndex("dbo.EventVolunteerType", "EventID");
            AddForeignKey("dbo.NewsComment", "NewsID", "dbo.News", "ID");
            AddForeignKey("dbo.OrganizationMember", "AccountID", "dbo.Account", "Id");
            AddForeignKey("dbo.EventVolunteerType", "EventID", "dbo.Event", "ID");
        }
    }
}
