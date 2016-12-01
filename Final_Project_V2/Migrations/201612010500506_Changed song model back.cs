namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedsongmodelback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArtistSongs", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.ArtistSongs", "Song_SongID", "dbo.Songs");
            DropIndex("dbo.ArtistSongs", new[] { "Artist_ArtistID" });
            DropIndex("dbo.ArtistSongs", new[] { "Song_SongID" });
            AddColumn("dbo.Songs", "SongArtist_ArtistID", c => c.Int());
            CreateIndex("dbo.Songs", "SongArtist_ArtistID");
            AddForeignKey("dbo.Songs", "SongArtist_ArtistID", "dbo.Artists", "ArtistID");
            DropTable("dbo.ArtistSongs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ArtistSongs",
                c => new
                    {
                        Artist_ArtistID = c.Int(nullable: false),
                        Song_SongID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ArtistID, t.Song_SongID });
            
            DropForeignKey("dbo.Songs", "SongArtist_ArtistID", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "SongArtist_ArtistID" });
            DropColumn("dbo.Songs", "SongArtist_ArtistID");
            CreateIndex("dbo.ArtistSongs", "Song_SongID");
            CreateIndex("dbo.ArtistSongs", "Artist_ArtistID");
            AddForeignKey("dbo.ArtistSongs", "Song_SongID", "dbo.Songs", "SongID", cascadeDelete: true);
            AddForeignKey("dbo.ArtistSongs", "Artist_ArtistID", "dbo.Artists", "ArtistID", cascadeDelete: true);
        }
    }
}
