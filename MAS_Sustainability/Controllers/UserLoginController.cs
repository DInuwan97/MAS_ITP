using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace MAS_Sustainability.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            DB dbConn = new DB();
            MySqlConnection mySqlCon = dbConn.DBConnection();

            using (mySqlCon)
            {
                mySqlCon.Open();
                String userEmail = userLogin.LoginUserEmail;
                String userPassword = userLogin.LoginUserPassword;
                //  String qry = "SELECT UserEmail,Password FROM users WHERE UserEmail = '"+userEmail+"' AND Password = '"+userPassword+"' ";
                MySqlCommand mySqlCmd = mySqlCon.CreateCommand();
                mySqlCmd.CommandType = System.Data.CommandType.Text;
                mySqlCmd.CommandText = "SELECT UserEmail,Password FROM users WHERE UserEmail = '" + userEmail + "' AND Password = '" + userPassword + "' and Validation = 'true' ";
                mySqlCmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter mySqlDA = new MySqlDataAdapter(mySqlCmd);
                mySqlDA.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {
                    //Session["user"] = new UserLogin() { Login = userLogin.LoginUserEmail, LoginUserEmail = userLogin.LoginUserEmail };
                    Session["user"] = userLogin.LoginUserEmail;
                    return RedirectToAction("Index", "Dashbord");
                }
            }



            return View();
        }

        public ActionResult Logout()
        {
            // Session.Clear();
            Session["user"] = null;
            return RedirectToAction("Login", "UserLogin");
        }
    }
}