namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_CUSTOMER()
        {
            TB_PLAN_DETAIL = new HashSet<TB_PLAN_DETAIL>();
        }

        [Key]
        public int N_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string S_CODE { get; set; }

        [Required]
        [StringLength(50)]
        public string S_ACCOUNT { get; set; }

        [Required]
        [StringLength(50)]
        public string S_PASSWORD { get; set; }

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


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_PLAN_DETAIL> TB_PLAN_DETAIL { get; set; }

        public string PLAN_NAME { get; set; }

        public DateTime? D_EXPRIRE { get; set; }

    }
}
