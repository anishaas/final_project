using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class ProjectAlbums
    {
        [Key]
        public string Title { get; set; }

        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public bool Featured { get; set; }
        public string Discount { get; set; }
    }
}