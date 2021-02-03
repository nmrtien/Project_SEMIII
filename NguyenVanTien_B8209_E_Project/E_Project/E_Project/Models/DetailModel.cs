using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Models
{
    public class DetailModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int total { get; set; }
        public double totalAmount { get; set; }
    }
}