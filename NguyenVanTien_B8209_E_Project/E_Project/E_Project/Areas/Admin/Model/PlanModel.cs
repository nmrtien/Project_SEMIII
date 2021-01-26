using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class PlanModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string detail { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public string status { get; set; }
    }
}