using eShowroom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eShowroom.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approvisonnement>().HasKey(am => new { am.BonEntreeId, am.ProductId });

            modelBuilder.Entity<Approvisonnement>().HasOne(m => m.Product).WithMany(am => am.Approvisonnements).HasForeignKey(m => m.ProductId);
            modelBuilder.Entity<Approvisonnement>().HasOne(m => m.BonEntree).WithMany(am => am.Approvisonnements).HasForeignKey(m => m.BonEntreeId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BonEntree> BonEntrees { get; set; }
        public DbSet<Approvisonnement> Approvisonnements { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
