using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEntity;
using ModelEntity.Frameworks;

namespace E_Project.Models
{
    public class IndexModel
    {
        public IEnumerable<TB_PLAN> Plans { get; set; }
        public IEnumerable<TB_PRODUCT> Products { get; set; }
    }
}