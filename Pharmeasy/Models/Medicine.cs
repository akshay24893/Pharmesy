namespace Pharmeasy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicine")]
    public partial class Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine()
        {
            Prscptn_mdicn_master = new HashSet<Prscptn_mdicn_master>();
        }

        [Key]
        public int medicine_id { get; set; }

        [StringLength(50)]
        [DisplayName("medicine name")]
        public string medicine_name { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prscptn_mdicn_master> Prscptn_mdicn_master { get; set; }
    }
}
