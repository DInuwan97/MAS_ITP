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
    public class DashbordController : Controller
    {
        public String SessionEmail = null;
        public String LoginUserName = null;
        // GET: Dashbord


        public MainModel setUserDetails()
        {
            MainModel mainModel = new MainModel();
            DataTable userDetailsDataTable = new DataTable();
            DB dbConn = new DB();

                UserLogin userLogin = new UserLogin();
                using (MySqlConnection mySqlCon = dbConn.DBConnection())
                {
                    mySqlCon.Open();
                    String qry_listOfTokens = "SELECT UserName,UserType,UserID,UserImage FROM users WHERE UserEmail = '" + Session["user"] + "'";
                    MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                    mySqlDa.Fill(userDetailsDataTable);
                }


            if (userDetailsDataTable.Rows.Count == 1)
                {
                    mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                    mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();
                    mainModel.LoggedUserID = Convert.ToInt32(userDetailsDataTable.Rows[0][2]);
                    mainModel.UserImagePath = userDetailsDataTable.Rows[0][3].ToString();
                    return mainModel;
                }
            else
                {
                return null;
                }
           
              
        }



        public ActionResult Index()
        {

            MainModel finalItem = new MainModel();

            HomeController home = new HomeController();
         
            DataTable userDetailsDataTable = new DataTable();
              if (Session["user"] == null)
              {
                  return RedirectToAction("Login", "UserLogin");
              }
              else
              {                 
                  return View(setUserDetails());
              }


        }



     

        public String getLoggedUserName() {
            return LoginUserName;

        }

        public String getSessionEmail()
        {
            return SessionEmail;
        }
    }
}