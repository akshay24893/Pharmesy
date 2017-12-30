namespace Pharmeasy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoctorData")]
    public partial class DoctorData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoctorData()
        {
            Approvals = new HashSet<Approval>();
            Prescriptions = new HashSet<Prescription>();
        }

        [Key]
        public int doc_id { get; set; }


        [StringLength(15)]
        [DisplayName("First Name")]
        public string fname { get; set; }

        [StringLength(15)]
        [DisplayName("Last Name")]
        public string lname { get; set; }

        [StringLength(15)]
        public string mobile { get; set; }

        [Required]
        [DisplayName("E-mail")]
        [StringLength(50)]
        public string doc_email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Approval> Approvals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
