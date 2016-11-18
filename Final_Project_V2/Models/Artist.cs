using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Artist
    {
        public Int32 ArtistID { get; set; }
        public string ArtistName { get; set; }
        public DateTime ArtistTimeStamp { get; set; }
        public bool Featured { get; set; }

        //navigational
        public virtual List<Genre> ArtistGenres { get; set; }
        public virtual List<Album> ArtistAlbums { get; set; }
        public virtual List<Song> ArtistSongs { get; set; }
    }
}