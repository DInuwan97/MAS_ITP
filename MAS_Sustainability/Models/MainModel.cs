using MAS_Sustainability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAS_Sustainability
{
    public class MainModel
    {
        //public UserLogin userLoginViewModel { get; set; }
        // public Token tokenViewModel { get; set; }

      //  public List<Survey> SurveyList { get; set; }
    //    public Survey survey { get; set; }


        public List<Token> ListToken { get; set; }
        public List<UserLogin> ListUserLogin { get; set; }
        public List<UserRegistrationModel> ListUserRegistration { get; set; }
        public List<Token> TokenList { get; set; }

         public List<Report> ReportList { get; set; }
        public Report report { get; set; }

        public List<UserRegistrationModel> ForgottenDetails { get; set; }

        



        public int[] ArrTokenAuditID { get; set; }
        public int[] ArrAttentionLevel { get; set; }
        public String[] ArrFirstImagePath { get; set; }
        public String[] ArrProblemName { get; set; }
        public String[] ArrLocation { get; set; }
        public String[] ArrUserName { get; set; }
        public String[] ArrTokenStatus { get; set; }   
        public int TokenAuditID { get; set; }
        public String ProblemName { get; set; }
        public String ProblemCategory { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public String FirstImagePath { get; set; }
        public String SecondImagePath { get; set; }
        public int AttentionLevel { get; set; }
        public string UserName { get; set; }
        public string AddedDate { get; set; }
        public String ReparationDepartment { get; set; }
        public String SpecialActs { get; set; }
        public String SentDate { get; set; }
        public int no_of_token_rows_TokenManager { get; set; }
        public String TokenStatus { get; set; }
        public int no_of_rows_side_bar { get; set; }

        public String LoggedUserName { get; set; }
        public String LoggedUserType { get; set; }

        public int LoggedUserID { get; set; }

        public String LoggedUserEmail { get; set; }



        //for UserManagement Controller's UserProfile View
        public String UserImagePath { get; set; }
        public String[] ArrUserImagePath { get; set; }
        //for UserManagement Controller's UserProfile View




        /*public MainModel()
        {
            new Token();
            new UserLogin();
        }*/
    }
}