namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organization", "Avatar", c => c.String());
            AddColumn("dbo.Organization", "Background", c => c.String());
            AddColumn("dbo.Organization", "Longitude", c => c.Double());
            AddColumn("dbo.Organization", "Latitude", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organization", "Latitude");
            DropColumn("dbo.Organization", "Longitude");
            DropColumn("dbo.Organization", "Background");
            DropColumn("dbo.Organization", "Avatar");
        }
    }
}
