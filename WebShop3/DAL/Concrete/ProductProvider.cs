using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop3.DAL.Abstract;
using WebShop3.DAL.Entities;
using WebShop3.Entity.Products;
using WebShop3.Models.ViewProducts;

namespace WebShop3.DAL.Concrete
{
    public class ProductProvider : IProductProvider
    {
        private EFContext _context;
        public ProductProvider(EFContext context)
        {
            _context = context;
        }

        public EProducts AddProduct(ProductsItemsViewModel item)
        {
            throw new NotImplementedException();
        }

        public List<EProducts> GetAll()
        {
            return _context.eProducts.ToList();
        }

        public EProducts GetProduct(int id)
        {
            return _context.eProducts.SingleOrDefault(m => m.Id == id);
        }
    }
}