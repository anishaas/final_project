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

            /*
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
            */
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
                new Song { SongTitle = "Bloody Mary", SongPrice = 0.89M },
                new Song { SongTitle = "The Queen", SongPrice = 1.29M },
                new Song { SongTitle = "You And I", SongPrice = 1.29M },
                new Song { SongTitle = "The Edge of Glory", SongPrice = 1.29M },
                                
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
                new Song { SongTitle = "Even If It Breaks Your Heart", SongPrice = 1.29M },
                new Song { SongTitle = "Crazy Girl", SongPrice = 0.89M },
                new Song { SongTitle = "On My Way", SongPrice = 1.29M },
                new Song { SongTitle = "Skeletons", SongPrice = 0.99M },
                new Song { SongTitle = "I Love Your", SongPrice = 1.29M },
                new Song { SongTitle = "The Fight", SongPrice = 1.29M },
                new Song { SongTitle = "My Old Man's Son", SongPrice = 1.29M },
                new Song { SongTitle = "Recover", SongPrice = 1.49M },
                new Song { SongTitle = "The Falling", SongPrice = 1.29M },
                new Song { SongTitle = "War On a Desperate Man", SongPrice = 1.29M },
                new Song { SongTitle = "Say Goodnight", SongPrice = 0.99M },
                new Song { SongTitle = "How Quickly You Forget", SongPrice = 1.29M },
                new Song { SongTitle = "Life At Best", SongPrice = 1.29M },
                new Song { SongTitle = "Room Goes Dark (Demo)", SongPrice = 1.39M },
                new Song { SongTitle = "Go Outside and Dance", SongPrice = 0.89M },
                new Song { SongTitle = "Me and Jack (Demo)", SongPrice = 1.29M },
                
                //Rihanna
                new Song { SongTitle = "S&M", SongPrice = 1.19M },
                new Song { SongTitle = "What's My Name?", SongPrice = 1.29M },
                new Song { SongTitle = "Cheers", SongPrice = 1.29M },
                new Song { SongTitle = "Fading", SongPrice = 0.99M },
                new Song { SongTitle = "Only Girl (In the World)", SongPrice = 1.29M },
                new Song { SongTitle = "California King Bed", SongPrice = 0.99M },
                new Song { SongTitle = "Man Down", SongPrice = 1.29M },
                new Song { SongTitle = "Raining Men", SongPrice = 1.29M },
                new Song { SongTitle = "Complicated", SongPrice = 0.89M },
                new Song { SongTitle = "Skin", SongPrice = 1.29M },
                new Song { SongTitle = "Love The Way You Lie", SongPrice = 1.29M }, 
                
                //Sam Hunt
                new Song { SongTitle = "Take Your Time", SongPrice = 1.19M },
                new Song { SongTitle = "Leave the Night On", SongPrice = 1.19M },
                new Song { SongTitle = "House Party", SongPrice = 0.99M },
                new Song { SongTitle = "Break Up in a Small Town", SongPrice = 0.99M },
                new Song { SongTitle = "Single for the Summer", SongPrice = 0.89M },
                new Song { SongTitle = "Ex to See", SongPrice = 0.99M },
                new Song { SongTitle = "Make You Miss Me", SongPrice = 0.89M },
                new Song { SongTitle = "Cop Car", SongPrice = 0.99M },
                new Song { SongTitle = "Raised on It", SongPrice = 0.99M },
                new Song { SongTitle = "Speakers", SongPrice = 0.99M },
                
                //Ariana Grande
                new Song { SongTitle = "Intro", SongPrice = 0.89M },
                new Song { SongTitle = "Problem (feat. Iggy Azalea)", SongPrice = 1.29M },
                new Song { SongTitle = "One Last Time", SongPrice = 1.29M },
                new Song { SongTitle = "Why Try", SongPrice = 0.99M },
                new Song { SongTitle = "Break Free(feat.Zedd)", SongPrice = 1.29M },
                new Song { SongTitle = "Best Mistake (feat. Big Sean)", SongPrice = 0.99M },
                new Song { SongTitle = "Be My Baby (feat. Cashmere Cat)", SongPrice = 0.99M },
                new Song { SongTitle = "Break Your Heart Right Back (feat.Childish Gambino)", SongPrice = 0.99M },
                new Song { SongTitle = "Love Me Harder (feat. The Weeknd)", SongPrice = 1.29M },
                new Song { SongTitle = "Just A Little Bit of Your Heart", SongPrice = 0.99M },
                new Song { SongTitle = "Hands On Me (feat.A$AP Ferg)", SongPrice = 0.99M },
                new Song { SongTitle = "My Everything", SongPrice = 0.99M },
                new Song { SongTitle = "Bang Bang (feat. Jessie J and Nicki Minaj)", SongPrice = 1.29M },
                new Song { SongTitle = "Only 1", SongPrice = 0.89M },
                new Song { SongTitle = "You Don't Know Me", SongPrice = 0.99M },

                //David Guetta & Usher
                new Song { SongTitle = "Where Them Girls At", SongPrice = 0.99M },
                new Song { SongTitle = "Little Bad Girl", SongPrice = 1.29M },
                new Song { SongTitle = "Turn Me On", SongPrice = 0.99M },
                new Song { SongTitle = "Sweat", SongPrice = 1.29M },
                new Song { SongTitle = "Without You", SongPrice = 1.29M },
                new Song { SongTitle = "Nothing Really Matters", SongPrice = 0.89M },
                new Song { SongTitle = "I Can Only Imagine", SongPrice = 1.29M },
                new Song { SongTitle = "Crank It Up", SongPrice = 1.29M },
                new Song { SongTitle = "Lunar", SongPrice = 0.99M },
                new Song { SongTitle = "Night of Your Life", SongPrice = 1.29M },
                new Song { SongTitle = "Repeat", SongPrice = 0.89M },
                new Song { SongTitle = "Titanium,", SongPrice = 1.29M },
                new Song { SongTitle = "I'm A Machine", SongPrice = 1.49M },

                //Lady Antebellum
                new Song { SongTitle = "We Owned the Night", SongPrice = 1.29M },
                new Song { SongTitle = "Just a Kiss", SongPrice = 0.89M },
                new Song { SongTitle = "Dancin' Away With My Heart", SongPrice = 1.29M },
                new Song { SongTitle = "Friday Night", SongPrice = 1.29M },
                new Song { SongTitle = "When You Were Mine", SongPrice = 1.29M },
                new Song { SongTitle = "Cold As Stone", SongPrice = 1.19M },
                new Song { SongTitle = "Singing Me Home", SongPrice = 1.29M },
                new Song { SongTitle = "Wanted You More", SongPrice = 1.29M },
                new Song { SongTitle = "As Your Turn Away", SongPrice = 0.99M },
                new Song { SongTitle = "Love I've Found In You", SongPrice = 1.29M },
                new Song { SongTitle = "Somewhere Love Remains", SongPrice = 0.99M },
                new Song { SongTitle = "Heart of the World", SongPrice = 1.29M },

                //Nicki Minaj
                new Song { SongTitle = "Save Me", SongPrice = 1.29M },
                new Song { SongTitle = "Moment 4 Life", SongPrice = 1.29M },
                new Song { SongTitle = "Check It Out", SongPrice = 1.29M },
                new Song { SongTitle = "Blazin'", SongPrice = 1.19M },
                new Song { SongTitle = "Here I Am", SongPrice = 1.29M },
                new Song { SongTitle = "Dear Old Nicki", SongPrice = 1.29M },
                new Song { SongTitle = "Your Love", SongPrice = 0.99M },
                new Song { SongTitle = "Last Chance", SongPrice = 1.29M },
                new Song { SongTitle = "Super Bass", SongPrice = 0.99M },
                new Song { SongTitle = "Blow Ya Mind", SongPrice = 1.29M },
                new Song { SongTitle = "Muny", SongPrice = 1.29M },
                new Song { SongTitle = "Girls Fall Like Dominoes", SongPrice = 0.89M },

                //Blake Shelton
                new Song { SongTitle = "Honey Bee", SongPrice = 0.99M },
                new Song { SongTitle = "Ready to Roll", SongPrice = 1.29M },
                new Song { SongTitle = "God Gave Me You", SongPrice = 0.89M },
                new Song { SongTitle = "Get Some", SongPrice = 1.29M },
                new Song { SongTitle = "Drink On It", SongPrice = 1.49M },
                new Song { SongTitle = "Good Ole Boys", SongPrice = 1.29M },
                new Song { SongTitle = "I'm Sorry", SongPrice = 1.29M },
                new Song { SongTitle = "Sunny In Seattle", SongPrice = 0.99M },
                new Song { SongTitle = "Over", SongPrice = 1.29M },
                new Song { SongTitle = "Hey", SongPrice = 1.29M },
                new Song { SongTitle = "Red River Blue", SongPrice = 1.39M },
                new Song { SongTitle = "Chili", SongPrice = 0.89M },
                new Song { SongTitle = "Addicted", SongPrice = 1.29M },

                //The Byars Family
                new Song { SongTitle = "Ruby", SongPrice = 1.49M },
                new Song { SongTitle = "Old School", SongPrice = 1.29M },
                new Song { SongTitle = "Dancing In The Rain", SongPrice = 1.29M },
                new Song { SongTitle = "He's My Brother", SongPrice = 1.29M },
                new Song { SongTitle = "Lady Of Darkness", SongPrice = 0.89M },
                new Song { SongTitle = "Red Haired Beauty", SongPrice = 1.29M },
                new Song { SongTitle = "Once In A Life", SongPrice = 1.29M },
                new Song { SongTitle = "Life At The Doublewide", SongPrice = 1.29M },
                new Song { SongTitle = "Isabelle", SongPrice = 1.19M },
                new Song { SongTitle = "The Waltz", SongPrice = 1.29M },
                new Song { SongTitle = "Me And Eddy B", SongPrice = 1.29M },
                
                //LMFAO
                new Song { SongTitle = "Rock the Beat 2", SongPrice = 1.29M },
                new Song { SongTitle = "Sorry for Party Rocking", SongPrice = 1.49M },
                new Song { SongTitle = "Party Rock Anthem", SongPrice = 1.29M },
                new Song { SongTitle = "Sexy And I Know It", SongPrice = 1.29M },
                new Song { SongTitle = "Champagne Showers", SongPrice = 0.99M },
                new Song { SongTitle = "One Day", SongPrice = 1.29M },
                new Song { SongTitle = "Take It to the Hole", SongPrice = 1.29M },
                new Song { SongTitle = "We Came Here to Party", SongPrice = 1.39M },
                new Song { SongTitle = "Reminds Me of You", SongPrice = 0.89M },
                new Song { SongTitle = "Best Night", SongPrice = 1.29M },
                new Song { SongTitle = "All Night Long", SongPrice = 1.49M },
                new Song { SongTitle = "With You", SongPrice = 1.29M },
                new Song { SongTitle = "Hot Dog", SongPrice = 1.29M },

                //Luke Bryan
                new Song { SongTitle = "Country Girl (Shake It for Me)", SongPrice = 1.29M },
                new Song { SongTitle = "Kiss Tomorrow Goodbye", SongPrice = 1.49M },
                new Song { SongTitle = "Drunk On You", SongPrice = 1.29M },
                new Song { SongTitle = "Too Damn Young", SongPrice = 1.29M },
                new Song { SongTitle = "I Don't Want This Night to End", SongPrice = 1.29M },
                new Song { SongTitle = "You Don't Know Jack", SongPrice = 0.89M },
                new Song { SongTitle = "Harvest Time", SongPrice = 1.29M },
                new Song { SongTitle = "I Know You're Gonna Be There", SongPrice = 1.29M },
                new Song { SongTitle = "Muckalee Creek Water", SongPrice = 0.29M },
                new Song { SongTitle = "Tailgate Blues", SongPrice = 1.19M },
                new Song { SongTitle = "Been There, Done That", SongPrice = 1.29M },
                new Song { SongTitle = "Faded Away", SongPrice = 1.29M },
                new Song { SongTitle = "I Knew You That Way", SongPrice = 0.99M },

                //The Band Perry
                new Song { SongTitle = "If I Die Young", SongPrice = 1.29M },
                new Song { SongTitle = "All Your Life", SongPrice = 0.99M },
                new Song { SongTitle = "You Lie", SongPrice = 1.29M },
                new Song { SongTitle = "Hip to My Heart", SongPrice = 1.29M },
                new Song { SongTitle = "Walk Me Down the Middle", SongPrice = 0.89M },
                new Song { SongTitle = "Independence", SongPrice = 1.29M },
                new Song { SongTitle = "Lasso", SongPrice = 1.29M },
                new Song { SongTitle = "Postcard from Paris", SongPrice = 0.99M },
                new Song { SongTitle = "Quittin' You", SongPrice = 1.29M },
                new Song { SongTitle = "Miss You Being Gone", SongPrice = 0.89M },
                new Song { SongTitle = "Double Heart", SongPrice = 1.29M },
                
                //Bobby McFerrin
                new Song { SongTitle ="Don’t Worry, Be Happy", SongPrice = 1.29M},
                new Song { SongTitle ="Thinkin About Your Body", SongPrice = 1.29M},
                new Song { SongTitle ="Spain", SongPrice = 1.29M},
                new Song { SongTitle ="Freedom is a Voice", SongPrice = 1.29M},
                new Song { SongTitle ="Friends", SongPrice = 1.29M},
                new Song { SongTitle ="Drive My Car", SongPrice = 1.29M},
                new Song { SongTitle ="Another Night in Tunsia", SongPrice = 1.29M},
                new Song { SongTitle ="Blue Bossa", SongPrice = 1.29M},
                new Song { SongTitle ="Turtle Shoes", SongPrice = 1.29M},
                new Song { SongTitle ="Good Lovin'", SongPrice = 1.29M},
                new Song { SongTitle ="From Me To You", SongPrice = 1.29M},
                new Song { SongTitle ="Bang!Zoom", SongPrice = 1.29M},

                //Bryant Oden
                new Song { SongTitle ="The Duck Song", SongPrice = 1.29M},
                //Foster the People
                new Song { SongTitle ="Helena Beat", SongPrice = 1.29M},
                new Song { SongTitle ="Pumped Up Kicks", SongPrice = 0.89M},
                new Song { SongTitle ="Call It What You Want", SongPrice = 1.29M},
                new Song { SongTitle ="Don't Stop (Color On the Walls)", SongPrice = 1.29M},
                new Song { SongTitle ="Waste", SongPrice = 0.99M},
                new Song { SongTitle ="I Would Do Anything for You", SongPrice = 1.29M},
                new Song { SongTitle ="Houdini", SongPrice = 0.89M},
                new Song { SongTitle ="Life On the Nickel", SongPrice = 1.29M},
                new Song { SongTitle ="Miss You", SongPrice = 1.49M},
                new Song { SongTitle ="Warrant", SongPrice = 1.29M},
                new Song { SongTitle ="Broken Jaw", SongPrice = 1.29M},
                
                //Kanye Jay-Z
                new Song { SongTitle ="No Church in the Wild", SongPrice = 1.29M},
                new Song { SongTitle ="Lift Off", SongPrice = 1.29M},
                new Song { SongTitle ="Otis", SongPrice = 0.99M},
                new Song { SongTitle ="Gotta Have It", SongPrice = 1.29M},
                new Song { SongTitle ="New Day", SongPrice = 0.89M},
                new Song { SongTitle ="That's My Bitch", SongPrice = 1.29M},
                new Song { SongTitle ="Welcome to the Jungle", SongPrice = 1.49M},
                new Song { SongTitle ="Who Gon Stop Me", SongPrice = 1.29M},
                new Song { SongTitle ="Murder to Excellence", SongPrice = 1.29M},
                new Song { SongTitle ="Made in America", SongPrice = 0.99M},
                new Song { SongTitle ="Why I Love You", SongPrice = 1.29M},
                new Song { SongTitle ="H*a*m", SongPrice = 1.29M},
                new Song { SongTitle ="Primetime", SongPrice = 1.39M},
                new Song { SongTitle ="The Joy", SongPrice = 0.89M},              

                //Selena Gomez
                new Song { SongTitle ="Love You Like a Love Song", SongPrice = 1.49M},
                new Song { SongTitle ="Bang Bang Bang", SongPrice = 1.29M},
                new Song { SongTitle ="Who Says", SongPrice = 0.99M},
                new Song { SongTitle ="We Own the Night", SongPrice = 1.29M},
                new Song { SongTitle ="Hit the Lights", SongPrice = 1.29M},
                new Song { SongTitle ="Whiplash", SongPrice = 1.39M},
                new Song { SongTitle ="When the Sun Goes Down", SongPrice = 0.89M},
                new Song { SongTitle ="My Dilemma", SongPrice = 1.29M},
                new Song { SongTitle ="That's More Like It", SongPrice = 1.49M},
                new Song { SongTitle ="Outlaw", SongPrice = 1.29M},
                new Song { SongTitle ="Middle of Nowhere", SongPrice = 1.29M},
                new Song { SongTitle ="Dices", SongPrice = 1.29M},

                //Individual songs
                new Song { SongTitle ="Answer", SongPrice = 1.29M},
                new Song { SongTitle ="Antrozous", SongPrice = 1.29M},
                new Song { SongTitle ="Beautiful Things (Gabriel & Dresden Radio Mix)", SongPrice = 1.29M},
                new Song { SongTitle ="Numb/Encore", SongPrice = 1.29M},
                new Song { SongTitle ="Little Boxes", SongPrice = 1.29M},
                new Song { SongTitle ="Puff, the Magic Dragon", SongPrice = 1.29M},
                new Song { SongTitle ="We Found Love (feat. Rihanna)", SongPrice = 1.29M},
                new Song { SongTitle ="Stereo Hearts (feat. Adam Levine)", SongPrice = 1.29M},
                new Song { SongTitle ="Mistletoe", SongPrice = 1.29M},
                new Song { SongTitle ="Paradise", SongPrice = 0.99M},
                new Song { SongTitle ="Young, Wild & Free (feat. Bruno Mars)", SongPrice = 1.29M},
                new Song { SongTitle ="You Make Me Feel... (feat. Sabi)", SongPrice = 1.29M},
                new Song { SongTitle ="It Girl", SongPrice = 1.39M},
                new Song { SongTitle ="Mr. Know It All", SongPrice = 0.89M},
                new Song { SongTitle ="5 O'Clock (feat. Wiz Khalifa & Lily Allen)", SongPrice = 1.29M},
                new Song { SongTitle ="Good Feeling", SongPrice = 1.49M},
                new Song { SongTitle ="In the Dark", SongPrice = 1.29M},
                new Song { SongTitle ="It Will Rain", SongPrice = 1.29M},
                new Song { SongTitle ="A Thousand Years", SongPrice = 0.89M },
                new Song { SongTitle ="Strange Clouds (feat. Lil Wayne)", SongPrice = 1.29M},
                new Song { SongTitle ="Give Me Everything (feat. Ne-Yo, Afrojack & Nayer)", SongPrice = 1.29M},
                new Song { SongTitle ="Focused (feat. Kid Cudi)", SongPrice = 1.29M},
                new Song { SongTitle ="Mr. Saxobeat (Radio Edit)", SongPrice = 1.19M },
                new Song { SongTitle ="When We Stand Together", SongPrice = 1.29M},
                new Song { SongTitle ="You the Boss (feat. Nicki Minaj)", SongPrice = 1.29M},
                new Song { SongTitle ="Round of Applause (feat. Drake)", SongPrice = 0.99M},
                new Song { SongTitle ="Domino", SongPrice = 0.99M},
                new Song { SongTitle ="Hello", SongPrice = 1.29M},
                new Song { SongTitle ="Barefoot Blue Jean Night", SongPrice = 1.29M},
                new Song { SongTitle ="Marvins Room", SongPrice = 0.89M},
                new Song { SongTitle ="Got 2 Luv U (feat. Alexis Jordan)", SongPrice = 1.29M},
                new Song { SongTitle ="Baggage Claim", SongPrice = 1.29M},
                new Song { SongTitle ="I Like It Like That", SongPrice = 0.99M },
                new Song { SongTitle ="Good Good Night", SongPrice = 1.29M },
                new Song { SongTitle ="Face to the Floor", SongPrice = 0.89M},
                new Song { SongTitle ="Steal My Girl", SongPrice = 1.29M},
                new Song { SongTitle ="Jealous", SongPrice = 0.99M},
                new Song { SongTitle ="Uptown Funk (ft. Bruno Mars)", SongPrice = 1.19M},
                new Song { SongTitle ="Take Me to Church", SongPrice = 0.99M},
                new Song { SongTitle ="These Walls", SongPrice = 1.19M},
            };

            //Find record based on a property and add/update
            songs.ForEach(s => db.Songs.AddOrUpdate(y => y.SongTitle, s));
            db.SaveChanges();

            //add genre to song

            //AddOrUpdateSongGenre(db,"Rolling In The Deep","Pop");
            //AddOrUpdateSongGenre(db, "Rumour Has It", "Pop");
            //AddOrUpdateSongGenre(db, "Turning Tables", "Pop");
            //AddOrUpdateSongGenre(db, "Don't You Remember", "Pop");
            //AddOrUpdateSongGenre(db, "Set Fire to the Rain", "Pop");
            //AddOrUpdateSongGenre(db, "He Won't Go", "Pop");
            //AddOrUpdateSongGenre(db, "Take It All", "Pop");
            //AddOrUpdateSongGenre(db, "I'll Be Waiting", "Pop");
            //AddOrUpdateSongGenre(db, "One and Only", "Pop");
            //AddOrUpdateSongGenre(db, "Lovesong", "Pop");
            //AddOrUpdateSongGenre(db, "Someone Like You", "Pop");
            //AddOrUpdateSongGenre(db, "I Found A Boy", "Pop");
            //Lady GaGa
            //AddOrUpdateSongGenre(db, "Marry the Night", "Pop");
            //AddOrUpdateSongGenre(db, "Born This Way", "Pop");
            //AddOrUpdateSongGenre(db, "Government Hooker", "Pop");
            //AddOrUpdateSongGenre(db, "Judas", "Pop");
            //AddOrUpdateSongGenre(db, "Americano", "Pop");
            //AddOrUpdateSongGenre(db, "Hair", "Pop");
            //AddOrUpdateSongGenre(db, "Bloody Mary", "Pop");
            //AddOrUpdateSongGenre(db, "Black Jesus + Amen Fashion", "Pop");
            //AddOrUpdateSongGenre(db, "Bad Kids", "Pop");
            //AddOrUpdateSongGenre(db, "Fashion of His Love", "Pop");
            //AddOrUpdateSongGenre(db, "Highway Unicorn (Road to Love)", "Pop");
            //AddOrUpdateSongGenre(db, "Heavy Metal Lover", "Pop");
            //AddOrUpdateSongGenre(db, "Electric Chapel", "Pop");
            //AddOrUpdateSongGenre(db, "The Queen", "Pop");
            //AddOrUpdateSongGenre(db, "You and I", "Pop");
            //AddOrUpdateSongGenre(db, "The Edge of Glory", "Pop");

            //Florence
            //AddOrUpdateSongGenre(db, "Only If For A Night", "Alternative");
            //AddOrUpdateSongGenre(db, "Shake It Out", "Alternative");
            //AddOrUpdateSongGenre(db, "What the Water Gave Me", "Alternative");
            //AddOrUpdateSongGenre(db, "Never Let Me Go", "Alternative");
            //AddOrUpdateSongGenre(db, "Breaking Down", "Alternative");
            //AddOrUpdateSongGenre(db, "Lover to Lover", "Alternative");
            //AddOrUpdateSongGenre(db, "No Light, No Light", "Alternative");
            //AddOrUpdateSongGenre(db, "Seven Devils", "Alternative");
            //AddOrUpdateSongGenre(db, "Heartlines", "Alternative");
            //AddOrUpdateSongGenre(db, "Spectrum", "Alternative");
            //AddOrUpdateSongGenre(db, "All of This and Heaven Too", "Alternative");
            //AddOrUpdateSongGenre(db, "Leave My Body", "Alternative");
            //AddOrUpdateSongGenre(db, "Remain Nameless", "Alternative");
            //AddOrUpdateSongGenre(db, "Strangeness and Charm", "Alternative");
            //AddOrUpdateSongGenre(db, "Bedroom Hymns", "Alternative");

            ////James Bay
            //AddOrUpdateSongGenre(db, "Craving", "Alternative");
            //AddOrUpdateSongGenre(db, "Hold Back the River", "Alternative");
            //AddOrUpdateSongGenre(db, "Let it Go", "Alternative");
            //AddOrUpdateSongGenre(db, "If You Ever Want to Be in Love", "Alternative");
            //AddOrUpdateSongGenre(db, "Best Fake Smile", "Alternative");
            //AddOrUpdateSongGenre(db, "When We Were on Fire", "Alternative");
            //AddOrUpdateSongGenre(db, "Move Together", "Alternative");
            //AddOrUpdateSongGenre(db, "Scars", "Alternative");
            //AddOrUpdateSongGenre(db, "Collide", "Alternative");
            //AddOrUpdateSongGenre(db, "Get Out While You Can", "Alternative");
            //AddOrUpdateSongGenre(db, "Need the Sun to Break", "Alternative");
            //AddOrUpdateSongGenre(db, "Incomplete", "Alternative");

            //Julian Smith
            //AddOrUpdateSongGenre(db, "Eat Randy", "Comedy");

            //Maroon 5 
            AddOrUpdateSongGenre(db, "Misery", "Pop");
            AddOrUpdateSongGenre(db, "Give a Little More", "Pop");
            AddOrUpdateSongGenre(db, "Stutter", "Pop");
            AddOrUpdateSongGenre(db, "Don't Know Nothing", "Pop");
            AddOrUpdateSongGenre(db, "Never Gonna Leave This Bed", "Pop");
            AddOrUpdateSongGenre(db, "I Can't Lie", "Pop");
            AddOrUpdateSongGenre(db, "Hands All Over", "Pop");
            AddOrUpdateSongGenre(db, "How", "Pop");
            AddOrUpdateSongGenre(db, "Get Back In My Life", "Pop");
            AddOrUpdateSongGenre(db, "Just a Feeling", "Pop");
            AddOrUpdateSongGenre(db, "Runaway", "Pop");
            AddOrUpdateSongGenre(db, "Out of Goodbyes", "Pop");
            AddOrUpdateSongGenre(db, "Moves Like Jagger", "Pop");
            AddOrUpdateSongGenre(db, "The Air That I Breathe", "Pop");
            AddOrUpdateSongGenre(db, "Last Change", "Pop");
            AddOrUpdateSongGenre(db, "No Curtain Call", "Pop");
            AddOrUpdateSongGenre(db, "If I Ain't Got You", "Pop");

            //Rihanna
            AddOrUpdateSongGenre(db, "S&M", "Pop");
            AddOrUpdateSongGenre(db, "What's My Name?", "Pop");
            AddOrUpdateSongGenre(db, "Cheers", "Pop");
            AddOrUpdateSongGenre(db, "Fading", "Pop");
            AddOrUpdateSongGenre(db, "Only Girl (In the World)", "Pop");
            AddOrUpdateSongGenre(db, "California King Bed", "Pop");
            AddOrUpdateSongGenre(db, "Man Down", "Pop");
            AddOrUpdateSongGenre(db, "Raining Men", "Pop");
            AddOrUpdateSongGenre(db, "Complicated", "Pop");
            AddOrUpdateSongGenre(db, "Skin", "Pop");
            AddOrUpdateSongGenre(db, "Love The Way You Lie", "Pop");

            //Ariana Grande
            AddOrUpdateSongGenre(db, "Intro", "Pop");
            AddOrUpdateSongGenre(db, "Problem (feat. Iggy Azalea)", "Pop");
            AddOrUpdateSongGenre(db, "One Last Time", "Pop");
            AddOrUpdateSongGenre(db, "Break Free(feat.Zedd)", "Pop");
            AddOrUpdateSongGenre(db, "Best Mistake (feat. Big Sean)", "Pop");
            AddOrUpdateSongGenre(db, "Be My Baby (feat. Cashmere Cat)", "Pop");
            AddOrUpdateSongGenre(db, "Break Your Heart Right Back (feat.Childish Gambino)", "Pop");
            AddOrUpdateSongGenre(db, "Love Me Harder (feat. The Weeknd)", "Pop");
            AddOrUpdateSongGenre(db, "Just a Little Bit of Your Heart", "Pop");
            AddOrUpdateSongGenre(db, "Hands On Me (feat.A$AP Ferg)", "Pop");
            AddOrUpdateSongGenre(db, "Bang Bang (feat. Jessie J and Nicki Minaj)", "Pop");
            AddOrUpdateSongGenre(db, "Only 1", "Pop");
            AddOrUpdateSongGenre(db, "You Don't Know Me", "Pop");

            //Blake Shelton
            AddOrUpdateSongGenre(db, "Honey Bee", "Pop");
            AddOrUpdateSongGenre(db, "Ready to Roll", "Pop");
            AddOrUpdateSongGenre(db, "God Gave Me You", "Pop");
            AddOrUpdateSongGenre(db, "Get Some", "Pop");
            AddOrUpdateSongGenre(db, "Drink On It", "Pop");
            AddOrUpdateSongGenre(db, "Good Ole Boys", "Pop");
            AddOrUpdateSongGenre(db, "I'm Sorry", "Pop");
            AddOrUpdateSongGenre(db, "Sunny In Seattle", "Pop");
            AddOrUpdateSongGenre(db, "Over", "Pop");
            AddOrUpdateSongGenre(db, "Hey", "Pop");
            AddOrUpdateSongGenre(db, "Red River Blue", "Pop");
            AddOrUpdateSongGenre(db, "Chili", "Pop");
            AddOrUpdateSongGenre(db, "Addicted", "Pop");

            //Blake Shelton second genre Country
            AddOrUpdateSongGenre(db, "Honey Bee", "Country");
            AddOrUpdateSongGenre(db, "Ready to Roll", "Country");
            AddOrUpdateSongGenre(db, "God Gave Me You", "Country");
            AddOrUpdateSongGenre(db, "Get Some", "Country");
            AddOrUpdateSongGenre(db, "Drink On It", "Country");
            AddOrUpdateSongGenre(db, "Good Ole Boys", "Country");
            AddOrUpdateSongGenre(db, "I'm Sorry", "Country");
            AddOrUpdateSongGenre(db, "Sunny In Seattle", "Country");
            AddOrUpdateSongGenre(db, "Over", "Country");
            AddOrUpdateSongGenre(db, "Hey", "Country");
            AddOrUpdateSongGenre(db, "Red River Blue", "Country");
            AddOrUpdateSongGenre(db, "Chili", "Country");
            AddOrUpdateSongGenre(db, "Addicted", "Country");

            ////add artist to song
            //AddOrUpdateSongArtist(db, "Rolling In The Deep", "ADELE");
            //AddOrUpdateSongArtist(db, "Rumour Has It", "ADELE");
            //AddOrUpdateSongArtist(db, "Turning Tables", "ADELE");
            //AddOrUpdateSongArtist(db, "Don't You Remember", "ADELE");
            //AddOrUpdateSongArtist(db, "Set Fire to the Rain", "ADELE");
            //AddOrUpdateSongArtist(db, "He Won't Go", "ADELE");
            //AddOrUpdateSongArtist(db, "Take It All", "ADELE");
            //AddOrUpdateSongArtist(db, "I'll Be Waiting", "ADELE");
            //AddOrUpdateSongArtist(db, "One and Only", "ADELE");
            //AddOrUpdateSongArtist(db, "Lovesong", "ADELE");
            //AddOrUpdateSongArtist(db, "Someone Like You", "ADELE");
            //AddOrUpdateSongArtist(db, "I Found a Boy", "ADELE");

            ////Lady GaGa
            //AddOrUpdateSongArtist(db, "Marry the Night", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Born This Way", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Government Hooker", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Judas", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Americano", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Hair", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Bloody Mary", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Black Jesus + Amen Fashion", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Bad Kids", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Fashion of His Love", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Highway Unicorn (Road to Love)", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Heavy Metal Lover", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "Electric Chapel", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "The Queen", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "You and I", "Lady GaGa");
            //AddOrUpdateSongArtist(db, "The Edge of Glory", "Lady GaGa");

            ////Florence
            //AddOrUpdateSongArtist(db, "Only If For A Night", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Shake It Out", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "What the Water Gave Me", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Never Let Me Go", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Breaking Down", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Lover to Lover", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "No Light, No Light", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Seven Devils", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Heartlines", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Spectrum", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "All of This and Heaven Too", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Leave My Body", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Remain Nameless", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Strangeness and Charm", "Florence + the Machine");
            //AddOrUpdateSongArtist(db, "Bedroom Hymns", "Florence + the Machine");

            //Maroon 5
            //AddOrUpdateSongArtist(db, "Misery", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Give a Little More", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Stutter", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Don't Know Nothing", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Never Gonna Leave This Bed", "Maroon 5");
            //AddOrUpdateSongArtist(db, "I Can't Lie", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Hands All Over", "Maroon 5");
            //AddOrUpdateSongArtist(db, "How", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Get Back In My Life", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Just a Feeling", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Runaway", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Out of Goodbyes", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Moves Like Jagger", "Maroon 5");
            //AddOrUpdateSongArtist(db, "The Air That I Breathe", "Maroon 5");
            //AddOrUpdateSongArtist(db, "Last Change", "Maroon 5");
            //AddOrUpdateSongArtist(db, "No Curtain Call", "Maroon 5");
            //AddOrUpdateSongArtist(db, "If I Ain't Got You", "Maroon 5");

            db.SaveChanges();
            
            //create album list
            var albums = new List<Album>
            {
               new Album { AlbumName = "21", AlbumPrice = 10.99M}
               //new Album { AlbumName = "Loud",  AlbumPrice = 9.99M},
               //new Album { AlbumName = "If You're Reading This It's Too Late", AlbumPrice = 12.99M},
               //new Album { AlbumName = "Torches", AlbumGenres = new List<Genre>(), AlbumPrice = 9.99M},
               //new Album { AlbumName = "Hands All Over", AlbumPrice = 9.99M, },
               //new Album { AlbumName = "Hands All Over (Deluxe Version)",  AlbumPrice = 14.99M },
               //new Album { AlbumName = "Nothing But the Beat", AlbumPrice = 9.99M },
               //new Album { AlbumName = "Born This Way", AlbumPrice = 14.99M},
               //new Album { AlbumName = "Red River Blue (Deluxe Version)", AlbumPrice = 11.99M},
               //new Album { AlbumName = "Pink Friday (Deluxe Version)",AlbumPrice = 14.99M},
               //new Album { AlbumName = "Watch The Throne (Deluxe Version)", AlbumPrice = 14.99M},
               //new Album { AlbumName = "Tailgates & Tanlines", AlbumPrice = 9.99M },
               //new Album { AlbumName = "The Band Perry", AlbumPrice = 9.99M },
               //new Album { AlbumName = "When the Sun Goes Down", AlbumPrice = 9.99M },
               //new Album { AlbumName = "Own the Night", AlbumPrice = 10.99M},
               //new Album { AlbumName = "Life At Best (Deluxe Version)", AlbumPrice = 11.99M },
               //new Album { AlbumName = "Songs From the Heart", AlbumPrice = 13.37M},
               //new Album { AlbumName = "Chaos and the Calm", AlbumPrice = 10.99M },
               //new Album { AlbumName = "My Everything (Deluxe Version)", AlbumPrice = 12.99M },
               //new Album { AlbumName = "Ceremonials (Deluxe Version)", AlbumPrice = 10.99M },
               //new Album { AlbumName = "Sorry for Party Rocking (Deluxe Version)", AlbumPrice = 9.99M },
               //new Album { AlbumName = "Montevallo", AlbumPrice = 9.99M},
               //new Album { AlbumName = "X2C", AlbumPrice = 3.99M },
               //new Album { AlbumName = "The Best of Bobby McFerrin", AlbumPrice = 9.99M },
               //new Album { AlbumName = "Eat Randy - Single", AlbumPrice = 1.29M },
               //new Album { AlbumName = "The Duck song (The Duck and the Lemonade Stand)", AlbumPrice = 1.29M },
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

