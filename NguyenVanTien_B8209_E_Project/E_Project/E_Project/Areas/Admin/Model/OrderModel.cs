using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class OrderModel
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public string productName { get; set; }
        public string planName { get; set; }
        public double amount { get; set; }
        public double total { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public string status { get; set; }
        public int product_id { get; set; }

        public int plan_id { get; set; }

        public int customer_id { get; set; }
    }
}