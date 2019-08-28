using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAS_Sustainability.Models
{
    public class StaffRegistrationModel
    {
        public int UserID { get; set; }
        public String UserFullName { get; set; }
        public String UserMobile { get; set; }
        public String UserEmail { get; set; }
        public String UserDepartment { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
        public String UserType { get; set; }
    }
}