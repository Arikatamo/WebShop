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
    public class CategoryProvider : ICategoryProvider
    {
        private EFContext _context;
        public CategoryProvider(EFContext context)
        {
            _context = context;
        }
        public ECategoryProduct Add_Category(CategoriesAddViewModel item)
        {
            throw new NotImplementedException();
        }

        public List<ECategoryProduct> Get_All()
        {
           return _context.eCategories.ToList();
        }

        public ECategoryProduct Get_Category(int id)
        {
            var item = _context.eCategories.FirstOrDefault(x=> x.Id == id);
            if (item != null)
            {
                return item;
            }
            return new ECategoryProduct();
          
        }

        public int Remove(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var item = _context.eCategories.FirstOrDefault(x => x.Id == id);
                if (item != null)
                {
                    _context.eCategories.Remove(item);
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