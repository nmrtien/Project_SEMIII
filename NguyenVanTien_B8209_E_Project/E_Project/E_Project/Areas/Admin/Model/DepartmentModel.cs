using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEntity;

namespace E_Project.Areas.Admin.Model
{
    public class DepartmentModel
    {
        public int id { get; set; }
        public string departmentName { get; set; }
        public string contact { get; set; }
        public DateTime createdDate { get; set; }
        public string status { get; set; }
    }
}