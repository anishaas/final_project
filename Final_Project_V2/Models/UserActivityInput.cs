using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_V2.Models
{
    public class UserActivityInput
    {
        //Scalar Properties
        public Int32 UserActivityInputID { get; set; }
        public Int32 UserActivityInputType { get; set; }
        public String UserActivityInputArg1 { get; set; }
        public String UserActivityInputArg2 { get; set; }
        public String UserActivityInputArg3 { get; set; }
        public String UserActivityInputArg4 { get; set; }
        public String UserActivityInputArg5 { get; set; }
        public String UserActivityInputTxt1 { get; set; }
        public String UserActivityInputTxt2 { get; set; }
        public String UserActivityInputTxt3 { get; set; }
        public String UserActivityInputTxt4 { get; set; }
        public String UserActivityInputTxt5 { get; set; }
        public DateTime UserActivityInputTimestamp { get; set; }

        //Navigational Properties
        public List<UserActivityClassification> UserActivityInputClassificationID { get; set; }
    }
}