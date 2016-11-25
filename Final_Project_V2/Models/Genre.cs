using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }
       // public DateTime GenreTimestamp { get; set; }
        public String GenreName { get; set; }

        public List<Album> GenreAlbums { get; set; }
        [InverseProperty("SongGenres")]
        public List<Song> GenreSongs { get; set; }

        public List<Artist> GenreArtists { get; set; }

    }
}