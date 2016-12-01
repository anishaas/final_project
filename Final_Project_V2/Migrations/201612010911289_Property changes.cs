namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Propertychanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "AlbumDiscountedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Songs", "SongDiscountedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "SongDiscountedPrice");
            DropColumn("dbo.Albums", "AlbumDiscountedPrice");
        }
    }
}
