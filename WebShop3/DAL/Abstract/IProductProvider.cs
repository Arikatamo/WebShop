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
        EProducts AddProduct(ProductsItemsViewModel item);
        EProducts GetProduct(int id);
        List<EProducts> GetAll();
    }
}
