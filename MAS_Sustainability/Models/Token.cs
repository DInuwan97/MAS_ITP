using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MAS_Sustainability
{
    public class Token
    {
        public int TokenAuditID { get; set; }
        public String ProblemName { get; set; }
        public String ProblemCategory { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public String FirstImagePath { get; set; }
        public HttpPostedFileBase FirstImageFile { get; set; }
        public String SecondImagePath { get; set; }
        public HttpPostedFileBase SecondImageFile { get; set; }
        public int AttentionLevel { get; set; }
        public string UserName { get; set; }
        public string AddedDate { get; set; }

        public String ReparationDepartment { get; set; }
        public String SpecialActs { get; set; }
        public String SentDate { get; set; }


        public int no_of_token_rows_TokenManager { get; set; }

        public String TokenStatus { get; set; }

        public int ArrTokenAuditID{get; set;}
        public int ArrAttentionLevel { get; set; }
        public String ArrFirstImagePath { get; set; }
        public String ArrProblemName { get; set; }
        public String ArrLocation { get; set; }

        public String ArrUserName{ get; set; }

        public int no_of_rows_side_bar { get;set; }

        public int no_of_tokens { get; set; }

        public String ArrTokenStatus { get; set; }

        public String LoggedUserNameSide { get; set; }

        public String SentUser { get; set; }


    }
}