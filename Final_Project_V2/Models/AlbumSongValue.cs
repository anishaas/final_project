using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class AlbumSongValue
    {
        public Int32 AlbumSongValueID { get; set; }
        public DateTime AlbumSongTimestamp { get; set; }
        //navigation
        public Album AlbumSongValueAlbum { get; set; }
        public Song AlbumSongValueSong { get; set; }
    }
}