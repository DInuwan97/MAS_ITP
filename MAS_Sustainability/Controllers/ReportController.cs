﻿using MAS_Sustainability.Models;
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
    public class ReportController : Controller

    {

        // GET: Report
        public ActionResult Index()
        {
            



            DataTable ReportDataTable = new DataTable();
            DataTable UserDataDatatable = new DataTable();
            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String UserDetails = "SELECT UserName,UserType,userid,userimage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                String listOfReports = "select * from tokens, token_audit where tokens.tokenAuditID = token_audit.tokenauditId";

                MySqlDataAdapter mySqlDa1 = new MySqlDataAdapter();
                MySqlCommand UserDetailsComm = new MySqlCommand(UserDetails, mySqlCon);
                MySqlCommand listOfReportsComm = new MySqlCommand(listOfReports, mySqlCon);
                

                mySqlDa1.SelectCommand = UserDetailsComm;
                mySqlDa1.Fill(UserDataDatatable);

                mySqlDa1.SelectCommand = listOfReportsComm;
                mySqlDa1.Fill(ReportDataTable);
            }
            
            
            var reportList = new List<Report>();



            for (int i = 0; i < ReportDataTable.Rows.Count; i++)
            {
                reportList.Add(new Report
                {
                    ProblemName = ReportDataTable.Rows[i][2].ToString(),
                    Location = ReportDataTable.Rows[i][3].ToString(),
                    Description = ReportDataTable.Rows[i][5].ToString(),
                    Category = ReportDataTable.Rows[i][8].ToString(),
                    tokenID = Convert.ToInt32(ReportDataTable.Rows[i][0]),
                    AddedDate = ReportDataTable.Rows[i][9].ToString()
                });
            }


            MainModel mainModel = new MainModel();


            mainModel.ReportList = reportList;

            if(UserDataDatatable.Rows.Count == 1)
            {

                mainModel.LoggedUserName = UserDataDatatable.Rows[0][0].ToString();
                mainModel.LoggedUserType = UserDataDatatable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(UserDataDatatable.Rows[0][2]);
                mainModel.UserImagePath = UserDataDatatable.Rows[0][3].ToString();
            }

            return View(mainModel);
        }



        public ActionResult viewReport(int? Id)
        {
            
            if (!Id.HasValue)
            {
                return RedirectToAction("Index", "Report");
            }

            
            DataTable UserDataDatatable1 = new DataTable();
            DataTable ReportDataTable1 = new DataTable();

            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String listOfReports1 = "select tokens.Tokenid,tokens.tokenauditid,problemname,location,attentionlevel,description,token_audit.tokenauditid,addeduser,category,addeddate,tokenimageid,token_image.tokenid,imagepath from tokens, token_audit, token_image where tokens.tokenAuditID = token_audit.tokenauditId and tokens.TokenID = '" + (int)Id + "' and token_image.tokenid=tokens.tokenauditid";
                String UserDetails1 = "SELECT UserName,UserType,userid,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa2 = new MySqlDataAdapter();
                MySqlCommand UserDetailsComm1 = new MySqlCommand(UserDetails1, mySqlCon);
                MySqlCommand listOfReportsComm1 = new MySqlCommand(listOfReports1, mySqlCon);

                mySqlDa2.SelectCommand = UserDetailsComm1;
                mySqlDa2.Fill(UserDataDatatable1);

                mySqlDa2.SelectCommand = listOfReportsComm1;
                mySqlDa2.Fill(ReportDataTable1);

            }
            if (ReportDataTable1.Rows.Count == 0)
            {
                return RedirectToAction("Index", "Report");
            }
            else
            {




                Report rep = new Report
                {
                    ProblemName = ReportDataTable1.Rows[0][2].ToString(),
                    Location = ReportDataTable1.Rows[0][3].ToString(),
                    Description = ReportDataTable1.Rows[0][5].ToString(),
                    Category = ReportDataTable1.Rows[0][8].ToString(),
                    tokenID = Convert.ToInt32(ReportDataTable1.Rows[0][0]),
                    AddedDate = ReportDataTable1.Rows[0][9].ToString(),
                    Image1path = ReportDataTable1.Rows[0][12].ToString(),
                    Image2path = ReportDataTable1.Rows[1][12].ToString()

                };

                DataTable commentsDatatable = new DataTable();
                DataTable likeDislikeCountDatatable = new DataTable();
                DataTable LikedorDislikedDatatable = new DataTable();
                using (MySqlConnection mySqlCon2 = dbConn.DBConnection())
                {
                    mySqlCon2.Open();
                    String ListOfComments = "select commentid,comment,comment.feedbackid,feedback.feedbackId,feedback.userid,feedback.tokenid,feedback.rating,users.userId,users.username,comment.datetime,users.userimage from comment,feedback,users where comment.feedbackId=feedback.feedbackId and users.userId = feedback.userId and feedback.tokenid=" + (int)Id + " order by dateTime desc";
                    String LikeDislikeCounts = "select count(*) as totalCount, sum(case when rating = '1' then 1 else 0 end) likeCount, sum(case when rating = '2' then 1 else 0 end) DislikeCount from feedback where tokenId = " + (int)Id ;
                    String LikedOrDisliked = "Select userid,tokenid,rating from feedback where tokenid = " + (int)Id + " and userid =" + (int)Convert.ToInt32(UserDataDatatable1.Rows[0][2]);
                    MySqlCommand sqlCommListComment = new MySqlCommand(ListOfComments, mySqlCon2);
                    MySqlCommand sqlCommLikeDislikeCount = new MySqlCommand(LikeDislikeCounts, mySqlCon2);
                    MySqlCommand sqlCommLikedOrDisliked = new MySqlCommand(LikedOrDisliked, mySqlCon2);
                    MySqlDataAdapter mySqlda3= new MySqlDataAdapter();
                    mySqlda3.SelectCommand = sqlCommListComment;
                    mySqlda3.Fill(commentsDatatable);

                    mySqlda3.SelectCommand = sqlCommLikeDislikeCount;
                    mySqlda3.Fill(likeDislikeCountDatatable);

                    mySqlda3.SelectCommand = sqlCommLikedOrDisliked;
                    mySqlda3.Fill(LikedorDislikedDatatable);
                }

                var commentList = new List<Report>();

                if (commentsDatatable.Rows.Count == 0)
                {
                    rep.dislikeCount = 0;
                }
                else
                {

                    for (int i = 0; i < commentsDatatable.Rows.Count; i++)
                    {
                        commentList.Add(new Report
                        {
                            comment = commentsDatatable.Rows[i][1].ToString(),
                            feedbackID = Convert.ToInt32(commentsDatatable.Rows[i][2]),
                            userID = Convert.ToInt32(commentsDatatable.Rows[i][4]),
                            userName = commentsDatatable.Rows[i][8].ToString(),
                            
                            userImagePath = commentsDatatable.Rows[i][10].ToString(),
                            tokenID = Convert.ToInt32(commentsDatatable.Rows[i][5]),
                            dateTime = commentsDatatable.Rows[i][9].ToString()
                        });
                    }
                }
                rep.commentList = commentList;
                if (DBNull.Value.Equals(likeDislikeCountDatatable.Rows[0][1]))
                {
                    rep.likeCount = 0;
                }
                else
                {
                    rep.likeCount = Convert.ToInt32(likeDislikeCountDatatable.Rows[0][1]);
                }
                if (DBNull.Value.Equals(likeDislikeCountDatatable.Rows[0][2]))
                {
                    rep.dislikeCount = 0;
                }
                else
                {
                    rep.dislikeCount = Convert.ToInt32(likeDislikeCountDatatable.Rows[0][2]);
                }

                if (LikedorDislikedDatatable.Rows.Count == 1)
                {
                    rep.Liked = Convert.ToInt32(LikedorDislikedDatatable.Rows[0][2]);
                    if (Convert.ToInt32(LikedorDislikedDatatable.Rows[0][2]) == 0)
                    {
                        rep.likeColor = "transparent";
                        rep.dislikeColor = "transparent";
                    }
                    else if (Convert.ToInt32(LikedorDislikedDatatable.Rows[0][2]) == 1)
                    {
                        rep.likeColor = "darkblue";
                        rep.dislikeColor = "transparent";
                    }
                    else if (Convert.ToInt32(LikedorDislikedDatatable.Rows[0][2]) == 2)
                    {
                        rep.likeColor = "transparent";
                        rep.dislikeColor = "darkblue";

                    }
                }
                else
                {
                    rep.likeColor = "transparent";
                    rep.dislikeColor = "transparent";
                }

                rep.allCount = Convert.ToInt32(likeDislikeCountDatatable.Rows[0][0]);






                MainModel main = new MainModel();

                main.report = rep;
                if (UserDataDatatable1.Rows.Count == 1)
                {

                    main.LoggedUserName = UserDataDatatable1.Rows[0][0].ToString();
                    main.LoggedUserType = UserDataDatatable1.Rows[0][1].ToString();
                    main.LoggedUserID = Convert.ToInt32(UserDataDatatable1.Rows[0][2]);
                    main.UserImagePath = UserDataDatatable1.Rows[0][3].ToString();
                }

                return View(main);
            }
        }






        [HttpPost]
        public ActionResult Like(int? tokenID, int? UserID, int? LikeStatus)
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



        [HttpPost]
        public ActionResult DisLike(int? tokenID, int? UserID, int? LikeStatus)
        {
            DB dbconnection = new DB();

            using (MySqlConnection mySqlCon = dbconnection.DBConnection())
            {
                mySqlCon.Open();
                if (LikeStatus == 1)
                {
                    String Like = "Update feedback set rating = '2' where userid='" + UserID + "' and tokenid = '" + tokenID + "'";
                    MySqlCommand mySqlComm = new MySqlCommand(Like, mySqlCon);
                    mySqlComm.ExecuteNonQuery();
                }
                else if (LikeStatus == 0)
                {
                    String Like = "Update feedback set rating = '2' where userid='" + UserID + "' and tokenid = '" + tokenID + "'";
                    MySqlCommand mySqlComm = new MySqlCommand(Like, mySqlCon);
                    int rowAffected = mySqlComm.ExecuteNonQuery();
                    if (rowAffected == 0)
                    {
                        String LikeUpdate = "Insert into feedback(userid,tokenid,rating) values(" + UserID + "," + tokenID + ",2)";
                        MySqlCommand mySqlComm2 = new MySqlCommand(LikeUpdate, mySqlCon);
                        mySqlComm2.ExecuteNonQuery();
                    }
                }
                else if (LikeStatus == 2)
                {
                    String Like = "Update feedback set rating = '0' where userid='" + UserID + "' and tokenid = '" + tokenID + "'";
                    MySqlCommand mySqlComm = new MySqlCommand(Like, mySqlCon);
                    mySqlComm.ExecuteNonQuery();
                }
            }

            return RedirectToAction("viewReport", "Report", new { id = tokenID });
        }





    }
}