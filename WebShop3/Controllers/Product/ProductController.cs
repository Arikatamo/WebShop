﻿using System;
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
                    DateCreate = prod.CreateDate
                }).ToList();
                return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductsItemsAddViewModel item)
        {
            if (ModelState.IsValid)
            {
                _context.AddProduct(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _context.GetProduct(id);
            if (product != null)
            {
                ProductsItemsViewModel model = new ProductsItemsViewModel
                {
                    Name = product.Name,
                    Discription = product.Discription,
                    Price = product.Price
                };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ProductsItemsViewModel item)
        {
            var product = _context.GetProduct(item.Id);
            if (product != null && ModelState.IsValid)
            {
                product.Name = item.Name;
                product.Price = item.Price;
                product.Discription = item.Discription;
                _context.SaveChange();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}