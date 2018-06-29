using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop3.DAL.Abstract;
using WebShop3.Models;

namespace WebShop3.Controllers
{
    public class VitaminsController : Controller
    {
        private readonly IVitaminsProvider _context;
        public VitaminsController(IVitaminsProvider item)
        {
            _context = item;
        }
        // GET: Vitamins
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = _context.Get_All().Select(x => new VitaminsItemViewModel
            {
                Id = x.Id,
                Discription = x.Discription,
                Name = x.Name
            });
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(VitaminsAddViewModel item)
        {

            if (ModelState.IsValid)
            {
                _context.Add_Vitamins(item);
                return RedirectToAction("Index");
            }
            else
            {
                //item.CategoryList = _context2.Get_All()
                //.Select(r => new SelectItemViewModel
                //{
                //    Id = r.Id,
                //    Name = r.Name
                //}).ToList();
                //if (item.CategoryList.Count != 0)
                //    item.CategoryId = item.CategoryList.Last().Id;
                return View(item);
            }
  
        }
        [HttpGet]
        public ActionResult Edit(int id)
        { ///
            var product = _context.Get_Vitamin(id);
            if (product != null)
            {
                VitaminsItemViewModel model = new VitaminsItemViewModel
                {
                    Name = product.Name,
                    Discription = product.Discription,
                    Id = product.Id
                    //Price = product.Price,
                    //DateCreate = product.CreateDate,
                    //LastChange = product.LastChange,
                    //Category = new CategoriesItemViewModel { Id = product.Categories.Id, Name = product.Categories.Name },
                    //CategoryList = _context2.Get_All().Select
                    //(x => new SelectItemViewModel
                    //{
                    //    Id = x.Id,
                    //    Name = x.Name
                    //}
                    //).ToList()
                };

                return View(model);
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VitaminsItemViewModel item)
        {
            var product = _context.Get_Vitamin(item.Id);
            if (product != null && ModelState.IsValid)
            {
                product.Name = item.Name;
                product.Discription = item.Discription;
                //product.Price = item.Price;
                //product.Categories = _context2.Get_Category(item.Category.Id);
                //product.LastChange = DateTime.Now;
                _context.SaveChange();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = _context.Get_Vitamin(id);
            VitaminsItemViewModel model = new VitaminsItemViewModel
            {
                Id = item.Id,
                Discription = item.Discription,
                Name = item.Name,
                //DateCreate = item.CreateDate,
                //Price = item.Price

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VitaminsItemViewModel item)
        {
            _context.Remove(item.Id);
            return RedirectToAction("Index");

            // return View();
        }
    }
}