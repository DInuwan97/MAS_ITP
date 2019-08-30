using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MAS_Sustainability.Models
{
    public class Survey
    {

        //feedback data
        public int userImageUserId { get; set; }
        public int userImageId { get; set; }
        public String userImagePath { get; set; }


        public String dateTime { get; set; }



        //Survey data
        public int rating { get; set; }
        public String comment { get; set; }
        public Boolean rated { get; set; }

        //my token list data
        public String VerifiedDate { get; set; }
        [Display(Name = "Problem Name")]

        public String ProblemName { get; set; }
        public int tokenID { get; set; }



        public List<Survey> reportList1 { get; set; }

        //token data
        public String Location { get; set; }
        public String Description { get; set; }
        public int userID { get; set; }
        public String userName { get; set; }

        public String Category { get; set; }
        public String AddedDate { get; set; }
        [Display(Name = "Added Date")]
        public String Image1path { get; set; }
        public String Image2path { get; set; }

    }
}