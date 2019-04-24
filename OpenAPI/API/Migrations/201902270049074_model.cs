namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Event", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Account", "Avatar", c => c.String());
            DropColumn("dbo.Event", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Location", c => c.String());
            DropColumn("dbo.Account", "Avatar");
            DropColumn("dbo.Event", "Latitude");
            DropColumn("dbo.Event", "Longitude");
        }
    }
}
