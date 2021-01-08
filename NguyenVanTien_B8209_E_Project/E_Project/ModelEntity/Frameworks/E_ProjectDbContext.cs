using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEntity.Frameworks
{
    public partial class E_ProjectDbContext : DbContext
    {
        public E_ProjectDbContext()
            : base("name=E_ProjectDbContext")
        {
        }

        public virtual DbSet<TB_ACCOUNT> TB_ACCOUNT { get; set; }
        public virtual DbSet<TB_STORE> TB_STORE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_ACCOUNT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_FULLNAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .HasMany(e => e.TB_STORE)
                .WithOptional(e => e.TB_ACCOUNT)
                .HasForeignKey(e => e.S_EMPLOYEE_ID);

            modelBuilder.Entity<TB_STORE>()
                .Property(e => e.S_ID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_STORE>()
                .Property(e => e.S_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_STORE>()
                .Property(e => e.S_CONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_STORE>()
                .Property(e => e.S_ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_STORE>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_STORE>()
                .Property(e => e.S_EMPLOYEE_ID)
                .IsUnicode(false);
        }
    }
}
