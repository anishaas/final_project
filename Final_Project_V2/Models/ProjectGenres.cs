using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class ProjectGenres
    {
        [Key]
        public string Genre { get; set; }
    }
}