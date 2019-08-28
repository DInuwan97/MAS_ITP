using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAS_Sustainability
{
    public class UserRegistrationModel
    {
        public int UserID { get; set; }

        public String UserFullName { get; set; }

        public String UserMobile { get; set; }

        public String UserEmail { get; set; }


        public String UserDepartment { get; set; }

        public String Password { get; set; }

        public String ConfirmPassword { get; set;}

        public String UserType { get; set; }

        public HttpPostedFileBase UserImage { get; set; }

        public string UserImagePath { get; set; }

  

        public int SecretKey { get; set; }


        public IEnumerable <SelectListItem> TypeList
        {
            get
            {

                return new List <SelectListItem>

        {
            new SelectListItem { Text = "Factory Engineering", Value = "Factory Engineering"},
            new SelectListItem { Text = "Production Engineering", Value = "Production Engineering"},
            new SelectListItem { Text = "Autonomation", Value = "Autonomation"},
            new SelectListItem { Text = "MOS", Value = "MOS"},
            new SelectListItem { Text = "RM", Value = "RM"},
            new SelectListItem { Text = "Quality", Value = "Quality"},
            new SelectListItem { Text = "FG", Value = "FG"},
            new SelectListItem { Text = "Technical", Value = "Technical"},
            new SelectListItem { Text = "Cutting", Value = "Cutting"},
            new SelectListItem { Text = "HR", Value = "HR"},
            new SelectListItem { Text = "Operation", Value = "Operation"},
            new SelectListItem { Text = "Production VSM 01", Value = "Production VSM 01"},
            new SelectListItem { Text = "Production VSM 02", Value = "Production VSM 02"},
            new SelectListItem { Text = "Production VSM 03", Value = "Production VSM 03"},
            new SelectListItem { Text = "Production VSM 04", Value = "Production VSM 04"},
            new SelectListItem { Text = "Pre-Sewing", Value = "Pre-Sewing"},
            new SelectListItem { Text = "Emblishment", Value = "Emblishment"},
            new SelectListItem { Text = "IE", Value = "IE"}

        };
            }
        }


    }
}