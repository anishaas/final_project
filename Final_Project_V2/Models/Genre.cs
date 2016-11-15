using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Genre
    {


        public virtual List<Album> Albums { get; set; }
    }
}