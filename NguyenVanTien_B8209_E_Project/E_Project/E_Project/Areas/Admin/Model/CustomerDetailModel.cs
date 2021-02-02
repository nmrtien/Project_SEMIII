using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEntity.Frameworks;

namespace E_Project.Areas.Admin.Model
{
    public class CustomerDetailModel
    {
        public IEnumerable<TB_PLAN> Plans { get; set; }

        public PlanDetailModel planDetail { get; set; }
        public int customerId { get; set; }
        public int planId { get; set; }
    }
}