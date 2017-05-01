namespace Vaccine_Webapi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<Barn> Barn { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Historik> Historik { get; set; }
        public virtual DbSet<Kalender> Kalender { get; set; }
        public virtual DbSet<Vaccine> Vaccine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
