using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebShop3.DAL.Abstract;
using WebShop3.DAL.Entities;
using WebShop3.Models.ViewProducts;
using WebShop3.Models;
using WebShop3.DAL.Concrete;

namespace WebShop3.Controllers.ProductController
{
    public class ProductController : Controller
    {
        private readonly IProductProvider _context;
        private readonly ICategoryProvider _context2;
        public ProductController(IProductProvider productprovider, ICategoryProvider item)
        {
            _context = productprovider;
            _context2 = item;
        }
        //GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            var model = _context.GetAll().Select
                (prod => new ProductsItemsViewModel
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Discription = prod.Discription,
                    Price = prod.Price,
                    DateCreate = prod.CreateDate,
                    LastChange = prod.LastChange,
                    Category =  prod.Categories.Select(x => new CategoriesItemViewModel
                    {
                        Discription = x.Discription,
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
                }).ToList();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var product = _context.GetProduct(id);
            if (product != null)
            {
                ProductsItemsViewModel model = new ProductsItemsViewModel
                {
                    Name = product.Name,
                    Discription = product.Discription,
                    Price = product.Price,
                    ImagePath = product.Image,
                    DateCreate = product.CreateDate,
                    LastChange = product.LastChange,
                    Category = product.Categories.Select(x=> new CategoriesItemViewModel
                    {
                        Discription = x.Discription,
                        Name = x.Name
                    }).ToList(),
                    CategoryId = product.Categories.Select(x => x.Id),
                    CategoryList = _context2.Get_All().Select
                    (x => new SelectItemViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }
                    ).ToList()
                };

                return View(model);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ProductsItemsAddViewModel model = new ProductsItemsAddViewModel();
            model.CategoryList = _context2.Get_All()
                .Select(r => new SelectItemViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(ProductsItemsAddViewModel item)
        {

            if (ModelState.IsValid)
            {
                _context.AddProduct(item);
                return RedirectToAction("Index");
            }
            else
            {
                item.CategoryList = _context2.Get_All()
                .Select(r => new SelectItemViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList();
            }    
            return View(item);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        { ///
            var product = _context.GetProduct(id);
            if (product != null)
            {
                ProductsItemsAddViewModel model = new ProductsItemsAddViewModel
                {
                    Name = product.Name,
                    Discription = product.Discription,
                    Price = product.Price,
                    CategoryId = product.Categories.Select(x => x.Id),
                    CategoryList = _context2.Get_All().Select
                    (x=> new SelectItemViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }
                    ).ToList()
                };

                return View(model);
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsItemsAddViewModel item)
        {
            if (ModelState.IsValid)
            {
                _context.ChangeProduct(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = _context.GetProduct(id);
            ProductsItemsViewModel model = new ProductsItemsViewModel
            {
                Id = item.Id,
                DateCreate = item.CreateDate,
                Discription = item.Discription,
                Name = item.Name,
                Price = item.Price

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductsItemsAddViewModel item)
        {
            _context.Remove(item.Id);
            return RedirectToAction("Index");
         
           // return View();
        }
    }
}