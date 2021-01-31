using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class PlanDetailModel
    {
        public int id { get; set; }
        public DateTime exprireDate { get; set; }
        public DateTime extendDate { get; set; }
        public double amount { get; set; }
        public string detail { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public int accountId { get; set; }
        public int planId { get; set; }
    }
}