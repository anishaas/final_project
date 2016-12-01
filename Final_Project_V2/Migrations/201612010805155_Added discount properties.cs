namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddiscountproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "SongDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Songs", "SongDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "SongDiscount");
            DropColumn("dbo.Albums", "SongDiscount");
        }
    }
}
