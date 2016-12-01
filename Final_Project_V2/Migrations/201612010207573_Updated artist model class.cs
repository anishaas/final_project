namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedartistmodelclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "SongArtist_ArtistID", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "SongArtist_ArtistID" });
            CreateTable(
                "dbo.ArtistSongs",
                c => new
                    {
                        Artist_ArtistID = c.Int(nullable: false),
                        Song_SongID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ArtistID, t.Song_SongID })
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_SongID, cascadeDelete: true)
                .Index(t => t.Artist_ArtistID)
                .Index(t => t.Song_SongID);
            
            DropColumn("dbo.Songs", "SongArtist_ArtistID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "SongArtist_ArtistID", c => c.Int());
            DropForeignKey("dbo.ArtistSongs", "Song_SongID", "dbo.Songs");
            DropForeignKey("dbo.ArtistSongs", "Artist_ArtistID", "dbo.Artists");
            DropIndex("dbo.ArtistSongs", new[] { "Song_SongID" });
            DropIndex("dbo.ArtistSongs", new[] { "Artist_ArtistID" });
            DropTable("dbo.ArtistSongs");
            CreateIndex("dbo.Songs", "SongArtist_ArtistID");
            AddForeignKey("dbo.Songs", "SongArtist_ArtistID", "dbo.Artists", "ArtistID");
        }
    }
}
