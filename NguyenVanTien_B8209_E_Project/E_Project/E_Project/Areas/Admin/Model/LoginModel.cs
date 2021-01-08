using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required]
        public string account { get; set; }
        public string password { get; set; }

    }
}