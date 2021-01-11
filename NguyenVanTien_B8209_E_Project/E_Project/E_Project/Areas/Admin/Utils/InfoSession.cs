using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Utils
{
    [Serializable]
    public class InfoSession
    {
        public int id { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string fullName { get; set; }
        public string type { get; set; }
        public string address { get; set; }
        public DateTime birthDay { get; set; }
    }
}