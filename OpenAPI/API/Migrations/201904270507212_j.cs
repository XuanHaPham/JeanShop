namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Account", "Bday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "Bday", c => c.String());
        }
    }
}
