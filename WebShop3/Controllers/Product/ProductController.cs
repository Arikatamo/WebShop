using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop3.Entity;
using WebShop3.Models.ViewProducts;
namespace WebShop3.Controllers.ProductController
{
    public class ProductController : Controller
    {
        private readonly EFContext _context;
        public ProductController()
        {

            _context = new EFContext();
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = _context.eProducts.Select
                (prod => new ProductsItemsView
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