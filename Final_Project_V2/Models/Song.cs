using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Song
    {
        //scalar
        public Int32 SongID { get; set; }
        public string SongTitle { get; set; }
        public DateTime SongTimestamp { get; set; }

        //navigational
        public virtual Artist SongArtist { get; set; }
        public virtual Genre SongGenre { get; set; }
        public virtual List<Album> SongAlbums { get; set; }
        
    }
}