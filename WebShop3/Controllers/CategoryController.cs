using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop3.DAL.Abstract;
using WebShop3.Models.ViewProducts;

namespace WebShop3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryProvider _context;

        public CategoryController(ICategoryProvider productprovider)
        {
            _context = productprovider;
        }

        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            var model = _context.Get_All().Select
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
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = _context.Get_Category(id);
            CategoriesItemViewModel model = new CategoriesItemViewModel
            {
                Id = item.Id,
                Discription = item.Discription,
                Name = item.Name
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriesItemViewModel item)
        {
            _context.Remove(item.Id);
            RedirectToAction("Index");
            return View();
        }
    }
}