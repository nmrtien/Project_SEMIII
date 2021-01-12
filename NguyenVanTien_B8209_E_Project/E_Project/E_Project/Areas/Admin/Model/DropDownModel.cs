using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Model
{
    public class DropDownModel
    {
        public int id { get; set; }
        public string modelName { get; set; }

        public DropDownModel (int id, string modelName)
        {
            this.id = id;
            this.modelName = modelName;
        }
    }
}