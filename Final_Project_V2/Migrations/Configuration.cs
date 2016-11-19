namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
<<<<<<< HEAD
    using Final_Project_V2.Models;
=======
    
>>>>>>> 0cd591cd7e96d0f45ac7499bbb006f781f38da10

    internal sealed class Configuration : DbMigrationsConfiguration<Final_Project_V2.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
<<<<<<< HEAD

        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

=======
        /*
>>>>>>> 0cd591cd7e96d0f45ac7499bbb006f781f38da10
        protected override void Seed(Final_Project_V2.Models.AppDbContext context)
        {
            //create a song to add
            Song song1 = new Song();
            song1.SongTitle = "Rolling in the Deep";
            db.Songs.AddOrUpdate(s => s.SongTitle, song1);
            db.SaveChanges();

            Genre genre1 = new Genre();
            genre1.GenreName = "Pop";
            db.Genres.AddOrUpdate(g => g.GenreName, genre1);
            db.SaveChanges();

            Album album1 = new Album();
            album1.AlbumName = "21";
            db.Albums.AddOrUpdate(a => a.AlbumName, album1);
            db.SaveChanges();

            Artist artist1 = new Artist();
            artist1.ArtistName = "ADELE";
            db.Artists.AddOrUpdate(a => a.ArtistName, artist1);
            db.SaveChanges();

            //find the song you just created in the database
           //song1 = db.Songs.FirstOrDefault(s => s.SongTitle == "Rolling in the Deep");
           song1.SongArtist = artist1;
           song1.SongGenre = genre1;
           //song1.SongAlbums = album1;
           //db.SaveChanges();
        }
        */
    }
}
