namespace Pharmeasy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Approval")]
    public partial class Approval
    {
        [Key]
        public int approval_id { get; set; }

        public int? user_id { get; set; }

        public int? app_doc { get; set; }

        public int? app_ph { get; set; }

        public int? doc_id { get; set; }

        public int? pharmacist_id { get; set; }

        public virtual DoctorData DoctorData { get; set; }

        public virtual Pharmacist Pharmacist { get; set; }

        public virtual UserData UserData { get; set; }
    }
}
