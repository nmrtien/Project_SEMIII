using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEntity;

namespace E_Project.Areas.Admin.Model
{
    public class StoreModel
    {
        public int id { get; set; }
        public string storeName { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public DateTime createdDate { get; set; }
        public string status { get; set; }
    }
}