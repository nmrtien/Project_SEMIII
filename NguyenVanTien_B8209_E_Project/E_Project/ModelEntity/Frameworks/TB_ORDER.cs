namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_ORDER
    {
        [Key]
        public int N_ID { get; set; }

        [Required]
        public double N_AMOUNT { get; set; }

        [Required]
        public int N_TOTAL { get; set; }

        [Required]
        [StringLength(50)]
        public string S_CUSTOMER_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string S_TYPE { get; set; }

        [Required]
        [StringLength(50)]
        public string S_PHONE { get; set; }

        [Required]
        [StringLength(50)]
        public string S_ADDRESS { get; set; }

        [Required]
        [StringLength(500)]
        public string S_DESCRIPTION { get; set; }

        [Required]
        [StringLength(50)]
        public string S_STATUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_CREATED { get; set; }

        public int? N_PRODUCT_ID { get; set; }
        public int? N_PLAN_ID { get; set; }

        public int? N_CUSTOMER_ID { get; set; }

        public double? PRICE { get; set; }

        public virtual TB_PRODUCT TB_PRODUCT { get; set; }

        public string PRODUCT_NAME { get; set; }
        public string PLAN_NAME { get; set; }
        public string S_DETAIL { get; set; }
    }
}