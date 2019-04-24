namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Duhaanph : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "OrganizationMemberID", "dbo.OrganizationMember");
            DropForeignKey("dbo.News", "OrganizationMemberID", "dbo.OrganizationMember");
            DropForeignKey("dbo.OrganizationMember", "OrganizationID", "dbo.Organization");
            DropForeignKey("dbo.OrganizationMemberRole", "OrganizationMemberID", "dbo.OrganizationMember");
            DropForeignKey("dbo.OrganizationMemberRole", "OrganizationRoleID", "dbo.OrganizationRole");
            DropForeignKey("dbo.OrganizationMember", "Account_Id", "dbo.Account");
            DropIndex("dbo.Event", new[] { "OrganizationMemberID" });
            DropIndex("dbo.News", new[] { "OrganizationMemberID" });
            DropIndex("dbo.OrganizationMember", new[] { "OrganizationID" });
            DropIndex("dbo.OrganizationMember", new[] { "Account_Id" });
            DropIndex("dbo.OrganizationMemberRole", new[] { "OrganizationRoleID" });
            DropIndex("dbo.OrganizationMemberRole", new[] { "OrganizationMemberID" });
            DropTable("dbo.OrganizationMember");
            DropTable("dbo.OrganizationMemberRole");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrganizationMemberRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrganizationRoleID = c.Int(),
                        OrganizationMemberID = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrganizationMember",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        OrganizationID = c.Int(),
                        TimeCreated = c.DateTime(),
                        Status = c.Boolean(),
                        Account_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.OrganizationMemberRole", "OrganizationMemberID");
            CreateIndex("dbo.OrganizationMemberRole", "OrganizationRoleID");
            CreateIndex("dbo.OrganizationMember", "Account_Id");
            CreateIndex("dbo.OrganizationMember", "OrganizationID");
            CreateIndex("dbo.News", "OrganizationMemberID");
            CreateIndex("dbo.Event", "OrganizationMemberID");
            AddForeignKey("dbo.OrganizationMember", "Account_Id", "dbo.Account", "Id");
            AddForeignKey("dbo.OrganizationMemberRole", "OrganizationRoleID", "dbo.OrganizationRole", "ID");
            AddForeignKey("dbo.OrganizationMemberRole", "OrganizationMemberID", "dbo.OrganizationMember", "ID");
            AddForeignKey("dbo.OrganizationMember", "OrganizationID", "dbo.Organization", "ID");
            AddForeignKey("dbo.News", "OrganizationMemberID", "dbo.OrganizationMember", "ID");
            AddForeignKey("dbo.Event", "OrganizationMemberID", "dbo.OrganizationMember", "ID");
        }
    }
}
