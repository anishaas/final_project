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
        //private AppDbContext db = new AppDbContext();

        protected override void Seed(Final_Project_V2.Models.AppDbContext db)
        {

            //create a list of genres to add
            var genres = new List<Genre>
            {
                new Genre { GenreName = "Pop" },
                new Genre { GenreName = "Alternative" },
                new Genre { GenreName = "Dance" }, 
                new Genre { GenreName = "Country" },
                new Genre { GenreName = "Hip Hop/Rap" },
                new Genre { GenreName = "Holiday" },
                new Genre { GenreName = "Rock" },
                new Genre { GenreName = "J-Pop" },
                new Genre { GenreName = "Classical" },
                new Genre { GenreName = "Soundtrack" },
                new Genre { GenreName = "Progressive Trance" },
                new Genre { GenreName = "Comedy" },
                new Genre { GenreName = "Singer/Songwriter" },
                new Genre { GenreName = "Nu Metal" },
                new Genre { GenreName = "Children's Music" },
                new Genre { GenreName = "Folk" },
                new Genre { GenreName = "Reggae" },
                new Genre { GenreName = "House" }
               };
            //add to database
            genres.ForEach(g => db.Genres.AddOrUpdate(x => x.GenreName, g));
            db.SaveChanges();

            //create a list of artists
            var artists = new List<Artist>
            {
                new Artist { ArtistName = "LMFAO"},
                new Artist { ArtistName = "ADELE"},
                new Artist { ArtistName = "Foster the People"},
                new Artist { ArtistName = "Maroon 5"},
                new Artist { ArtistName = "David Guetta"},
                new Artist { ArtistName = "Usher"},
                new Artist { ArtistName = "Lady GaGa"},
                new Artist { ArtistName = "Rihanna"},
                new Artist { ArtistName = "Blake Shelton"},
                new Artist { ArtistName = "Nicki Minaj"},
                new Artist { ArtistName = "Kanye West"},
                new Artist { ArtistName = "JAY Z"},
                new Artist { ArtistName = "Luke Bryan"},
                new Artist { ArtistName = "The Band Perry"},
                new Artist { ArtistName = "Selena Gomez & the Scene"},
                new Artist { ArtistName = "Lady Antebellum"},
                new Artist { ArtistName = "Eli Young Band"},
                new Artist { ArtistName = "The Byars Family"},
                new Artist { ArtistName = "Drake"},
                new Artist { ArtistName = "Gym Class Heroes"},
                new Artist { ArtistName = "Justin Bieber"},
                new Artist { ArtistName = "Coldplay"},
                new Artist { ArtistName = "Snoop Dogg"},
                new Artist { ArtistName = "Wiz Khalifa"},
                new Artist { ArtistName = "Cobra Starship"},
                new Artist { ArtistName = "Jason Derulo"},
                new Artist { ArtistName = "Kelly Clarkson"},
                new Artist { ArtistName = "T-Pain"},
                new Artist { ArtistName = "Flo Rida"},
                new Artist { ArtistName = "DEV"},
                new Artist { ArtistName = "Bruno Mars"},
                new Artist { ArtistName = "Christina Perri"},
                new Artist { ArtistName = "B.o.B"},
                new Artist { ArtistName = "Pitbull"},
                new Artist { ArtistName = "Wale"},
                new Artist { ArtistName = "Alexandra Stan"},
                new Artist { ArtistName = "Nickelback"},
                new Artist { ArtistName = "Rick Ross"},
                new Artist { ArtistName = "Waka Flocka Flame"},
                new Artist { ArtistName = "Florence + the Machine"},
                new Artist { ArtistName = "Jessie J"},
                new Artist { ArtistName = "Martin Solveig & Dragonette"},
                new Artist { ArtistName = "Jake Owen"},
                new Artist { ArtistName = "Sean Paul"},
                new Artist { ArtistName = "Miranda Lambert"},
                new Artist { ArtistName = "Hot Chelle Rae"},
                new Artist { ArtistName = "Roscoe Dash"},
                new Artist { ArtistName = "Chevelle"},
                new Artist { ArtistName = "James Bay"},
                new Artist { ArtistName = "Ariana Grande"},
                new Artist { ArtistName = "Sam Hunt"},
                new Artist { ArtistName = "One Direction"},
                new Artist { ArtistName = "Nick Jonas"},
                new Artist { ArtistName = "Mark Ronson"},
                new Artist { ArtistName = "Hozier"},
                new Artist { ArtistName = "Kendrick Lamar"},
                new Artist { ArtistName = "FLOW"},
                new Artist { ArtistName = "Hans Zimmer"},
                new Artist { ArtistName = "James Newton Howard"},
                new Artist { ArtistName = "Andain"},
                new Artist { ArtistName = "Bryant Oden"},
                new Artist { ArtistName = "Linkin Park"},
                new Artist { ArtistName = "Julian Smith"},
                new Artist { ArtistName = "Malvina Reynolds"},
                new Artist { ArtistName = "Peter, Paul & Mary"},
                new Artist { ArtistName = "Bobby McFerrin"},
                new Artist { ArtistName = "Calvin Harris"},
            };

            //add artists to database
            artists.ForEach(a => db.Artists.AddOrUpdate(b => b.ArtistName, a));
            db.SaveChanges();
            //update the artists genres
            AddOrUpdateArtistGenre(db, "LMFAO", "Pop");
            AddOrUpdateArtistGenre(db, "ADELE", "Pop");
            AddOrUpdateArtistGenre(db, "Foster The People", "Alternative");
            AddOrUpdateArtistGenre(db, "Maroon 5", "Pop");
            AddOrUpdateArtistGenre(db, "David Guetta", "Dance");
            AddOrUpdateArtistGenre(db, "Usher", "Dance");
            AddOrUpdateArtistGenre(db, "Lady GaGa", "Pop");
            AddOrUpdateArtistGenre(db, "Rihanna", "Pop");
            AddOrUpdateArtistGenre(db, "Blake Shelton", "Pop");
            AddOrUpdateArtistGenre(db, "Nicki Minaj", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Kanye West", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "JAY Z", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Drake", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Luke Bryan", "Country");
            AddOrUpdateArtistGenre(db, "The Band Perry", "Country");
            AddOrUpdateArtistGenre(db, "Selena Gomez & the Scene", "Pop");
            AddOrUpdateArtistGenre(db, "Lady Antebellum", "Country");
            AddOrUpdateArtistGenre(db, "Eli Young Band", "Country");
            AddOrUpdateArtistGenre(db, "The Byars Family", "Country");
            AddOrUpdateArtistGenre(db, "Gym Class Heroes", "Pop");
            AddOrUpdateArtistGenre(db, "Justin Bieber", "Holiday");
            AddOrUpdateArtistGenre(db, "Coldplay", "Alternative");
            AddOrUpdateArtistGenre(db, "Snoop Dogg", "Hip Hop/Rap"); 
            AddOrUpdateArtistGenre(db, "Wiz Khalifa", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Cobra Starship", "Alternative");
            AddOrUpdateArtistGenre(db, "Jason Derulo", "Pop");
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
            AddOrUpdateArtistGenre(db, "Sam Hunt", "Country");
            AddOrUpdateArtistGenre(db, "One Direction", "Pop");
            AddOrUpdateArtistGenre(db, "Nick Jonas", "Pop");
            AddOrUpdateArtistGenre(db, "Mark Ronson", "Pop");
            AddOrUpdateArtistGenre(db, "Hozier", "Alternative");
            AddOrUpdateArtistGenre(db, "Kendrick Lamar", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "FLOW", "Pop");
            AddOrUpdateArtistGenre(db, "FLOW", "J-Pop");
            AddOrUpdateArtistGenre(db, "Hans Zimmer", "Classical");
            AddOrUpdateArtistGenre(db, "Hans Zimmer", "Soundtrack"); 
            AddOrUpdateArtistGenre(db, "James Newton Howard", "Classical");
            AddOrUpdateArtistGenre(db, "James Newton Howard", "Soundtrack");
            AddOrUpdateArtistGenre(db, "Andain", "Progressive");
            AddOrUpdateArtistGenre(db, "Andain", "Trance");
            AddOrUpdateArtistGenre(db, "Andain", "Dance");
            AddOrUpdateArtistGenre(db, "Bryant Oden", "Comedy");
            AddOrUpdateArtistGenre(db, "Bryant Oden", "Children's Music");
            AddOrUpdateArtistGenre(db, "Bryant Oden", "Singer/Songwriter");
            AddOrUpdateArtistGenre(db, "Linkin Park", "Alternative");
            AddOrUpdateArtistGenre(db, "Linkin Park", "Nu Metal");
            AddOrUpdateArtistGenre(db, "Linkin Park", "Hip Hop/Rap");
            AddOrUpdateArtistGenre(db, "Julian Smith", "Comedy");
            AddOrUpdateArtistGenre(db, "Malvina Reynolds", "Folk");
            AddOrUpdateArtistGenre(db, "Peter, Paul & Mary", "Singer/Songwriter");
            AddOrUpdateArtistGenre(db, "Bobby McFerrin", "Reggae");
            AddOrUpdateArtistGenre(db, "Calvin Harris", "Pop");
            db.SaveChanges();

            var songs = new List<Song>
            {
                //ADELE
                new Song { SongTitle = "Rolling In The Deep", SongPrice = 1.29M },
                new Song { SongTitle = "Rumour Has It", SongPrice = 0.89M },
                new Song { SongTitle = "Turning Tables", SongPrice = 1.29M },
                new Song { SongTitle = "Don't You Remember", SongPrice = 1.29M },
                new Song { SongTitle = "Set Fire to the Rain", SongPrice = 1.29M },
                new Song { SongTitle = "He Won't Go", SongPrice = 1.19M },
                new Song { SongTitle = "Take It All", SongPrice = 1.29M },
                new Song { SongTitle = "I'll Be Waiting", SongPrice = 1.29M },
                new Song { SongTitle = "One And Only", SongPrice = 0.99M },
                new Song { SongTitle = "Lovesong", SongPrice = 1.29M },
                new Song { SongTitle = "Someone Like You", SongPrice = 0.99M },
                new Song { SongTitle = "I Found A Boy", SongPrice = 1.29M },
                /*
                //Lady GaGa
                new Song { SongTitle = "Marry the Night", SongPrice = 1.29M },
                new Song { SongTitle = "Born This Way", SongPrice = 1.29M },
                new Song { SongTitle = "Government Hooker", SongPrice = 0.99M },
                new Song { SongTitle = "Judas", SongPrice = 1.29M },
                new Song { SongTitle = "Americano", SongPrice = 1.29M },
                new Song { SongTitle = "Hair", SongPrice = 1.39M },
                new Song { SongTitle = "Black Jesus + Amen Fashion", SongPrice = 1.29M },
                new Song { SongTitle = "Bad Kids", SongPrice = 1.49M },
                new Song { SongTitle = "Fashion of His Love", SongPrice = 0.89M },
                new Song { SongTitle = "Highway Unicorn (Road to Love)", SongPrice = 1.29M },
                new Song { SongTitle = "Heavy Metal Lover", SongPrice = 1.29M },
                new Song { SongTitle = "Electric Chapel", SongPrice = 0.89M },
                new Song { SongTitle = "The Queen", SongPrice = 1.29M },
                new Song { SongTitle = "You And I", SongPrice = 1.29M },
                new Song { SongTitle = "The Edge of Glory", SongPrice = 1.29M },
                //Florence
                new Song { SongTitle = "Only If For A Night", SongPrice = 0.99M },
                new Song { SongTitle = "Shake It Out", SongPrice = 1.29M },
                new Song { SongTitle = "What the Water Gave Me", SongPrice = 0.99M },
                new Song { SongTitle = "Never Let Me Go", SongPrice = 0.99M },
                new Song { SongTitle = "Breaking Down", SongPrice = 0.99M },
                new Song { SongTitle = "Lover to Lover", SongPrice = 0.99M },
                new Song { SongTitle = "No Light, No Light", SongPrice = 0.99M },
                new Song { SongTitle = "Seven Devils", SongPrice = 1.29M },
                new Song { SongTitle = "Spectrum", SongPrice = 1.29M },
                new Song { SongTitle = "Heartlines", SongPrice = 0.99M },
                new Song { SongTitle = "All of This and Heaven Too", SongPrice = 0.99M },
                new Song { SongTitle = "Leave My Body", SongPrice = 0.99M },
                new Song { SongTitle = "Remain Nameless", SongPrice = 0.99M },
                new Song { SongTitle = "Strangeness and Charm", SongPrice = 0.99M },
                new Song { SongTitle = "Bedroom Hymns", SongPrice = 0.99M },
                //James Bay
                new Song { SongTitle = "Craving", SongPrice = 1.29M },
                new Song { SongTitle = "Hold Back the River", SongPrice = 1.29M },
                new Song { SongTitle = "Let it Go", SongPrice = 1.29M },
                new Song { SongTitle = "If You Ever Want to Be in Love", SongPrice = 1.29M },
                new Song { SongTitle = "Best Fake Smile", SongPrice = 1.29M },
                new Song { SongTitle = "When We Were on Fire", SongPrice = 1.29M },
                new Song { SongTitle = "Move Together", SongPrice = 1.29M },
                new Song { SongTitle = "Scars", SongPrice = 1.29M },
                new Song { SongTitle = "Collide", SongPrice = 1.29M },
                new Song { SongTitle = "Get Out While You Can", SongPrice = 1.29M },
                new Song { SongTitle = "Need the Sun to Break", SongPrice = 1.29M },
                new Song { SongTitle = "Incomplete", SongPrice = 1.29M },
                //Julian Smith
                new Song { SongTitle = "Eat Randy", SongPrice = 1.29M },
                //Maroon 5
                new Song { SongTitle = "Misery", SongPrice = 0.99M },
                new Song { SongTitle = "Give a Little More", SongPrice = 1.29M },
                new Song { SongTitle = "Stutter", SongPrice = 1.29M },
                new Song { SongTitle = "Don't Know Nothing", SongPrice = 1.39M },
                new Song { SongTitle = "Never Gonna Leave This Bed", SongPrice = 0.89M },
                new Song { SongTitle = "I Can't Lie", SongPrice = 1.29M },
                new Song { SongTitle = "Hands All Over", SongPrice = 1.49M },
                new Song { SongTitle = "How", SongPrice = 1.29M },
                new Song { SongTitle = "Get Back In My Life", SongPrice = 1.29M } ,
                new Song { SongTitle = "Just a Feeling", SongPrice = 1.29M },
                new Song { SongTitle = "Runaway", SongPrice = 0.89M },
                new Song { SongTitle = "Out of Goodbyes", SongPrice = 1.29M },
                new Song { SongTitle = "Moves Like Jagger", SongPrice = 1.29M },
                new Song { SongTitle = "The Air That I Breathe", SongPrice = 1.29M },
                new Song { SongTitle = "Last Change", SongPrice = 1.29M },
                new Song { SongTitle = "No Curtain Call", SongPrice = 1.19M },
                new Song { SongTitle = "If I Ain't Got You", SongPrice = 1.29M },
                new Song { SongTitle = "The Air That I Breathe", SongPrice = 1.29M },
                //Drake
                new Song { SongTitle = "Legend", SongPrice = 0.99M },
                new Song { SongTitle = "Energy", SongPrice = 1.19M },
                new Song { SongTitle = "10 Bands", SongPrice = 0.99M },
                new Song { SongTitle = "Know Yourself", SongPrice = 0.99M },
                new Song { SongTitle = "No Tellin'", SongPrice = 0.99M },
                new Song { SongTitle = "Madonna", SongPrice = 0.99M },
                new Song { SongTitle = "6 God", SongPrice = 0.99M },
                new Song { SongTitle = "Star67", SongPrice = 0.99M },
                new Song { SongTitle = "Preach (feat. PARTYNEXTDOOR)", SongPrice = 0.99M },
                new Song { SongTitle = "Used To (feat.Lil Wayne)", SongPrice = 0.99M },
                new Song { SongTitle = "6 Man", SongPrice = 0.99M },
                new Song { SongTitle = "Now & Forever", SongPrice = 0.99M },
                new Song { SongTitle = "Company (feat. Travi$ Scott", SongPrice = 0.99M },
                new Song { SongTitle = "You & The 6", SongPrice = 0.99M },
                new Song { SongTitle = "Jungle'", SongPrice = 0.99M },
                new Song { SongTitle = "6PM In New York", SongPrice = 0.99M },
                new Song { SongTitle = "Even If It Breaks Your Heart", SongPrice = 1.29M },
                
                //Eli Young
                new Song { SongTitle = "Even If It Breaks Your Heart", SongPrice = 1.29M }
                new Song { SongTitle = "Crazy Girl", SongPrice = 0.89M }
                new Song { SongTitle = "On My Way", SongPrice = 1.29M }
                new Song { SongTitle = "Skeletons", SongPrice = 0.99M }
                new Song { SongTitle = "I Love Your", SongPrice = 1.29M }
                new Song { SongTitle = "The Fight", SongPrice = 1.29M }
                new Song { SongTitle = "My Old Man's Son", SongPrice = 1.29M }
                new Song { SongTitle = "Recover", SongPrice = 1.49M }
                new Song { SongTitle = "The Falling", SongPrice = 1.29M }
                new Song { SongTitle = "War On a Desperate Man", SongPrice = 1.29M }
                new Song { SongTitle = "Say Goodnight", SongPrice = 0.99M }
                new Song { SongTitle = "How Quickly You Forget", SongPrice = 1.29M }
                new Song { SongTitle = "Life At Best", SongPrice = 1.29M }
                new Song { SongTitle = "Room Goes Dark (Demo)", SongPrice = 1.39M }
                new Song { SongTitle = "Go Outside and Dance", SongPrice = 0.89M }
                new Song { SongTitle = "Me and Jack (Demo)", SongPrice = 1.29M }
                */
            };

            //Find record based on a property and add/update
            songs.ForEach(s => db.Songs.AddOrUpdate(y => y.SongTitle, s));
            db.SaveChanges();

            //add genre to song
            
            AddOrUpdateSongGenre(db,"Rolling In The Deep","Pop");
            AddOrUpdateSongGenre(db, "Rumour Has It", "Pop");
            AddOrUpdateSongGenre(db, "Turning Tables", "Pop");
            AddOrUpdateSongGenre(db, "Don't You Remember", "Pop");
            AddOrUpdateSongGenre(db, "Set Fire to the Rain", "Pop");
            AddOrUpdateSongGenre(db, "He Won't Go", "Pop");
            AddOrUpdateSongGenre(db, "Take It All", "Pop");
            AddOrUpdateSongGenre(db, "I'll Be Waiting", "Pop");
            AddOrUpdateSongGenre(db, "One and Only", "Pop");
            AddOrUpdateSongGenre(db, "Lovesong", "Pop");
            AddOrUpdateSongGenre(db, "Someone Like You", "Pop");
            AddOrUpdateSongGenre(db, "I Found A Boy", "Pop");
            /*
             //Lady GaGa
            AddOrUpdateSongGenre(db, "Marry the Night", "Pop");
            AddOrUpdateSongGenre(db, "Born This Way", "Pop");
            AddOrUpdateSongGenre(db, "Government Hooker", "Pop");
            AddOrUpdateSongGenre(db, "Judas", "Pop");
            AddOrUpdateSongGenre(db, "Americano", "Pop");
            AddOrUpdateSongGenre(db, "Hair", "Pop");
            AddOrUpdateSongGenre(db, "Bloody Mary", "Pop");
            AddOrUpdateSongGenre(db, "Black Jesus + Amen Fashion", "Pop");
            AddOrUpdateSongGenre(db, "Bad Kids", "Pop");
            AddOrUpdateSongGenre(db, "Fashion of His Love", "Pop");
            AddOrUpdateSongGenre(db, "Highway Unicorn (Road to Love)", "Pop");
            AddOrUpdateSongGenre(db, "Heavy Metal Lover", "Pop");
            AddOrUpdateSongGenre(db, "Electric Chapel", "Pop");
            AddOrUpdateSongGenre(db, "The Queen", "Pop");
            AddOrUpdateSongGenre(db, "You and I", "Pop");
            AddOrUpdateSongGenre(db, "The Edge of Glory", "Pop");

            //Florence
            AddOrUpdateSongGenre(db, "Only If For A Night", "Alternative");
            AddOrUpdateSongGenre(db, "Shake It Out", "Alternative");
            AddOrUpdateSongGenre(db, "What the Water Gave Me", "Alternative");
            AddOrUpdateSongGenre(db, "Never Let Me Go", "Alternative");
            AddOrUpdateSongGenre(db, "Breaking Down", "Alternative");
            AddOrUpdateSongGenre(db, "Lover to Lover", "Alternative");
            AddOrUpdateSongGenre(db, "No Light, No Light", "Alternative");
            AddOrUpdateSongGenre(db, "Seven Devils", "Alternative");
            AddOrUpdateSongGenre(db, "Heartlines", "Alternative");
            AddOrUpdateSongGenre(db, "Spectrum", "Alternative");
            AddOrUpdateSongGenre(db, "All of This and Heaven Too", "Alternative");
            AddOrUpdateSongGenre(db, "Leave My Body", "Alternative");
            AddOrUpdateSongGenre(db, "Remain Nameless", "Alternative");
            AddOrUpdateSongGenre(db, "Strangeness and Charm", "Alternative");
            AddOrUpdateSongGenre(db, "Bedroom Hymns", "Alternative");

            //James Bay
            AddOrUpdateSongGenre(db, "Craving", "Alternative");
            AddOrUpdateSongGenre(db, "Hold Back the River", "Alternative");
            AddOrUpdateSongGenre(db, "Let it Go", "Alternative");
            AddOrUpdateSongGenre(db, "If You Ever Want to Be in Love", "Alternative");
            AddOrUpdateSongGenre(db, "Best Fake Smile", "Alternative");
            AddOrUpdateSongGenre(db, "When We Were on Fire", "Alternative");
            AddOrUpdateSongGenre(db, "Move Together", "Alternative");
            AddOrUpdateSongGenre(db, "Scars", "Alternative");
            AddOrUpdateSongGenre(db, "Collide", "Alternative");
            AddOrUpdateSongGenre(db, "Get Out While You Can", "Alternative");
            AddOrUpdateSongGenre(db, "Need the Sun to Break", "Alternative");
            AddOrUpdateSongGenre(db, "Incomplete", "Alternative");

            //Julian Smith
            AddOrUpdateSongGenre(db, "Eat Randy", "Comedy");
            */

            //add artist to song
            AddOrUpdateSongArtist(db, "Rolling In The Deep", "ADELE");
            AddOrUpdateSongArtist(db, "Rumour Has It", "ADELE");
            AddOrUpdateSongArtist(db, "Turning Tables", "ADELE");
            AddOrUpdateSongArtist(db, "Don't You Remember", "ADELE");
            AddOrUpdateSongArtist(db, "Set Fire to the Rain", "ADELE");
            AddOrUpdateSongArtist(db, "He Won't Go", "ADELE");
            AddOrUpdateSongArtist(db, "Take It All", "ADELE");
            AddOrUpdateSongArtist(db, "I'll Be Waiting", "ADELE");
            AddOrUpdateSongArtist(db, "One and Only", "ADELE");
            AddOrUpdateSongArtist(db, "Lovesong", "ADELE");
            AddOrUpdateSongArtist(db, "Someone Like You", "ADELE");
            AddOrUpdateSongArtist(db, "I Found a Boy", "ADELE");
            /*
              //Lady GaGa
            AddOrUpdateSongArtist(db, "Marry the Night", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Born This Way", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Government Hooker", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Judas", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Americano", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Hair", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Bloody Mary", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Black Jesus + Amen Fashion", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Bad Kids", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Fashion of His Love", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Highway Unicorn (Road to Love)", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Heavy Metal Lover", "Lady GaGa");
            AddOrUpdateSongArtist(db, "Electric Chapel", "Lady GaGa");
            AddOrUpdateSongArtist(db, "The Queen", "Lady GaGa");
            AddOrUpdateSongArtist(db, "You and I", "Lady GaGa");
            AddOrUpdateSongArtist(db, "The Edge of Glory", "Lady GaGa");

            //Florence
            AddOrUpdateSongArtist(db, "Only If For A Night", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Shake It Out", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "What the Water Gave Me", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Never Let Me Go", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Breaking Down", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Lover to Lover", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "No Light, No Light", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Seven Devils", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Heartlines", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Spectrum", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "All of This and Heaven Too", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Leave My Body", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Remain Nameless", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Strangeness and Charm", "Florence + the Machine");
            AddOrUpdateSongArtist(db, "Bedroom Hymns", "Florence + the Machine");
            */
            db.SaveChanges();

            /*
            //create a album
            Album album1 = new Album();
            album1.AlbumArtist = db.Artists.FirstOrDefault(a => a.ArtistName == "Drake");
            album1.AlbumName = "Sorry for Party Rocking (Deluxe Version)";
            album1.AlbumPrice = 9.99M;
            db.Albums.AddOrUpdate(a => a.AlbumName, album1);
            db.Albums.AddOrUpdate(a => a.AlbumPrice, album1);
            db.SaveChanges();

            //find the album just created
            album1 = db.Albums.FirstOrDefault(a => a.AlbumName == "Sorry for Party Rocking (Deluxe Version)" && a.AlbumArtist.ArtistName == "LMFAO");
            album1.AlbumGenres.Add(db.Genres.FirstOrDefault(a => a.GenreName == "Pop"));
            db.SaveChanges();

            //add genre to album
            AddOrUpdateAlbumGenre(db, "Sorry for Party Rocking (Deluxe Version)", "Pop");
            db.SaveChanges();
            */
            //create album list
            var albums = new List<Album>
            {
               new Album { AlbumName = "21", AlbumPrice = 10.99M},
               //new Album { AlbumName = "Loud",  AlbumPrice = 9.99M},
               //new Album { AlbumName = "If You're Reading This It's Too Late", AlbumGenres = new List<Genre>(), AlbumPrice = 12.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Torches", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Hands All Over", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Hands All Over (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 14.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Nothing But the Beat", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Born This Way", AlbumGenres = new List<Genre>(), AlbumPrice = 14.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Red River Blue (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 11.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Pink Friday (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 14.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Watch The Throne (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 14.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Tailgates & Tanlines", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "The Band Perry", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "When the Sun Goes Down", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Own the Night", AlbumGenres = new List<Genre>(), AlbumPrice = 10.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Life At Best (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 11.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Songs From the Heart", AlbumGenres = new List<Genre>(), AlbumPrice = 13.37M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Chaos and the Calm", AlbumGenres = new List<Genre>(), AlbumPrice = 10.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "My Everything (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 12.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Ceremonials (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 10.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Sorry for Party Rocking (Deluxe Version)", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Montevallo", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "X2C", AlbumGenres = new List<Genre>(), AlbumPrice = 3.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "The Best of Bobby McFerrin", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "Eat Randy - Single", AlbumGenres = new List<Genre>(), AlbumPrice = 1.29M, AlbumSongs = new List<Song>() },
            //    new Album { AlbumName = "The Duck song (The Duck and the Lemonade Stand)", AlbumGenres = new List<Genre>(), AlbumPrice = 1.29M, AlbumSongs = new List<Song>() },
             };

            ////add to database
            albums.ForEach(a => db.Albums.AddOrUpdate(y => y.AlbumName, a));
            db.SaveChanges();

            AddOrUpdateAlbumGenre(db, "21", "Pop");
            //AddOrUpdateAlbumGenre(db, "Loud", "Pop");
            //AddOrUpdateAlbumGenre(db, "If You're Reading This It's Too Late", "Hip Hop/Rap");

            //AddOrUpdateAlbumGenre(db, "Sorry for Party Rocking (Deluxe Version)", "Pop");
            //AddOrUpdateAlbumGenre(db, "Torches", "Alternative");
            //AddOrUpdateAlbumGenre(db, "Hands All Over", "Pop");
            //AddOrUpdateAlbumGenre(db, "Hands All Over (Deluxe Version)", "Pop");
            //AddOrUpdateAlbumGenre(db, "Nothing But the Beat", "Dance");
            //AddOrUpdateAlbumGenre(db, "Born This Way", "Pop");
            //AddOrUpdateAlbumGenre(db, "Red River Blue (Deluxe Version)", "Country");
            //AddOrUpdateAlbumGenre(db, "Red River Blue (Deluxe Version)", "Pop");
            //AddOrUpdateAlbumGenre(db, "Pink Friday (Deluxe Version)", "Hip Hop/Rap");
            //AddOrUpdateAlbumGenre(db, "Watch The Throne (Deluxe Version)", "Hop Hop/Rap");
            //AddOrUpdateAlbumGenre(db, "Tailgates & Tanlines", "Country");
            //AddOrUpdateAlbumGenre(db, "The Band Perry", "Country");
            //AddOrUpdateAlbumGenre(db, "When the Sun Goes Down", "Pop");
            //AddOrUpdateAlbumGenre(db, "Own the Night", "Country");
            //AddOrUpdateAlbumGenre(db, "Life At Best (Deluxe Version)", "Country");
            //AddOrUpdateAlbumGenre(db, "Songs From the Heart", "Country");
            //AddOrUpdateAlbumGenre(db, "Chaos and the Calm", "Alternative");
            //AddOrUpdateAlbumGenre(db, "My Everything (Deluxe Version", "Pop");
            //AddOrUpdateAlbumGenre(db, "Ceremonials (Deluxe Version)", "Alternative");
            //AddOrUpdateAlbumGenre(db, "Montevallo", "Country");
            //AddOrUpdateAlbumGenre(db, "X2C", "Country");
            //AddOrUpdateAlbumGenre(db, "The Best of Bobby McFerrin", "Reggae");
            //AddOrUpdateAlbumGenre(db, "Eat Randy - Single", "Comedy");
            //AddOrUpdateAlbumGenre(db, "The Duck Song (The Duck and the Lemonade Stand)", "Comedy");
            //AddOrUpdateAlbumGenre(db, "The Duck Song (The Duck and the Lemonade Stand)", "Children's Music");
            //AddOrUpdateAlbumGenre(db, "The Duck Song (The Duck and the Lemonade Stand)", "Singer/Songwriter");
            //db.SaveChanges();
            //AddOrUpdateArtistAlbum(db, "Drake", "If You're Reading This It's Too Late");
            //AddOrUpdateArtistAlbum(db, "ADELE", "21");
            //AddOrUpdateArtistAlbum(db, "Rihanna", "Loud");

            AddOrUpdateAlbumArtist(db, "21", "ADELE");

            /*
            AddOrUpdateAlbumArtist(db, "Sorry for Party Rocking (Deluxe Version)", "LMFAO");
            AddOrUpdateAlbumArtist(db, "Torches", "Foster The People");
            AddOrUpdateAlbumArtist(db, "Hands All Over", "Maroon 5");
            AddOrUpdateAlbumArtist(db, "Hands All Over (Deluxe Version)", "Maroon 5");
            AddOrUpdateAlbumArtist(db, "Nothing But the Beat", "David Guetta & Usher");
            AddOrUpdateAlbumArtist(db, "Born This Way", "Lady GaGa");
            AddOrUpdateAlbumArtist(db, "Loud", "Rihanna");
            AddOrUpdateAlbumArtist(db, "Red River Blue (Deluxe Version)", "Blake Shleton");
            AddOrUpdateAlbumArtist(db, "Pink Friday (Deluxe Version)", "Nicki Minaj");
            AddOrUpdateAlbumArtist(db, "Watch The Throne (Deluxe Version)", "Kanye West & JAY Z");
            AddOrUpdateAlbumArtist(db, "Tailgates & Tanlines", "Luke Bryan");
            AddOrUpdateAlbumArtist(db, "The Band Perry", "The Band perry");
            AddOrUpdateAlbumArtist(db, "When the SUn Goes Down", "Selena Gomez & the Scene");
            AddOrUpdateAlbumArtist(db, "Own the Night", "Lady Antebellum");
            AddOrUpdateAlbumArtist(db, "Life At Best (Deluxe Version)", "Eli Young Band");
            AddOrUpdateAlbumArtist(db, "Songs From the Heart", "The Byars Family");
            AddOrUpdateAlbumArtist(db, "Chaos and the Calm", "James Bay");
            AddOrUpdateAlbumArtist(db, "My Everything (Deluxe Version", "Ariana Grande");
            AddOrUpdateAlbumArtist(db, "Ceremonials (Deluxe Version)", "Florence + The Machine");
            AddOrUpdateAlbumArtist(db, "If You're Reading This It's Too Late", "Drake");
            AddOrUpdateAlbumArtist(db, "Montevallo", "Sam Hunt");
            AddOrUpdateAlbumArtist(db, "X2C", "Sam Hunt");
            AddOrUpdateAlbumArtist(db, "The Best of Bobby McFerrin", "Bobby McFerrin");
            AddOrUpdateAlbumArtist(db, "Eat Randy - Single", "Julian Smith");
            AddOrUpdateAlbumArtist(db, "The Duck Song (The Duck and the Lemonade Stand)", "Bryant Oden");
            */
            db.SaveChanges();

            //add album to song
            AddOrUpdateSongAlbum(db, "Rolling In the Deep", "21");
            AddOrUpdateSongAlbum(db, "Rumour Has It", "21");
            AddOrUpdateSongAlbum(db, "Turning Tables", "21");
            AddOrUpdateSongAlbum(db, "Don't You Remember", "21");
            AddOrUpdateSongAlbum(db, "Set Fire to the Rain", "21");
            AddOrUpdateSongAlbum(db, "He Won't Go", "21");
            AddOrUpdateSongAlbum(db, "Take It All", "21");
            AddOrUpdateSongAlbum(db, "I'll Be Waiting", "21");
            AddOrUpdateSongAlbum(db, "One and Only", "21");
            AddOrUpdateSongAlbum(db, "Lovesong", "21");
            AddOrUpdateSongAlbum(db, "Someone Like You", "21");
            AddOrUpdateSongAlbum(db, "I Found a Boy", "21");
            //    AddOrUpdateSongAlbum(db, "Energy", "If You're Reading This It's Too Late");
            //    AddOrUpdateSongAlbum(db, "S&M", "Loud");
        }


        //add artist to the album
        void AddOrUpdateSongArtist(AppDbContext db, string songName, string artistName)
        {
            //find specified song
            Song song = db.Songs.SingleOrDefault(s => s.SongTitle == songName);
            //find specified artist
            Artist artist = db.Artists.SingleOrDefault(a => a.ArtistName == artistName);
            //add artist to song
            song.SongArtist = artist;
        }

        //add artist to the album
        void AddOrUpdateAlbumArtist(AppDbContext db, string albumName, string artistName)
        {
            //find specified artist
            Artist artist = db.Artists.SingleOrDefault(a => a.ArtistName == artistName);
            //find specified album
            Album album = db.Albums.SingleOrDefault(a => a.AlbumName == albumName);
            //add artist to album
            album.AlbumArtist = artist;
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

        //add genre to the song
        void AddOrUpdateSongGenre(AppDbContext db, string songName, string genreName)
        {
            //find specified genre
            Genre genre = db.Genres.SingleOrDefault(g => g.GenreName == genreName);
            //find specified song
            Song song = db.Songs.SingleOrDefault(s => s.SongTitle == songName);
            //add genre to song
            song.SongGenres.Add(genre);
        }

        //add genre to the album
        void AddOrUpdateAlbumGenre(AppDbContext db, string albumName, string genreName)
        {
            //find specified genre
            Genre genre = db.Genres.SingleOrDefault(g => g.GenreName == genreName);
            //find specified artist
            Album album = db.Albums.SingleOrDefault(a => a.AlbumName == albumName);
            //add genre to artist
            album.AlbumGenres.Add(genre);
        }

        //add album to the song
        void AddOrUpdateSongAlbum(AppDbContext db, string songName, string albumName)
        {
            //find specified song
            Song song = db.Songs.SingleOrDefault(s => s.SongTitle == songName);
            //find specified album
            Album album = db.Albums.SingleOrDefault(a => a.AlbumName == albumName);
            //add album to song
            song.SongAlbums.Add(album);
        }

        //add album to the artist
        void AddOrUpdateArtistAlbum(AppDbContext db, string artistName, string albumName)
        {
            //find specified album
            Album album = db.Albums.SingleOrDefault(a => a.AlbumName == albumName);
            //find specified artist
            Artist artist = db.Artists.SingleOrDefault(a => a.ArtistName == artistName);
            //add genre to artist
            artist.ArtistAlbums.Add(album);
        }

        //create a user manager to add users to the database
        }
    }

