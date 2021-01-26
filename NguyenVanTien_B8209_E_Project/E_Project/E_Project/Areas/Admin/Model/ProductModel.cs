using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class ProductModel
    {
        public int id { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string type { get; set; }
        public string detail { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public string status { get; set; }
    }
}