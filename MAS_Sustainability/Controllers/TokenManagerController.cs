using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace MAS_Sustainability.Controllers
{
    public class TokenManagerController : Controller
    {
        // GET: TokenManager
        public ActionResult View(TokenManagerController tokenManager)
        {
            DB dbConn = new DB();
            String AddedUser = Session["user"].ToString();

            using (MySqlConnection mySqlCon = new MySqlConnection())
            {
                mySqlCon.Open();

            }


                return View();
        }
    }
}