namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_PLAN_DETAIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_PLAN_DETAIL()
        {
            TB_CUSTOMER = new HashSet<TB_CUSTOMER>();
        }

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

        public int? N_PRODUCT_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CUSTOMER> TB_CUSTOMER { get; set; }

        public virtual TB_PLAN TB_PLAN { get; set; }

        public virtual TB_PRODUCT TB_PRODUCT { get; set; }
    }
}
