namespace Pharmeasy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prescription()
        {
            Prscptn_mdicn_master = new HashSet<Prscptn_mdicn_master>();
        }

        [Key]
        public int presciption_id { get; set; }

        [Required]
        [StringLength(50)]
        public string treatment { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? date { get; set; }

        public int? doc_id { get; set; }

        public int? user_id { get; set; }

        public virtual DoctorData DoctorData { get; set; }

        public virtual UserData UserData { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prscptn_mdicn_master> Prscptn_mdicn_master { get; set; }
    }
}
