using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class ProjectArtists
    {
        [Key]
        public string Artist { get; set; }

        public string Genre { get; set; }
        public bool Featured { get; set; }
    }
}