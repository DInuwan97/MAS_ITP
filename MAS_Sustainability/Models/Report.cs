using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MAS_Sustainability.Models
{
    public class Report
    {

        //feedback data
        public int feedbackID { get; set; }
        public int userID { get; set; }
        public String userName { get; set; }
        public String UserEmail { get; set; }
        public int userImageUserId { get; set; }
        public int userImageId { get; set; }
        public String userImagePath { get; set; }
        public int tokenID { get; set; }
        public int ratingFeedback { get; set; }
        public int likeCount { get; set; }
        public int dislikeCount { get; set; }
        public int allCount { get; set; }
        public int commentCount { get; set; }
        public int commentID { get; set; }
        public String comment { get; set; }
        public String dateTime { get; set; }
        public List<Report> commentList { get; set; }
        public String likeColor { get; set; }
        public String dislikeColor { get; set; }
        public int Liked { get; set; }



        //report data
        public String VerifiedDate { get; set; }
        public int CompletedTokenImageID { get; set; }
        public int CompletedImageId { get; set; }
        public String CompleteImagePath { get; set; }
        public int CompleteRating { get; set; }
        [Display(Name = "Problem Name")]
        public String ProblemName { get; set; }
        public String Location { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }

        public String AddedDate { get; set; }
        public String Image1path { get; set; }
        public String Image2path { get; set; }
        [Display(Name = "Recieved Date")]
        public String recievedDateRepair { get; set; }
        [Display(Name = "DeadLine Provided")]
        public String DeadLineRepair { get; set; }
        [Display(Name = "Cost")]
        public String amountRepair { get; set; }


        public List<Report> reportList1 { get; set; }



    }
}