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
            //    new ECategoryProduct { Id = 1,  Name = "����"},
            //     new ECategoryProduct { Id = 2,  Name = "����"},
            //      new ECategoryProduct { Id = 3,  Name = "���"},
            //       new ECategoryProduct { Id = 4,  Name = "��������"},
            //        new ECategoryProduct { Id = 5,  Name = "�����"}
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
                //³���������� ��������
                new EVitamins { Id = 17, Name = "�����"},
                new EVitamins { Id = 18, Name = "˳���� �������"},
                new EVitamins { Id = 19, Name = "�������"},
                //Microelements
                new EVitamins { Id = 20, Name = "�������"},
                new EVitamins { Id = 21, Name = "������"},
                new EVitamins { Id = 22, Name = "�����"},
                new EVitamins { Id = 23, Name = "����"},
                new EVitamins { Id = 24, Name = "�����"},
                new EVitamins { Id = 25, Name = "���"},
                new EVitamins { Id = 26, Name = "����"},
                new EVitamins { Id = 27, Name = "����" },
                new EVitamins { Id = 28, Name = "�����" },
                new EVitamins { Id = 29, Name = "̳��"},
                new EVitamins { Id = 30, Name = "���������" },
                new EVitamins { Id = 31, Name = "����" },
                new EVitamins { Id = 32, Name = "��������"},
                new EVitamins { Id = 33, Name = "�����" },
                new EVitamins { Id = 34, Name = "����"},
                new EVitamins { Id = 35, Name = "���������"}
            };

            List<EProducts> Products = new List<EProducts>
            {
                new EProducts { Id = 1, Categories = new ECategoryProduct{ Id = 1, Name = "����" }, Name = "�������", Price = 100, Vitamins = new List<EVitamins>()}
                
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
