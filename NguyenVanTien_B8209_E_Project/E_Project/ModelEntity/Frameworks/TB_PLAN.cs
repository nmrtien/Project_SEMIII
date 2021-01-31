namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_PLAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_PLAN()
        {
            TB_PLAN_DETAIL = new HashSet<TB_PLAN_DETAIL>();
        }

        [Key]
        public int N_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string S_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string S_TYPE { get; set; }

        [Required]
        [StringLength(500)]
        public string S_DETAIL { get; set; }

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
    }
}