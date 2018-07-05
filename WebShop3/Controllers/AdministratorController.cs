using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop3.DAL.Abstract;
using WebShop3.Models.ViewProducts;

namespace WebShop3.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IProductProvider product;
        private readonly ICategoryProvider category;

        public AdministratorController(IProductProvider product, ICategoryProvider category)
        {
            this.product = product;
            this.category = category;
        }

        // GET: Administrator
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Product(string Product)
        {
            var model = product.GetAll().Select
                (prod => new ProductsItemsViewModel
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Discription = prod.Discription,
                    Price = prod.Price,
                    DateCreate = prod.CreateDate,
                    LastChange = prod.LastChange,
                    Category = prod.Categories.Select(x=> new CategoriesItemViewModel
                    {
                        Discription= x.Discription,
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
                }).ToList();
            return PartialView(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Category(string Category)
        {
            var model = category.Get_All().Select
                (
                item => new CategoriesItemViewModel
                {
                    Id = item.Id,
                    Discription = item.Discription,
                    Name = item.Name
                }
                ).ToList();
            return PartialView(model);
        }
        //[HttpPost]
        [AllowAnonymous]
        public ActionResult CategoryDelete(int id)
        {
            category.Remove(id);
            var Category = category.Get_All().Select
              (
              item => new CategoriesItemViewModel
              {
                  Id = item.Id,
                  Discription = item.Discription,
                  Name = item.Name
              }
              ).ToList();
            return PartialView("Category", Category);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CategoryEdit(int id)
        {
             var model = category.Get_All().Select
              (
              item => new CategoriesItemViewModel
              {
                  Id = item.Id,
                  Discription = item.Discription,
                  Name = item.Name
              }
              ).FirstOrDefault(x=> x.Id==id);
            return PartialView(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CategoryEdit(CategoriesItemViewModel item)
        {
            var model = category.Get_Category(item.Id);
            if (item != null)
            {
                model.Name = item.Name;
                model.Discription = item.Discription;
                category.SaveChange();
            }
            var Category = category.Get_All().Select
               (
               it => new CategoriesItemViewModel
               {
                   Id = it.Id,
                   Discription = it.Discription,
                   Name = it.Name
               }
               ).ToList();
            return PartialView("Category", Category);
        }
    }
}