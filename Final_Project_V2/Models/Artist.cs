using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Artist
    {
        //constructor
        public Artist()
        {
           this.ArtistGenres = new List<Genre>();
           this.ArtistAlbums = new List<Album>();
           this.ArtistSongs = new List<Song>(); 
        }
        
        public Int32 ArtistID { get; set; }
        public string ArtistName { get; set; }
       // public DateTime ArtistTimeStamp { get; set; }
        public bool Featured { get; set; }

        //navigational
        public List<Genre> ArtistGenres { get; set; }

        [InverseProperty("AlbumArtist")]
        public List<Album> ArtistAlbums { get; set; }

        [InverseProperty("SongArtist")]
        public List<Song> ArtistSongs { get; set; }
    }
}