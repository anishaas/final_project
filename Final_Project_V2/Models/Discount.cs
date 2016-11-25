using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class Discount
    {
        //scalar
        public Int32 DiscountID { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool DiscountStatus { get; set; }
        public DateTime DiscountTimeStamp { get; set; }
        public Int32 DiscountedItemID { get; set; }


    }
}