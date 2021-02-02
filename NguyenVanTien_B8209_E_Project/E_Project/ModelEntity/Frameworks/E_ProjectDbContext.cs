namespace ModelEntity.Frameworks
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class E_ProjectDbContext : DbContext
    {
        public E_ProjectDbContext()
            : base("name=E_ProjectDbContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TB_ACCOUNT> TB_ACCOUNT { get; set; }
        public virtual DbSet<TB_CUSTOMER> TB_CUSTOMER { get; set; }
        public virtual DbSet<TB_DEPARTMENT> TB_DEPARTMENT { get; set; }
        public virtual DbSet<TB_ORDER> TB_ORDER { get; set; }
        public virtual DbSet<TB_PLAN> TB_PLAN { get; set; }
        public virtual DbSet<TB_PLAN_DETAIL> TB_PLAN_DETAIL { get; set; }
        public virtual DbSet<TB_PRODUCT> TB_PRODUCT { get; set; }
        public virtual DbSet<TB_STORE> TB_STORE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
                .Property(e => e.S_TECHNICAL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCOUNT>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            /*modelBuilder.Entity<TB_ACCOUNT>()
                .HasMany(e => e.TB_CUSTOMER)
                .WithOptional(e => e.TB_ACCOUNT)
                .HasForeignKey(e => e.N_ACCOUNT_ID);*/

            modelBuilder.Entity<TB_CUSTOMER>()
                .Property(e => e.S_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_CUSTOMER>()
                .Property(e => e.S_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_CUSTOMER>()
                .Property(e => e.S_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_CUSTOMER>()
                .Property(e => e.S_ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_CUSTOMER>()
                .Property(e => e.S_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_CUSTOMER>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_CUSTOMER>()
                .HasMany(e => e.TB_PLAN_DETAIL)
                .WithOptional(e => e.TB_CUSTOMER)
                .HasForeignKey(e => e.N_CUSTOMER_ID);

            modelBuilder.Entity<TB_DEPARTMENT>()
                .Property(e => e.S_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DEPARTMENT>()
                .Property(e => e.S_CONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DEPARTMENT>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_DEPARTMENT>()
                .HasMany(e => e.TB_ACCOUNT)
                .WithOptional(e => e.TB_DEPARTMENT)
                .HasForeignKey(e => e.N_DEPARTMENT_ID);

            modelBuilder.Entity<TB_ORDER>()
                .Property(e => e.S_CUSTOMER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ORDER>()
                .Property(e => e.S_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ORDER>()
                .Property(e => e.S_ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ORDER>()
                .Property(e => e.S_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ORDER>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PLAN>()
                .Property(e => e.S_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PLAN>()
                .Property(e => e.S_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PLAN>()
                .Property(e => e.S_DETAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PLAN>()
                .Property(e => e.S_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PLAN>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            /*modelBuilder.Entity<TB_PLAN>()
                .HasMany(e => e.TB_ORDER)
                .WithOptional(e => e.TB_PLAN)
                .HasForeignKey(e => e.N_PLAN_ID);*/

            modelBuilder.Entity<TB_PLAN>()
                .HasMany(e => e.TB_PLAN_DETAIL)
                .WithOptional(e => e.TB_PLAN)
                .HasForeignKey(e => e.N_PLAN_ID);

            modelBuilder.Entity<TB_PLAN_DETAIL>()
                .Property(e => e.S_DETAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PLAN_DETAIL>()
                .Property(e => e.S_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PRODUCT>()
                .Property(e => e.S_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PRODUCT>()
                .Property(e => e.S_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PRODUCT>()
                .Property(e => e.S_DETAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PRODUCT>()
                .Property(e => e.S_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PRODUCT>()
                .Property(e => e.S_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PRODUCT>()
                .HasMany(e => e.TB_ORDER)
                .WithOptional(e => e.TB_PRODUCT)
                .HasForeignKey(e => e.N_PRODUCT_ID);

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
                .HasMany(e => e.TB_ACCOUNT)
                .WithOptional(e => e.TB_STORE)
                .HasForeignKey(e => e.N_STORE_ID);
        }
    }
}
