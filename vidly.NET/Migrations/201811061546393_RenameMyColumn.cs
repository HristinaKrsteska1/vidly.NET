namespace vidly.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMyColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Rentals", "DateAdded", "DateReturned");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Rentals", "DateAdded", "DateReturned");
        }
    }
}
