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
        
                EProducts product = new EProducts
                {
                    Name = item.Name,
                    Discription = item.Discription,
                    Price = item.Price

                };
            if (item.CategoryId != null)
            {
                var category = (from p in _context.eCategories where item.CategoryId.Contains(p.Id) select p).ToList();
                if (category != null)
                {
                    product.Categories = category;
                }
            }


            _context.eProducts.Add(product);
                _context.SaveChanges();
                return product;
           
            
        }

        public void ChangeProduct(ProductsItemsAddViewModel item)
        {
            var product = GetProduct(item.Id);
            if (product != null)
            {
                product.Name = item.Name;
                product.Price = item.Price;
                product.Discription = item.Discription;
                product.Categories.Clear();
                if (item.CategoryId != null)
                {
                    product.Categories = (from p in _context.eCategories where item.CategoryId.Contains(p.Id) select p).ToList();

                }
                product.LastChange = DateTime.Now;
                SaveChange();
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
        public int Remove(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var item = _context.eProducts.FirstOrDefault(x => x.Id == id);
                if (item != null)
                {
                    _context.eProducts.Remove(item);
                    _context.SaveChanges();
                    scope.Complete();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}