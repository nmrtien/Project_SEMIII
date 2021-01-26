namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_CUSTOMER
    {
        [Key]
        public int N_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string S_CODE { get; set; }

        [Required]
        [StringLength(50)]
        public string S_NAME { get; set; }

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

        public int? N_ACCOUNT_ID { get; set; }

        public int? N_PLAN_DETAIL_ID { get; set; }

        public virtual TB_ACCOUNT TB_ACCOUNT { get; set; }

        public virtual TB_PLAN_DETAIL TB_PLAN_DETAIL { get; set; }
    }
}
