namespace ModelEntity.Frameworks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_STORE
    {
        [Key]
        [StringLength(50)]
        public string S_ID { get; set; }

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

        [StringLength(50)]
        public string S_EMPLOYEE_ID { get; set; }

        public virtual TB_ACCOUNT TB_ACCOUNT { get; set; }

        [StringLength(50)]
        public string S_EMPLOYEE_NAME { get; set; }
    }
}
