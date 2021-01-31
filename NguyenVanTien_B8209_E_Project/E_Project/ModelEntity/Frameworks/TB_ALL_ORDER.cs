namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_ALL_ORDER
    {
        public int N_ID { get; set; }

        [Required]
        public double AMOUNT { get; set; }

        [Required]
        public int TOTAL { get; set; }

        [Required]
        [StringLength(50)]
        public string S_CUSTOMER_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string S_PHONE { get; set; }

        [Required]
        [StringLength(50)]
        public string S_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string S_STATUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_CREATED { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCT_NAME { get; set; }

        public string PLAN_NAME { get; set; }

    }
}