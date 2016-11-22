namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedalbummodelclassgenreproperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "AlbumGenre_GenreID", "dbo.Genres");
            DropIndex("dbo.Albums", new[] { "AlbumGenre_GenreID" });
            CreateTable(
                "dbo.GenreAlbums",
                c => new
                    {
                        Genre_GenreID = c.Int(nullable: false),
                        Album_AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreID, t.Album_AlbumID })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID, cascadeDelete: true)
                .Index(t => t.Genre_GenreID)
                .Index(t => t.Album_AlbumID);
            
            DropColumn("dbo.Albums", "AlbumGenre_GenreID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "AlbumGenre_GenreID", c => c.Int());
            DropForeignKey("dbo.GenreAlbums", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.GenreAlbums", "Genre_GenreID", "dbo.Genres");
            DropIndex("dbo.GenreAlbums", new[] { "Album_AlbumID" });
            DropIndex("dbo.GenreAlbums", new[] { "Genre_GenreID" });
            DropTable("dbo.GenreAlbums");
            CreateIndex("dbo.Albums", "AlbumGenre_GenreID");
            AddForeignKey("dbo.Albums", "AlbumGenre_GenreID", "dbo.Genres", "GenreID");
        }
    }
}
