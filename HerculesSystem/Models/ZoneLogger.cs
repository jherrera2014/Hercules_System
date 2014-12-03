namespace HerculesSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ZoneLogger : DbContext
    {
        public ZoneLogger()
            : base("name=ZoneLogger")
        {
        }

        public virtual DbSet<zone> zone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<zone>()
                .Property(e => e.ZoneName)
                .IsUnicode(false);
        }
    }
}
