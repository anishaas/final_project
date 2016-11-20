namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using Final_Project_V2.Models;
    
    internal sealed class Configuration : DbMigrationsConfiguration<Final_Project_V2.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();
   
        protected override void Seed(Final_Project_V2.Models.AppDbContext context)
        {
            //create a list of genres to add
            var genres = new List<Genre>
            {
                new Genre { GenreName = "Alternative" },
                new Genre { GenreName = "Dance, House" },
                new Genre { GenreName = "Reggae" },
                new Genre { GenreName = "J-Pop" },
                new Genre { GenreName = "Folk" },
                new Genre { GenreName = "Singer/Songwriter" },
                new Genre { GenreName = "Holiday" },
                new Genre { GenreName = "Classical" },
                new Genre { GenreName = "Soudtrack" },
                new Genre { GenreName = "Progressive Trance" },
                new Genre { GenreName = "Nu Metal" },
                new Genre { GenreName = "Dance" },
                new Genre { GenreName = "Children's Music" },
                new Genre { GenreName = "Comedy" },
               };
            //add to database
                genres.ForEach(g => db.Genres.AddOrUpdate(x => x.GenreName, g));
                db.SaveChanges();

            //create a list of artists
            var artists = new List<Artist>
            {
                new Artist { ArtistName = "Drake", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "ADELE", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Rihanna", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Sam Hunt", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Eli Young Band", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Foster the People", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Bryent Oden", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Kanye West & JAY Z", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Calvin Harris", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "FLOW", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Hans Zimmer & James Newton Howard", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Justin Bieber", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Coldplay", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Snoop Dogg & Wiz Khalifa", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Cobra Starship", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Kelly Clarkson", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Selena Gomez & the Scene", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "T-Pain", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Flo-Rida", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "DEV", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Bruno Mars", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Christina Perri", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "B.o.B", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Pitbull", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Wale", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Alexandra Stan", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Nickleback", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Rick Ross", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Waka Flocka Flame", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Florence + the Machine", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Jessie J", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Martin Solvieg & Dragonette", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Jake Owen", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Sean Paul", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Hot Chelle Rae", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Miranda Lambert", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Roscoe Dash", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Chevelle", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "One Direction", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Nick Jonas", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Mark Ronson", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Hozier", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Kendrick Lamar", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Lady GaGa", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "James Bay", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Ariana Grande", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Maroon 5", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "David Guetta & Usher", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Lady Antebellum", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Nicki Minaj", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Blake Shelton", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "The Byars Family", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "LMFAO", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Luke Bryan", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "The Band Perry", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Bobby McFerrin", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Malvina Reynolds", ArtistGenres = new List<Genre>()},
                new Artist { ArtistName = "Peter, Paul & Mary", ArtistGenres = new List<Genre>()}
            };
                //add to database
                artists.ForEach(a => db.Artists.AddOrUpdate(b => b.ArtistName, a));
                db.SaveChanges();

            AddOrUpdateArtistGenre(db, "Drake", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "ADELE", "Pop");
            AddOrUpdateArtistGenre(db, "Rihanna", "Pop");
            AddOrUpdateArtistGenre(db, "Sam Hunt", "Country");
            AddOrUpdateArtistGenre(db, "Eli Young Band", "Country");
            AddOrUpdateArtistGenre(db, "Foster The People", "Alternative");
            AddOrUpdateArtistGenre(db, "Kanye West & JAY Z", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Calvin Harris", "Pop");
            AddOrUpdateArtistGenre(db, "LMFAO", "Pop");
            AddOrUpdateArtistGenre(db, "Maroon 5","Pop");
            AddOrUpdateArtistGenre(db, "David Guetta & Usher","Dance");
            AddOrUpdateArtistGenre(db, "Lady GaGa", "Pop");
            AddOrUpdateArtistGenre(db, "Blake Shelton", "Pop");
            AddOrUpdateArtistGenre(db, "Nicki Minaj", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Luke Bryan", "Country");
            AddOrUpdateArtistGenre(db, "The Band Perry", "Country");
            AddOrUpdateArtistGenre(db, "Selena Gomez & the Scene", "Pop");
            AddOrUpdateArtistGenre(db, "Lady Antebellum", "Country");
            AddOrUpdateArtistGenre(db, "The Byars Family", "Country");
            AddOrUpdateArtistGenre(db, "Gym Class Heroes", "Pop");
            AddOrUpdateArtistGenre(db, "Justin Bieber", "Holiday");
            AddOrUpdateArtistGenre(db, "Coldplay", "Alternative");
            AddOrUpdateArtistGenre(db, "Snoop Dogg & Wiz Khalifa", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Cobra Starship", "Alternative");
            AddOrUpdateArtistGenre(db, "Jason Derula", "Pop");
            AddOrUpdateArtistGenre(db, "Kelly Clarkson", "Pop");
            AddOrUpdateArtistGenre(db, "T-Pain", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Flo Rida", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "DEV", "Pop");
            AddOrUpdateArtistGenre(db, "Christina Perri", "Alternative");
            AddOrUpdateArtistGenre(db, "B.o.B", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Pitbull", "Pop");
            AddOrUpdateArtistGenre(db, "Wale", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Alexandra Stan", "Dance");
            AddOrUpdateArtistGenre(db, "Nickelback", "Rock");
            AddOrUpdateArtistGenre(db, "Rick Ross", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Waka Flocka Flame", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Florence + the Machine", "Alternative");
            AddOrUpdateArtistGenre(db, "Jessie J", "Pop");
            AddOrUpdateArtistGenre(db, "Martin Solveig & Dragonette", "Dance");
            AddOrUpdateArtistGenre(db, "Jake Owen", "Country");
            AddOrUpdateArtistGenre(db, "Sean Paul", "Pop");
            AddOrUpdateArtistGenre(db, "Miranda Lambert", "Country");
            AddOrUpdateArtistGenre(db, "Hot Chelle Rae", "Pop");
            AddOrUpdateArtistGenre(db, "Roscoe Dash", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Chevelle", "Rock");
            AddOrUpdateArtistGenre(db, "James Bay", "Alternative");
            AddOrUpdateArtistGenre(db, "Ariana Grande", "Pop");
            AddOrUpdateArtistGenre(db, "One Direction", "Pop");
            AddOrUpdateArtistGenre(db, "Nick Jonas", "Pop");
            AddOrUpdateArtistGenre(db, "Mark Ronson", "Pop");
            AddOrUpdateArtistGenre(db, "Hozier", "Alternative");
            AddOrUpdateArtistGenre(db, "FLOW", "Pop");
            AddOrUpdateArtistGenre(db, "FLOW", "J-Pop");
            AddOrUpdateArtistGenre(db, "Hans Zimmer &James Newton Howard", "Classical");
            AddOrUpdateArtistGenre(db, "Hans Zimmer &James Newton Howard", "Soundtrack");
            AddOrUpdateArtistGenre(db, "FLOW", "Pop");
            AddOrUpdateArtistGenre(db, "Andain", "Progressive");
            AddOrUpdateArtistGenre(db, "Andain", "Trance");
            AddOrUpdateArtistGenre(db, "Andain", "Dance");
            AddOrUpdateArtistGenre(db, "Jay-Z & Linkin Park", "Alternative");
            AddOrUpdateArtistGenre(db, "Jay-Z & Linkin Park", "Nu Metal");
            AddOrUpdateArtistGenre(db, "Jay-Z & Linkin Park", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Bryant Oden", "Comedy");
            AddOrUpdateArtistGenre(db, "Bryant Oden", "Children's Music");
            AddOrUpdateArtistGenre(db, "Bryant Oden", "Singer/Songwriter");
            AddOrUpdateArtistGenre(db, "Julian Smith", "Comedy");
            AddOrUpdateArtistGenre(db, "Malvina Reynolds", "Folk");
            AddOrUpdateArtistGenre(db, "Peter, Paul & Mary", "Singer/Songwriter");
            AddOrUpdateArtistGenre(db, "Bobby McFerrin", "Reggae");
            AddOrUpdateArtistGenre(db, "Calvin Harris", "Pop");

            db.SaveChanges();
        }

        //add genre to the artist
        void AddOrUpdateArtistGenre(AppDbContext db, string artistName, string genreName)
        {
            //find specified genre
            Genre genre = db.Genres.SingleOrDefault(g => g.GenreName == genreName);
            //find specified artist
            Artist artist = db.Artists.SingleOrDefault(a => a.ArtistName == artistName);
            //add genre to artist
            artist.ArtistGenres.Add(genre);
        }
    }
}
