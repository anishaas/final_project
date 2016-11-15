using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class UserActivityClassification
    {
        public Int32 UserActivityClassificationID { get; set; }
        public Int32 UserActivityClassificationType { get; set; }
        public String UserActivityArg1 { get; set; }
        public String UserActivityArg2 { get; set; }
        public String UserActivityArg3 { get; set; }
        public String UserActivityArg4 { get; set; }
        public String UserActivityArg5 { get; set; }
        public String UserActivityTxt1 { get; set; }
        public String UserActivityTxt2 { get; set; }
        public String UserActivityTxt3 { get; set; }
        public String UserActivityTxt4 { get; set; }
        public String UserActivityTxt5 { get; set; }
        public DateTime UserActivityClassificationTimestamp { get; set; }

        //Navigational Properties
        public UserActivityInput UserActivityInputID { get; set; }
    }
}