namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_PLAN_DETAIL
    {
        [Key]
        public int N_ID { get; set; }

        public double N_AMOUNT { get; set; }

        [StringLength(500)]
        public string S_DETAIL { get; set; }

        [StringLength(500)]
        public string S_DESCRIPTION { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_EXPRIRE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? D_EXTENED { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_CREATED { get; set; }

        public int? N_PLAN_ID { get; set; }

        public int? N_CUSTOMER_ID { get; set; }

        public virtual TB_CUSTOMER TB_CUSTOMER { get; set; }

        public virtual TB_PLAN TB_PLAN { get; set; }
    }
}
