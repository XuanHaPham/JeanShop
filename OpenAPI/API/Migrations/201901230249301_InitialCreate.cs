namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventID = c.Int(),
                        Status = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Event", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        StartTime = c.DateTime(),
                        FinishTime = c.DateTime(),
                        Location = c.String(),
                        TimeCreated = c.DateTime(),
                        OrganizationMemberID = c.Int(),
                        Public = c.Boolean(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationMember", t => t.OrganizationMemberID)
                .Index(t => t.OrganizationMemberID);
            
            CreateTable(
                "dbo.EventComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(),
                        AccountID = c.Int(),
                        Content = c.String(),
                        Status = c.Boolean(),
                        Account_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .ForeignKey("dbo.Event", t => t.EventID)
                .Index(t => t.EventID)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Fullname = c.String(),
                        Point = c.Double(),
                        Address = c.String(),
                        Status = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.EventVolunteer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(),
                        EventID = c.Int(),
                        TimeCreated = c.DateTime(),
                        Status = c.String(maxLength: 10, fixedLength: true),
                        Account_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .ForeignKey("dbo.Event", t => t.EventID)
                .Index(t => t.EventID)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.AccountLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Account", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.NewsComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NewsID = c.Int(nullable: false),
                        AccountID = c.Int(),
                        Content = c.String(),
                        TimeCreated = c.DateTime(),
                        Status = c.Boolean(),
                        Account_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .ForeignKey("dbo.News", t => t.NewsID)
                .Index(t => t.NewsID)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ImageURL = c.String(),
                        OrganizationMemberID = c.Int(),
                        Public = c.Boolean(),
                        TimeCreated = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationMember", t => t.OrganizationMemberID)
                .Index(t => t.OrganizationMemberID);
            
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
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        TimeCreate = c.DateTime(),
                        Creator = c.String(maxLength: 128),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.Creator)
                .Index(t => t.Creator);
            
            CreateTable(
                "dbo.OrganizationMemberRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrganizationRoleID = c.Int(),
                        OrganizationMemberID = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationMember", t => t.OrganizationMemberID)
                .ForeignKey("dbo.OrganizationRole", t => t.OrganizationRoleID)
                .Index(t => t.OrganizationRoleID)
                .Index(t => t.OrganizationMemberID);
            
            CreateTable(
                "dbo.OrganizationRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccountRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Role", t => t.IdentityRole_Id)
                .ForeignKey("dbo.Account", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.EventVolunteerType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventTypeID = c.Int(),
                        EventID = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Event", t => t.EventID)
                .ForeignKey("dbo.EventType", t => t.EventTypeID)
                .Index(t => t.EventTypeID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.EventType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Configuaration",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountRole", "IdentityUser_Id", "dbo.Account");
            DropForeignKey("dbo.AccountLogin", "IdentityUser_Id", "dbo.Account");
            DropForeignKey("dbo.AccountClaim", "IdentityUser_Id", "dbo.Account");
            DropForeignKey("dbo.AccountRole", "IdentityRole_Id", "dbo.Role");
            DropForeignKey("dbo.EventVolunteerType", "EventTypeID", "dbo.EventType");
            DropForeignKey("dbo.EventVolunteerType", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventComment", "EventID", "dbo.Event");
            DropForeignKey("dbo.Organization", "Creator", "dbo.Account");
            DropForeignKey("dbo.OrganizationMember", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.OrganizationMemberRole", "OrganizationRoleID", "dbo.OrganizationRole");
            DropForeignKey("dbo.OrganizationMemberRole", "OrganizationMemberID", "dbo.OrganizationMember");
            DropForeignKey("dbo.OrganizationMember", "OrganizationID", "dbo.Organization");
            DropForeignKey("dbo.News", "OrganizationMemberID", "dbo.OrganizationMember");
            DropForeignKey("dbo.Event", "OrganizationMemberID", "dbo.OrganizationMember");
            DropForeignKey("dbo.NewsComment", "NewsID", "dbo.News");
            DropForeignKey("dbo.NewsComment", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.EventVolunteer", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventVolunteer", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.EventComment", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.Activity", "EventID", "dbo.Event");
            DropIndex("dbo.EventVolunteerType", new[] { "EventID" });
            DropIndex("dbo.EventVolunteerType", new[] { "EventTypeID" });
            DropIndex("dbo.AccountRole", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AccountRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.OrganizationMemberRole", new[] { "OrganizationMemberID" });
            DropIndex("dbo.OrganizationMemberRole", new[] { "OrganizationRoleID" });
            DropIndex("dbo.Organization", new[] { "Creator" });
            DropIndex("dbo.OrganizationMember", new[] { "Account_Id" });
            DropIndex("dbo.OrganizationMember", new[] { "OrganizationID" });
            DropIndex("dbo.News", new[] { "OrganizationMemberID" });
            DropIndex("dbo.NewsComment", new[] { "Account_Id" });
            DropIndex("dbo.NewsComment", new[] { "NewsID" });
            DropIndex("dbo.AccountLogin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.EventVolunteer", new[] { "Account_Id" });
            DropIndex("dbo.EventVolunteer", new[] { "EventID" });
            DropIndex("dbo.AccountClaim", new[] { "IdentityUser_Id" });
            DropIndex("dbo.EventComment", new[] { "Account_Id" });
            DropIndex("dbo.EventComment", new[] { "EventID" });
            DropIndex("dbo.Event", new[] { "OrganizationMemberID" });
            DropIndex("dbo.Activity", new[] { "EventID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Role");
            DropTable("dbo.Configuaration");
            DropTable("dbo.EventType");
            DropTable("dbo.EventVolunteerType");
            DropTable("dbo.AccountRole");
            DropTable("dbo.OrganizationRole");
            DropTable("dbo.OrganizationMemberRole");
            DropTable("dbo.Organization");
            DropTable("dbo.OrganizationMember");
            DropTable("dbo.News");
            DropTable("dbo.NewsComment");
            DropTable("dbo.AccountLogin");
            DropTable("dbo.EventVolunteer");
            DropTable("dbo.AccountClaim");
            DropTable("dbo.Account");
            DropTable("dbo.EventComment");
            DropTable("dbo.Event");
            DropTable("dbo.Activity");
        }
    }
}
