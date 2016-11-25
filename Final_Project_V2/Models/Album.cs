using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Album
    {
        //scalar 
        public Int32 AlbumID { get; set; }
        public decimal AlbumPrice { get; set; }
        public string AlbumName { get; set; }
       // public DateTime AlbumTimestamp { get; set; }
        public bool Featured { get; set; }

        //navigational
        public List<Genre> AlbumGenres { get; set; }

        [InverseProperty("ArtistAlbums")]
        public Artist AlbumArtist { get; set; }

        [InverseProperty("SongAlbums")]
        public List<Song> AlbumSongs { get; set; }
        
    }
}