namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAccountIdType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EventComment", new[] { "Account_Id" });
            DropIndex("dbo.EventVolunteer", new[] { "Account_Id" });
            DropIndex("dbo.NewsComment", new[] { "Account_Id" });
            DropIndex("dbo.OrganizationMember", new[] { "Account_Id" });
            DropColumn("dbo.EventComment", "AccountID");
            DropColumn("dbo.EventVolunteer", "AccountID");
            DropColumn("dbo.NewsComment", "AccountID");
            DropColumn("dbo.OrganizationMember", "AccountID");
            RenameColumn(table: "dbo.EventComment", name: "Account_Id", newName: "AccountID");
            RenameColumn(table: "dbo.EventVolunteer", name: "Account_Id", newName: "AccountID");
            RenameColumn(table: "dbo.NewsComment", name: "Account_Id", newName: "AccountID");
            RenameColumn(table: "dbo.OrganizationMember", name: "Account_Id", newName: "AccountID");
            AlterColumn("dbo.EventComment", "AccountID", c => c.String(maxLength: 128));
            AlterColumn("dbo.EventVolunteer", "AccountID", c => c.String(maxLength: 128));
            AlterColumn("dbo.NewsComment", "AccountID", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrganizationMember", "AccountID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.EventComment", "AccountID");
            CreateIndex("dbo.EventVolunteer", "AccountID");
            CreateIndex("dbo.NewsComment", "AccountID");
            CreateIndex("dbo.OrganizationMember", "AccountID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrganizationMember", new[] { "AccountID" });
            DropIndex("dbo.NewsComment", new[] { "AccountID" });
            DropIndex("dbo.EventVolunteer", new[] { "AccountID" });
            DropIndex("dbo.EventComment", new[] { "AccountID" });
            AlterColumn("dbo.OrganizationMember", "AccountID", c => c.Int(nullable: false));
            AlterColumn("dbo.NewsComment", "AccountID", c => c.Int());
            AlterColumn("dbo.EventVolunteer", "AccountID", c => c.Int());
            AlterColumn("dbo.EventComment", "AccountID", c => c.Int());
            RenameColumn(table: "dbo.OrganizationMember", name: "AccountID", newName: "Account_Id");
            RenameColumn(table: "dbo.NewsComment", name: "AccountID", newName: "Account_Id");
            RenameColumn(table: "dbo.EventVolunteer", name: "AccountID", newName: "Account_Id");
            RenameColumn(table: "dbo.EventComment", name: "AccountID", newName: "Account_Id");
            AddColumn("dbo.OrganizationMember", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.NewsComment", "AccountID", c => c.Int());
            AddColumn("dbo.EventVolunteer", "AccountID", c => c.Int());
            AddColumn("dbo.EventComment", "AccountID", c => c.Int());
            CreateIndex("dbo.OrganizationMember", "Account_Id");
            CreateIndex("dbo.NewsComment", "Account_Id");
            CreateIndex("dbo.EventVolunteer", "Account_Id");
            CreateIndex("dbo.EventComment", "Account_Id");
        }
    }
}
