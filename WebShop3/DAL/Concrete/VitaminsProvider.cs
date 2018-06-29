using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using WebShop3.DAL.Abstract;
using WebShop3.DAL.Entities;
using WebShop3.Entity.Products;
using WebShop3.Models;

namespace WebShop3.DAL.Concrete
{
    public class VitaminsProvider : IVitaminsProvider
    {
        private EFContext _context;
        public VitaminsProvider(EFContext context)
        {
            _context = context;
        }
        public EVitamins Add_Vitamins(VitaminsAddViewModel item)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var temp = _context.eVitamins.FirstOrDefault(x => x.Name == item.Name);
                if (temp == null)
                {
                    temp.Name = item.Name;
                    temp.Discription = item.Discription;
                    _context.eVitamins.Add(temp);
                    _context.SaveChanges();
                    scope.Complete();
                    return temp;
                }
            }

            throw new Exception("This item alredy in base");
        }

        public List<EVitamins> Get_All()
        {
            return _context.eVitamins.ToList();
        }

        public EVitamins Get_Vitamin(int id)
        {
            var item = _context.eVitamins.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return item;
            }
            return new EVitamins();
        }

        public void Remove(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _context.eVitamins.Remove(_context.eVitamins.FirstOrDefault(x => x.Id == id));
                _context.SaveChanges();
                scope.Complete();
            }


        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}