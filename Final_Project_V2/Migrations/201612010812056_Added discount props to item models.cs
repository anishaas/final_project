namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddiscountpropstoitemmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "AlbumDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Albums", "AlbumDiscountEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Songs", "SongDiscountEnabled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Albums", "SongDiscount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "SongDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Songs", "SongDiscountEnabled");
            DropColumn("dbo.Albums", "AlbumDiscountEnabled");
            DropColumn("dbo.Albums", "AlbumDiscount");
        }
    }
}
