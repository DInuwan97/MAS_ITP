using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using MAS_Sustainability.Models;

namespace MAS_Sustainability.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index1()
         {

            return View();

        }

        public MainModel setUserDetails()
        {
            MainModel mainModel = new MainModel();
            DataTable userDetailsDataTable = new DataTable();
            DB dbConn = new DB();

            UserLogin userLogin = new UserLogin();
            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String qry_listOfTokens = "SELECT UserName,UserType FROM users WHERE UserEmail = '" + Session["user"] + "'";
                MySqlDataAdapter mySqlDa = new MySqlDataAdapter(qry_listOfTokens, mySqlCon);
                mySqlDa.Fill(userDetailsDataTable);
            }


            if (userDetailsDataTable.Rows.Count == 1)
            {

                mainModel.LoggedUserName = userDetailsDataTable.Rows[0][0].ToString();
                mainModel.LoggedUserType = userDetailsDataTable.Rows[0][1].ToString();

                return mainModel;
            }
            else
            {
                return null;
            }


        }

        public ActionResult Index()
        {
            //ViewBag.Message = "Your contact page.";

            return View(setUserDetails());
        }
    }
}