namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingSongModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "SongPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "SongPrice");
        }
    }
}
