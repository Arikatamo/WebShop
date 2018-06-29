using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop3.Entity.Products;
using WebShop3.Models;

namespace WebShop3.DAL.Abstract
{
    public interface IVitaminsProvider
    {
        EVitamins Add_Vitamins(VitaminsAddViewModel item);
        EVitamins Get_Vitamin(int id);
        List<EVitamins> Get_All();
        void SaveChange();
        void Remove(int id);
    }
}
