using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop3.Entity.Products;
using WebShop3.Models.ViewProducts;

namespace WebShop3.DAL.Abstract
{
    public interface ICategoryProvider
    {
        ECategoryProduct Add_Category(CategoriesAddViewModel item);
        ECategoryProduct Get_Category(int id);
        List<ECategoryProduct> Get_All();
        void SaveChange();
        int Remove(int id);
    }
}
