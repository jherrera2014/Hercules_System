namespace Hercules.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Photo)
                .IsUnicode(false);

        }
    }
}
