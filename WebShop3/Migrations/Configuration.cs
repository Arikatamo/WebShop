namespace WebShop3.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebShop3.DAL.Entities;
    using WebShop3.Entity.Products;

    internal sealed class Configuration : DbMigrationsConfiguration<EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFContext context)
        {
           

            //List<ECategoryProduct> Categories = new List<ECategoryProduct>
            //{
            //    new ECategoryProduct { Id = 1,  Name = "Мясо"},
            //     new ECategoryProduct { Id = 2,  Name = "Риба"},
            //      new ECategoryProduct { Id = 3,  Name = "Хліб"},
            //       new ECategoryProduct { Id = 4,  Name = "Макарони"},
            //        new ECategoryProduct { Id = 5,  Name = "Крупи"}
            //};
            //foreach (var item in Categories)
            //{
            //    context.eCategories.AddOrUpdate(item);
            //}


            List<EVitamins> Vitamins = new List<EVitamins>
            {
            new EVitamins { Id = 1, Name = "A"},
                new EVitamins { Id = 2, Name = "B"},
                new EVitamins { Id = 3, Name = "B1"},
                new EVitamins { Id = 4, Name = "B2"},
                new EVitamins { Id = 5, Name = "B3"},
                new EVitamins { Id = 6, Name = "B4"},
                new EVitamins { Id = 7, Name = "B5"},
                new EVitamins { Id = 8, Name = "B6(PP)"},
                new EVitamins { Id = 9, Name = "B9"},
                new EVitamins { Id = 10, Name = "B12"},
                new EVitamins { Id = 11, Name = "D"},
                new EVitamins { Id = 12, Name = "E"},
                new EVitamins { Id = 13, Name = "K"},
                new EVitamins { Id = 14, Name = "H"},
                new EVitamins { Id = 15, Name = "C"},
                new EVitamins { Id = 16, Name = "PP"},
                //ВітаміноПодібні Речовини
                new EVitamins { Id = 17, Name = "Рутин"},
                new EVitamins { Id = 18, Name = "Лівоєва Кислота"},
                new EVitamins { Id = 19, Name = "Карнітин"},
                //Microelements
                new EVitamins { Id = 20, Name = "Кальцій"},
                new EVitamins { Id = 21, Name = "Фосфор"},
                new EVitamins { Id = 22, Name = "Магній"},
                new EVitamins { Id = 23, Name = "Калій"},
                new EVitamins { Id = 24, Name = "Залізо"},
                new EVitamins { Id = 25, Name = "Йод"},
                new EVitamins { Id = 26, Name = "Фтор"},
                new EVitamins { Id = 27, Name = "Цинк" },
                new EVitamins { Id = 28, Name = "Селен" },
                new EVitamins { Id = 29, Name = "Мідь"},
                new EVitamins { Id = 30, Name = "Марганець" },
                new EVitamins { Id = 31, Name = "Хром" },
                new EVitamins { Id = 32, Name = "Молибден"},
                new EVitamins { Id = 33, Name = "Білки" },
                new EVitamins { Id = 34, Name = "Жири"},
                new EVitamins { Id = 35, Name = "Вуглеводи"}
            };

            List<EProducts> Products = new List<EProducts>
            {
                new EProducts { Id = 1, Categories = new ECategoryProduct{ Id = 1, Name = "Мясо" }, Name = "Свинина", Price = 100, Vitamins = new List<EVitamins>()}
                
            };

            foreach (var item in Vitamins)
            {
                context.eVitamins.AddOrUpdate(item);
            }



            foreach (var item in Products)
            {
                context.eProducts.AddOrUpdate(item);
            }


            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
