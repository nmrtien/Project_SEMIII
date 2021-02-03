using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEntity;
using ModelEntity.Frameworks;

namespace E_Project.Models
{
    public class CardModel
    {
        public IEnumerable<TB_ORDER> orders { get; set; }
        public double total { get; set; }
    }
}