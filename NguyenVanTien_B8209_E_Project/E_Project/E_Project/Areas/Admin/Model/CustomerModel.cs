using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class CustomerModel
    {
        public int id { get; set; }

        
        public string customerName { get; set; }
        public string code { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string accountName { get; set; }
        public string planName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime exprireDate { get; set; }
        public string status { get; set; }
        public PlanDetailModel planDetail { get; set; }
        public int saleId { get; set; }
        public int planId { get; set; }

        public List<DropDownModel> saleList { get; set; }

        public List<DropDownModel> planList { get; set; }
    }
}