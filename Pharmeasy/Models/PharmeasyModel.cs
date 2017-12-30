namespace Pharmeasy.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PharmeasyModel : DbContext
    {
        public PharmeasyModel()
            : base("name=PharmeasyModel")
        {
        }

        public virtual DbSet<Approval> Approvals { get; set; }
        public virtual DbSet<DoctorData> DoctorDatas { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Pharmacist> Pharmacists { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Prscptn_mdicn_master> Prscptn_mdicn_master { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorData>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<DoctorData>()
                .Property(e => e.lname)
                .IsUnicode(false);

            modelBuilder.Entity<DoctorData>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<DoctorData>()
                .Property(e => e.doc_email)
                .IsUnicode(false);

            modelBuilder.Entity<DoctorData>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.medicine_name)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<Pharmacist>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<Pharmacist>()
                .Property(e => e.lname)
                .IsUnicode(false);

            modelBuilder.Entity<Pharmacist>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Pharmacist>()
                .Property(e => e.ph_email)
                .IsUnicode(false);

            modelBuilder.Entity<Pharmacist>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.treatment)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.lname)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.usr_email)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
