﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Song
    {
        //scalar
        public Int32 SongID { get; set; }
        public string SongTitle { get; set; }
       // public DateTime SongTimestamp { get; set; }
        public bool Featured { get; set; }

        //navigational
        [InverseProperty("ArtistSongs")]
        public Artist SongArtist { get; set; }
        //Can a song belong to multiple genres? so a list instead of single genre? 
        [InverseProperty("GenreSongs")]
        public List<Genre> SongGenres { get; set; }
        [InverseProperty("AlbumSongs")]
        public List<Album> SongAlbums { get; set; }

        
    }
}