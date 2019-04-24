namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreOrgMembers : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organization", t => t.OrganizationID)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .Index(t => t.OrganizationID)
                .Index(t => t.Account_Id);
            
            CreateIndex("dbo.Event", "OrganizationMemberID");
            CreateIndex("dbo.News", "OrganizationMemberID");
            AddForeignKey("dbo.Event", "OrganizationMemberID", "dbo.OrganizationMember", "ID");
            AddForeignKey("dbo.News", "OrganizationMemberID", "dbo.OrganizationMember", "ID");
            DropTable("dbo.OrganizationRole");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrganizationRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.OrganizationMember", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.OrganizationMember", "OrganizationID", "dbo.Organization");
            DropForeignKey("dbo.News", "OrganizationMemberID", "dbo.OrganizationMember");
            DropForeignKey("dbo.Event", "OrganizationMemberID", "dbo.OrganizationMember");
            DropIndex("dbo.OrganizationMember", new[] { "Account_Id" });
            DropIndex("dbo.OrganizationMember", new[] { "OrganizationID" });
            DropIndex("dbo.News", new[] { "OrganizationMemberID" });
            DropIndex("dbo.Event", new[] { "OrganizationMemberID" });
            DropTable("dbo.OrganizationMember");
        }
    }
}
