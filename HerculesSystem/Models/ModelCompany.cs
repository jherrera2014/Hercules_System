namespace Hercules.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCompany : DbContext
    {
        public ModelCompany()
            : base("name=ModelCompany")
        {
        }

        public virtual DbSet<Company> company { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
