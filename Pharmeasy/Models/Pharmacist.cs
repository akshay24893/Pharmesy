namespace Pharmeasy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pharmacist")]
    public partial class Pharmacist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pharmacist()
        {
            Approvals = new HashSet<Approval>();
        }

        [Key]
        public int pharmacist_id { get; set; }

        [StringLength(15)]
        [DisplayName("First Name")]
        public string fname { get; set; }

        [StringLength(15)]
        [DisplayName("Last Name")]
        public string lname { get; set; }

        [StringLength(15)]
        public string mobile { get; set; }

        [Required]
        [DisplayName("mobile")]
        [StringLength(50)]
        public string ph_email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Approval> Approvals { get; set; }
    }
}
