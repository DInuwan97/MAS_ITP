using MAS_Sustainability.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAS_Sustainability.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult Index()
        {
            DataTable SurveyDataTable = new DataTable();
            DataTable UserDataDatatable = new DataTable();
            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String UserDetails = "SELECT UserName,UserType,userid,userimage FROM users WHERE UserEmail = '" + Session["user"] + "'";

                //add the session username in query
                String listOfSurveys = "select TokenID,ProblemName,AddedDate from tokens, token_audit where tokens.tokenAuditID = token_audit.tokenauditId ";

                MySqlDataAdapter mySqlDa1 = new MySqlDataAdapter();

                MySqlCommand UserDetailsComm = new MySqlCommand(UserDetails, mySqlCon);
                MySqlCommand listOfReportsComm = new MySqlCommand(listOfSurveys, mySqlCon);


                mySqlDa1.SelectCommand = UserDetailsComm;
                mySqlDa1.Fill(UserDataDatatable);

                mySqlDa1.SelectCommand = listOfReportsComm;
                mySqlDa1.Fill(SurveyDataTable);
            }

            var surveyList = new List<Survey>();

            for (int i = 0; i < SurveyDataTable.Rows.Count; i++)
            {
                surveyList.Add(new Survey
                {
                    tokenID = Convert.ToInt32(SurveyDataTable.Rows[i][0]),
                    ProblemName = SurveyDataTable.Rows[i][1].ToString(),
                    AddedDate = SurveyDataTable.Rows[i][2].ToString()
                });
            }

            MainModel mainModel = new MainModel();

            mainModel.SurveyList = surveyList;

            if (UserDataDatatable.Rows.Count == 1)
            {

                mainModel.LoggedUserName = UserDataDatatable.Rows[0][0].ToString();
                mainModel.LoggedUserType = UserDataDatatable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(UserDataDatatable.Rows[0][2]);
                mainModel.UserImagePath = UserDataDatatable.Rows[0][3].ToString();
            }

            return View(mainModel);
        }

        public ActionResult viewSurvey(int? Id)
        {

            if (!Id.HasValue)
            {
                return RedirectToAction("Index", "Survey");
            }


            DataTable UserDataDatatable = new DataTable();
            DataTable SurveyDataTable = new DataTable();

            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();

                //AND AddedUser='"+Session["user"]+"'";
                String listOfsurvey = "select tokens.TokenID,ProblemName,Location,Description,AddedUser,AddedDate,Category,TokenImageID,ImagePath,rating,comment " +
                                     "from comment,feedback,tokens, token_audit,users,token_image " +
                                     "where users.UserID=feedback.userId AND " +
                                     "tokens.TokenID=feedback.tokenId AND " +
                                     "tokens.tokenAuditID = token_audit.tokenauditId and " +
                                     "tokens.TokenID = '" + (int)Id + "' and " +
                                     "token_image.tokenid=tokens.tokenauditid AND " +
                                     "comment.feedbackId=feedback.feedbackId;";

                String UserDetails = "SELECT UserName,UserType,userid,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa2 = new MySqlDataAdapter();
                MySqlCommand UserDetailsComm = new MySqlCommand(UserDetails, mySqlCon);
                MySqlCommand listOfReportsComm = new MySqlCommand(listOfsurvey, mySqlCon);
                mySqlDa2.SelectCommand = UserDetailsComm;
                mySqlDa2.Fill(UserDataDatatable);
                mySqlDa2.SelectCommand = listOfReportsComm;
                mySqlDa2.Fill(SurveyDataTable);
            }
            if (SurveyDataTable.Rows.Count == 0)
            {
                return RedirectToAction("Index", "Survey");
            }
            else
            {
                Survey s = new Survey
                {
                    tokenID = Convert.ToInt32(SurveyDataTable.Rows[0][0]),
                    ProblemName = SurveyDataTable.Rows[0][1].ToString(),
                    Location = SurveyDataTable.Rows[0][2].ToString(),
                    Description = SurveyDataTable.Rows[0][3].ToString(),
                    AddedDate = SurveyDataTable.Rows[0][5].ToString(),
                    Category = SurveyDataTable.Rows[0][6].ToString(),
                    Image1path = SurveyDataTable.Rows[0][8].ToString(),
                    Image2path = SurveyDataTable.Rows[1][8].ToString(),
                    rating = Convert.ToInt32(SurveyDataTable.Rows[1][9]),
                    comment = SurveyDataTable.Rows[1][10].ToString(),

                };

                MainModel main = new MainModel();

                main.survey = s;
                if (UserDataDatatable.Rows.Count == 1)
                {

                    main.LoggedUserName = UserDataDatatable.Rows[0][0].ToString();
                    main.LoggedUserType = UserDataDatatable.Rows[0][1].ToString();
                    main.LoggedUserID = Convert.ToInt32(UserDataDatatable.Rows[0][2]);
                    main.UserImagePath = UserDataDatatable.Rows[0][3].ToString();
                }

                return View(main);

            }
        }

        [HttpPost]
        public ActionResult SubmitSurvey(int? tokenID, int? UserID, int? LikeStatus)
        {
            DB dbconnection = new DB();

            using (MySqlConnection mySqlCon = dbconnection.DBConnection())
            {
                mySqlCon.Open();
                if (LikeStatus == 2)
                {
                    String Like = "Update feedback set rating = '1' where userid='" + UserID + "' and tokenid = '" + tokenID + "'";
                    MySqlCommand mySqlComm = new MySqlCommand(Like, mySqlCon);
                    mySqlComm.ExecuteNonQuery();
                }
                else if (LikeStatus == 0)
                {
                    String Like = "Update feedback set rating = '1' where userid='" + UserID + "' and tokenid = '" + tokenID + "'";
                    MySqlCommand mySqlComm = new MySqlCommand(Like, mySqlCon);
                    int rowAffected = mySqlComm.ExecuteNonQuery();
                    if (rowAffected == 0)
                    {
                        String LikeUpdate = "Insert into feedback(userid,tokenid,rating) values(" + UserID + "," + tokenID + ",1)";
                        MySqlCommand mySqlComm2 = new MySqlCommand(LikeUpdate, mySqlCon);
                        mySqlComm2.ExecuteNonQuery();
                    }
                }
                else if (LikeStatus == 1)
                {
                    String Like = "Update feedback set rating = '0' where userid='" + UserID + "' and tokenid = '" + tokenID + "'";
                    MySqlCommand mySqlComm = new MySqlCommand(Like, mySqlCon);
                    mySqlComm.ExecuteNonQuery();
                }
            }

            return RedirectToAction("viewReport", "Report", new { id = tokenID });
        }

        /*

        [HttpPost]
        public ActionResult UpdateComment(int? tokenID, int? UserID,int? rating,string? comment)
        {
            DB dbconnection = new DB();

            using (MySqlConnection mySqlCon = dbconnection.DBConnection())
            {
                mySqlCon.Open();
                if ()
                {
                    String feedbackUpdate = "UPDATE feedback set rating= "+rating+ " where userid='" + UserID + "' and tokenid = '" + tokenID + "'";
                    String commentUpdate = "UPDATE comment set comment = "+comment+" where userid='" + UserID + "' and tokenid = '" + tokenID + "'";

                    MySqlCommand mySqlComm = new MySqlCommand(feedbackUpdate, mySqlCon);
                    mySqlComm.ExecuteNonQuery();

                    MySqlCommand mySqlComm = new MySqlCommand(commentUpdate, mySqlCon);
                    mySqlComm.ExecuteNonQuery();
                }
               
            }

            return RedirectToAction("viewSurvey", "Survey", new { id = tokenID });
        }
        */
    }
}