using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class ProjectSongs
    {
        [Key]
        [Column(Order = 1)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public string Album { get; set; }
        public bool Featured { get; set; }
        public string Discount { get; set; }
    }
}