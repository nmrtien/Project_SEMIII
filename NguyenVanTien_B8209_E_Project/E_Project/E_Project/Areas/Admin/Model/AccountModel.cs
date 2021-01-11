using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class AccountModel
    {
        public int id { get; set; }
        public string employeeName { get; set; }

        public AccountModel(int id, string employeeName)
        {
            this.id = id;
            this.employeeName = employeeName;
        }
    }
}