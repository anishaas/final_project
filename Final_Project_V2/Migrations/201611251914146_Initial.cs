namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        AlbumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumName = c.String(),
                        Featured = c.Boolean(nullable: false),
                        AlbumArtist_ArtistID = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Artists", t => t.AlbumArtist_ArtistID)
                .Index(t => t.AlbumArtist_ArtistID);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(),
                        Featured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        SongTitle = c.String(),
                        Featured = c.Boolean(nullable: false),
                        SongArtist_ArtistID = c.Int(),
                    })
                .PrimaryKey(t => t.SongID)
                .ForeignKey("dbo.Artists", t => t.SongArtist_ArtistID)
                .Index(t => t.SongArtist_ArtistID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountID = c.Int(nullable: false, identity: true),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountStatus = c.Boolean(nullable: false),
                        DiscountTimeStamp = c.DateTime(nullable: false),
                        DiscountedItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountID);
            
            CreateTable(
                "dbo.UserActivityClassifications",
                c => new
                    {
                        UserActivityClassificationID = c.Int(nullable: false, identity: true),
                        UserActivityClassificationType = c.Int(nullable: false),
                        UserActivityArg1 = c.String(),
                        UserActivityArg2 = c.String(),
                        UserActivityArg3 = c.String(),
                        UserActivityArg4 = c.String(),
                        UserActivityArg5 = c.String(),
                        UserActivityTxt1 = c.String(),
                        UserActivityTxt2 = c.String(),
                        UserActivityTxt3 = c.String(),
                        UserActivityTxt4 = c.String(),
                        UserActivityTxt5 = c.String(),
                        UserActivityClassificationTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserActivityClassificationID);
            
            CreateTable(
                "dbo.UserActivityInputs",
                c => new
                    {
                        UserActivityInputID = c.Int(nullable: false, identity: true),
                        UserActivityInputType = c.Int(nullable: false),
                        UserActivityInputArg1 = c.String(),
                        UserActivityInputArg2 = c.String(),
                        UserActivityInputArg3 = c.String(),
                        UserActivityInputArg4 = c.String(),
                        UserActivityInputArg5 = c.String(),
                        UserActivityInputTxt1 = c.String(),
                        UserActivityInputTxt2 = c.String(),
                        UserActivityInputTxt3 = c.String(),
                        UserActivityInputTxt4 = c.String(),
                        UserActivityInputTxt5 = c.String(),
                        UserActivityInputTimestamp = c.DateTime(nullable: false),
                        UserActivityInputClassificationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserActivityInputID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MI = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(),
                        CCNumber1 = c.String(),
                        CCType1 = c.String(),
                        CCNumber2 = c.String(),
                        CCType2 = c.String(),
                        SSN = c.String(),
                        EmpType = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.GenreArtists",
                c => new
                    {
                        Genre_GenreID = c.Int(nullable: false),
                        Artist_ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreID, t.Artist_ArtistID })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID, cascadeDelete: true)
                .Index(t => t.Genre_GenreID)
                .Index(t => t.Artist_ArtistID);
            
            CreateTable(
                "dbo.GenreSongs",
                c => new
                    {
                        Genre_GenreID = c.Int(nullable: false),
                        Song_SongID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreID, t.Song_SongID })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_SongID, cascadeDelete: true)
                .Index(t => t.Genre_GenreID)
                .Index(t => t.Song_SongID);
            
            CreateTable(
                "dbo.AlbumSongs",
                c => new
                    {
                        Album_AlbumID = c.Int(nullable: false),
                        Song_SongID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Album_AlbumID, t.Song_SongID })
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_SongID, cascadeDelete: true)
                .Index(t => t.Album_AlbumID)
                .Index(t => t.Song_SongID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AlbumSongs", "Song_SongID", "dbo.Songs");
            DropForeignKey("dbo.AlbumSongs", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.Albums", "AlbumArtist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.Songs", "SongArtist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.GenreSongs", "Song_SongID", "dbo.Songs");
            DropForeignKey("dbo.GenreSongs", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.GenreArtists", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.GenreArtists", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.GenreAlbums", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.GenreAlbums", "Genre_GenreID", "dbo.Genres");
            DropIndex("dbo.AlbumSongs", new[] { "Song_SongID" });
            DropIndex("dbo.AlbumSongs", new[] { "Album_AlbumID" });
            DropIndex("dbo.GenreSongs", new[] { "Song_SongID" });
            DropIndex("dbo.GenreSongs", new[] { "Genre_GenreID" });
            DropIndex("dbo.GenreArtists", new[] { "Artist_ArtistID" });
            DropIndex("dbo.GenreArtists", new[] { "Genre_GenreID" });
            DropIndex("dbo.GenreAlbums", new[] { "Album_AlbumID" });
            DropIndex("dbo.GenreAlbums", new[] { "Genre_GenreID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Songs", new[] { "SongArtist_ArtistID" });
            DropIndex("dbo.Albums", new[] { "AlbumArtist_ArtistID" });
            DropTable("dbo.AlbumSongs");
            DropTable("dbo.GenreSongs");
            DropTable("dbo.GenreArtists");
            DropTable("dbo.GenreAlbums");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserActivityInputs");
            DropTable("dbo.UserActivityClassifications");
            DropTable("dbo.Discounts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Songs");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
