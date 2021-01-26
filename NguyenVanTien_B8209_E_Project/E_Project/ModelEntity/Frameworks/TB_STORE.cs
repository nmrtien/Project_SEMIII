namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_STORE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_STORE()
        {
            TB_ACCOUNT = new HashSet<TB_ACCOUNT>();
        }

        [Key]
        public int N_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string S_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string S_CONTACT { get; set; }

        [Required]
        [StringLength(50)]
        public string S_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string S_STATUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_CREATED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ACCOUNT> TB_ACCOUNT { get; set; }
    }
}
