namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_ACCOUNT()
        {
            TB_CUSTOMER = new HashSet<TB_CUSTOMER>();
        }

        [Key]
        public int N_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string S_ACCOUNT { get; set; }

        [Required]
        [StringLength(50)]
        public string S_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string S_TYPE { get; set; }

        [Required]
        [StringLength(50)]
        public string S_FULLNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string S_PHONE { get; set; }

        [Required]
        [StringLength(50)]
        public string S_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string S_TECHNICAL { get; set; }

        [Required]
        [StringLength(50)]
        public string S_STATUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_BIRTHDAY { get; set; }

        public int? N_DEPARTMENT_ID { get; set; }

        public int? N_STORE_ID { get; set; }

        public virtual TB_DEPARTMENT TB_DEPARTMENT { get; set; }

        public virtual TB_STORE TB_STORE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CUSTOMER> TB_CUSTOMER { get; set; }

        public string STORE_NAME { get; set; }

        public string DEPARTMENT_NAME { get; set; }
    }
}