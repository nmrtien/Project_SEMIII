using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class AccountModel
    {
        public int id { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string technical { get; set; }
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime birthDay { get; set; }
        public int storeId { get; set; }
        public int departmentId { get; set; }

        public int type { get; set; }
        public List<DropDownModel> storeList { get; set; }

        public List<DropDownModel> departmentList { get; set; }

        public List<DropDownModel> accountTypeList { get; set; }
     
    }


}