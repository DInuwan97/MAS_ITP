using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace MAS_Sustainability.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Edit(int id)
        {
            List<UserRegistrationModel> List_UserRegistration = new List<UserRegistrationModel>();
            MainModel mainModel = new MainModel();
            DataTable userDetailsDataTable = new DataTable();
            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String qry_listOfTokens = "SELECT UserName,UserType,UserID,UserEmail,UserMobile,UserDepartment,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                mySqlDa.Fill(userDetailsDataTable);
            }

            for (int i = 0; i < userDetailsDataTable.Rows.Count; i++)
            {
                List_UserRegistration.Add(new UserRegistrationModel
                {
                    UserFullName = userDetailsDataTable.Rows[0][0].ToString(),
                    UserType = userDetailsDataTable.Rows[0][1].ToString(),
                    UserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]),
                    UserEmail = userDetailsDataTable.Rows[0][3].ToString(),
                    UserMobile = userDetailsDataTable.Rows[0][4].ToString(),
                    UserDepartment = userDetailsDataTable.Rows[0][5].ToString(),
                    UserImagePath = userDetailsDataTable.Rows[0][6].ToString()
                }
                );
            }

            if(userDetailsDataTable.Rows.Count == 1)
            {
                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][6].ToString();

                mainModel.ListUserRegistration = List_UserRegistration;
               
                return View(mainModel);
            }
            else
            {
                return View("Index");
            }



            
        }



        public ActionResult Index()
        {
            DataTable userDetailsDataTable = new DataTable();
            DataTable userListDataTable = new DataTable();
            MainModel mainModel = new MainModel();

           // UserRegistrationModel userRegistrationModel = new UserRegistrationModel();

            List<UserRegistrationModel> List_UserRegistration = new List<UserRegistrationModel>();

            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();

                String qry_listOfTokens = "SELECT UserName,UserType,UserID,UserEmail,UserMobile,UserDepartment,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                mySqlDa.Fill(userDetailsDataTable);


                String qry_listOfUsers = "SELECT * FROM users";
                MySqlDataAdapter mySqlData_UserList = new MySqlDataAdapter(qry_listOfUsers, mySqlCon);
                mySqlData_UserList.Fill(userListDataTable);


                mainModel.ArrFirstImagePath = new string[500];


            }

            if (Session["user"] == null || userDetailsDataTable.Rows[0][1].ToString() != ("Administrator"))
            {
                return RedirectToAction("Index", "Dashbord");
            }

           

            for (int i = 0; i < userListDataTable.Rows.Count; i++)
            {
               
                

                List_UserRegistration.Add(new UserRegistrationModel {

                    UserFullName = userListDataTable.Rows[i][1].ToString(),
                    UserType = userListDataTable.Rows[i][7].ToString(),
                    UserID = Convert.ToInt32(userListDataTable.Rows[i][0]),
                    UserEmail = userListDataTable.Rows[i][2].ToString(),
                    UserMobile = userListDataTable.Rows[i][3].ToString(),
                    UserDepartment = userListDataTable.Rows[i][6].ToString(),
                    UserImagePath = userListDataTable.Rows[i][8].ToString()


            });

            }



            if (userDetailsDataTable.Rows.Count == 1)
            {
                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][6].ToString();

                mainModel.ListUserRegistration = List_UserRegistration;
                //ViewBag.UserImageVariable = mainModel;

                return View(mainModel);
            }
         
            else
            {
                return View()
;            }
        }

        public ActionResult UserProfile(int id)
        {

            List<UserRegistrationModel> List_UserDetails = new List<UserRegistrationModel>();
            List<UserRegistrationModel> List_UserRegistration = new List<UserRegistrationModel>();

            MainModel mainModel = new MainModel();
            DataTable userDetailsDataTable = new DataTable();
            DataTable LoggeduserDetailsDataTable = new DataTable();

            DB dbConn = new DB();

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String qry_listOfUsers = "SELECT * FROM users WHERE UserID = @UserID";
                MySqlDataAdapter mySqlData_UserList = new MySqlDataAdapter(qry_listOfUsers, mySqlCon);
                mySqlData_UserList.SelectCommand.Parameters.AddWithValue("@UserID",id);
                mySqlData_UserList.Fill(userDetailsDataTable);

                String qry_listOfTokens = "SELECT UserName,UserType,UserID,UserEmail,UserMobile,UserDepartment,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                mySqlDa.Fill(LoggeduserDetailsDataTable);

            }

            if (LoggeduserDetailsDataTable.Rows.Count == 1)
            {
                mainModel.LoggedUserName = LoggeduserDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = LoggeduserDetailsDataTable.Rows[0][1].ToString();
                mainModel.LoggedUserID = Convert.ToInt32(LoggeduserDetailsDataTable.Rows[0][2]);
                mainModel.UserImagePath = userDetailsDataTable.Rows[0][6].ToString();

            }

            if (userDetailsDataTable.Rows.Count == 1)
            {

                mainModel.UserImagePath = userDetailsDataTable.Rows[0][8].ToString();

                List_UserDetails.Add(
                    new UserRegistrationModel {
                        UserFullName = userDetailsDataTable.Rows[0][1].ToString(),
                        UserType = userDetailsDataTable.Rows[0][7].ToString(),
                        UserID = Convert.ToInt32(userDetailsDataTable.Rows[0][0]),
                        UserEmail = userDetailsDataTable.Rows[0][2].ToString(),
                        UserMobile = userDetailsDataTable.Rows[0][3].ToString(),
                        UserDepartment = userDetailsDataTable.Rows[0][6].ToString()
                        
                    }    
                );


                mainModel.ListUserRegistration = List_UserDetails;
            }

                return View(mainModel);
        }


        public ActionResult UpdateUserProfile(UserRegistrationModel userRegistrationModel)
        {
            DB dbConn = new DB();

            string UserImageFile = Path.GetFileNameWithoutExtension(userRegistrationModel.UserImage.FileName);
            string extension2 = Path.GetExtension(userRegistrationModel.UserImage.FileName);
            UserImageFile = UserImageFile + DateTime.Now.ToString("yymmssfff") + extension2;
            userRegistrationModel.UserImagePath = "~/userimages/" + UserImageFile;
            UserImageFile = Path.Combine(Server.MapPath("~/userimages/"), UserImageFile);
            userRegistrationModel.UserImage.SaveAs(UserImageFile);

            String userImgPath = userRegistrationModel.UserImagePath;




            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();


                String qry_update_userDetails = "UPDATE users SET UserName = @UserName, UserMobile = @UserMobile , UserImage = @userImgPath WHERE UserID = @UserID";

                MySqlCommand mySqlCommand_update_userDetails = new MySqlCommand(qry_update_userDetails, mySqlCon);
                mySqlCommand_update_userDetails.Parameters.AddWithValue("@UserID", userRegistrationModel.UserID);
                mySqlCommand_update_userDetails.Parameters.AddWithValue("@UserName", userRegistrationModel.UserFullName);
                mySqlCommand_update_userDetails.Parameters.AddWithValue("@UserMobile", userRegistrationModel.UserMobile);
                mySqlCommand_update_userDetails.Parameters.AddWithValue("@userImgPath", userRegistrationModel.UserImagePath);
                mySqlCommand_update_userDetails.ExecuteNonQuery();


            }

            return RedirectToAction("index");
        }



    }
}