namespace Pharmeasy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prscptn_mdicn_master
    {
        [Key]
        public int prscptn_mdicn_masters_id { get; set; }

        public int? presciption_id { get; set; }

        public int? medicine_id { get; set; }

        public virtual Medicine Medicine { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
