using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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

        public EProducts AddProduct(ProductsItemsAddViewModel item)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                EProducts product = new EProducts
                {
                    Name = item.Name,
                    Discription = item.Discription,
                    Price = item.Price
                    //Vitamins = new List<EVitamins>(),
                    //Categories = new ECategoryProduct()

                };

                //if (item.Category != null)
                //{
                //    var category = _context.eCategories.SingleOrDefault(x => x.Name == item.Category.Name);
                //    if (category != null)
                //    {
                //        product.Categories = category;
                //    }
                //}
                _context.eProducts.Add(product);
                _context.SaveChanges();
                scope.Complete();
                return product;
            }
            
        }

        public List<EProducts> GetAll()
        {
            return _context.eProducts.ToList();
        }

        public EProducts GetProduct(int id)
        {
            return _context.eProducts.SingleOrDefault(m => m.Id == id);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}