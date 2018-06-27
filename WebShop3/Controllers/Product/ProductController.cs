using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop3.DAL.Abstract;
using WebShop3.DAL.Entities;
using WebShop3.Models.ViewProducts;
namespace WebShop3.Controllers.ProductController
{
    public class ProductController : Controller
    {
        private readonly IProductProvider _context;
        public ProductController(IProductProvider productprovider)
        {

            _context = productprovider;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = _context.GetAll().Select
                (prod => new ProductsItemsViewModel
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Discription = prod.Discription,
                    Price = prod.Price,
                    DateCreate = prod.CreateDate
                }).ToList();
                return View(model);
        }

    }
}