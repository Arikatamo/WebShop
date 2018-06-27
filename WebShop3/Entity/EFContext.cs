using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebShop3.Entity.Products;

namespace WebShop3.Entity
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Connection")
        {

        }

       public DbSet<EProducts> eProducts { get; set; }
       public DbSet<ECategoryProduct> eCategories { get; set; }
       public DbSet<EVitamins> eVitamins { get; set; }

    }
}