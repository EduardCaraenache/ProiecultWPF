using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CeaiModel
{
    public partial class CeaiModel1 : DbContext
    {
        public CeaiModel1()
            : base("name=CeaiModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Inventory>()
                .Property(e => e.Flavor)
                .IsFixedLength();

            modelBuilder.Entity<Inventory>()
                .Property(e => e.Quality)
                .IsFixedLength();

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Inventory)
                .WillCascadeOnDelete();
        }
    }
}
