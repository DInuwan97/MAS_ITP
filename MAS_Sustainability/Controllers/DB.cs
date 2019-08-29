using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAS_Sustainability.Models;
using MySql.Data.MySqlClient;

namespace MAS_Sustainability.Controllers
{
    public class DB
    {
        private String connectionString = @"server=localhost;port=3307;user id=root;password=admin;database=mas_isscs;";

        public MySqlConnection DBConnection()
        {
            MySqlConnection mySqlConn = new MySqlConnection(connectionString);
            return mySqlConn;
        }

        internal MySqlConnection DBConnection(StaffRegistrationModel staffRegistrationModel1, object staffRegistrationModel2)
        {
            throw new NotImplementedException();
        }
    }
}