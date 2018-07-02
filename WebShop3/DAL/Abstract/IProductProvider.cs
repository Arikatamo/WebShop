using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop3.Entity.Products;
using WebShop3.Models.ViewProducts;

namespace WebShop3.DAL.Abstract
{
    public interface IProductProvider
    {
        EProducts AddProduct(ProductsItemsAddViewModel item);
        void ChangeProduct(ProductsItemsAddViewModel item);

        EProducts GetProduct(int id);
        List<EProducts> GetAll();
        void SaveChange();
        int Remove(int id);
    }
}
