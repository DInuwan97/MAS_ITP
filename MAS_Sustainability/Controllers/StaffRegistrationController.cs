using MAS_Sustainability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace MAS_Sustainability.Controllers
{
    public class StaffRegistrationController : Controller
    {
        // GET: StaffRegistration
        public ActionResult Index()
        {
            return View();
        }

        // GET: StaffRegistration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffRegistration/Create
        [HttpPost]
        public ActionResult Create(StaffRegistrationModel staffRegistrationModel)
        {
            DB dbConn = new DB();

            // String connectionString = @"server=localhost;port=3306;user id=root;database=mas_isscs;password=ThirtyFirst9731@;";

            using (MySqlConnection mySqlCon = dbConn.DBConnection())
            {
                mySqlCon.Open();
                String qry = "INSERT INTO users(UserName,UserEmail,UserMobile,Password,ConfirmPassword,UserDepartment,UserType) VALUES(@UserName,@UserEmail,@UserMobile,@Password,@ConfirmPassword,@UserDepartment,@UserType)";
                MySqlCommand mySqlcmd = new MySqlCommand(qry, mySqlCon);

                mySqlcmd.Parameters.AddWithValue("@UserName", staffRegistrationModel.UserFullName);
                mySqlcmd.Parameters.AddWithValue("@UserEmail", staffRegistrationModel.UserEmail);
                mySqlcmd.Parameters.AddWithValue("@UserMobile", staffRegistrationModel.UserMobile);
                mySqlcmd.Parameters.AddWithValue("@Password", staffRegistrationModel.Password);
                mySqlcmd.Parameters.AddWithValue("@ConfirmPassword", staffRegistrationModel.ConfirmPassword);
                mySqlcmd.Parameters.AddWithValue("@UserDepartment", staffRegistrationModel.UserDepartment);
                mySqlcmd.Parameters.AddWithValue("@UserType", staffRegistrationModel.UserType);

                mySqlcmd.ExecuteNonQuery();


            }

            return RedirectToAction("Create");

        }

        // GET: StaffRegistration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StaffRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffRegistration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
