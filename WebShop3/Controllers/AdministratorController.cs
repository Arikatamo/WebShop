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
                    Category = new CategoriesItemViewModel { Name = prod.Categories.Name }
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
                    Name = item.Name,
                    //Products = item.Products.Select
                    //(
                    //    x => new ProductsItemsViewModel
                    //    {
                    //        DateCreate = x.CreateDate,
                    //        Discription = x.Discription,
                    //        Id = x.Id,
                    //        LastChange = x.LastChange,
                    //        Name = x.Name,
                    //        Price = x.Price
                    //    }
                    //).ToList()
                }
                ).ToList();
            return PartialView(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteCategory(CategoriesItemViewModel Delete)
        {
           // var model = category.Get_All().FirstOrDefault(x=> x.Id == id);
           
            return PartialView();
        }

    }
}