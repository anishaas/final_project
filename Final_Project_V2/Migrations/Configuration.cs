namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Final_Project_V2.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Final_Project_V2.Models.AppDbContext context)
        {
            //create a song to add
            Song song1 = new Song();
            song1.Name = "Rolling in the Deep";
            db.Songs.AddOrUpdate(s => s.Name, song1);
            db.SaveChanges();

            //find the song you just created in the database
            song1 = db.Songs.FirstOrDefault(s => s.Name == "Rolling in the Deep");
            song1.Artists.Add(db.Artists.FirstOrDefault(a => a.Name == "ADELE"));
            song1.Genres.Add(db.Genres.FirstOrDefault(a => a.Name == "Pop"));
            song1.Albums.Add(db.Albums.FirstOrDefault(a => a.Name == "21"));
            db.SaveChanges();
        }
    }
}
