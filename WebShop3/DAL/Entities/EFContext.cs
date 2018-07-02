using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebShop3.Entity.Products;

namespace WebShop3.DAL.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DefaultConnection") {}
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EProducts> eProducts { get; set; }
        public DbSet<ECategoryProduct> eCategories { get; set; }
        public DbSet<EVitamins> eVitamins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EVitamins>()
                        .HasMany(s => s.Products)
                        .WithMany(c => c.Vitamins)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("VitaminsId");
                            cs.MapRightKey("ProductId");
                        });
            modelBuilder.Entity<EProducts>()
                  .HasMany(s => s.Categories)
                  .WithMany(c => c.Products)
                  .Map(cs =>
                  {
                      cs.MapLeftKey("CategoriesId");
                      cs.MapRightKey("ProductId");
                  });


        }
    }
}