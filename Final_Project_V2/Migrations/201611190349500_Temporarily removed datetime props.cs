namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temporarilyremoveddatetimeprops : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Albums", "AlbumTimestamp");
            DropColumn("dbo.Artists", "ArtistTimeStamp");
            DropColumn("dbo.Genres", "GenreTimestamp");
            DropColumn("dbo.Songs", "SongTimestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "SongTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "GenreTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Artists", "ArtistTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Albums", "AlbumTimestamp", c => c.DateTime(nullable: false));
        }
    }
}
