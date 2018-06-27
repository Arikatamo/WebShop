using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebShop3.Models.ViewProducts
{
    public class CategoriesItemViewModel
    {
        public int Id { get; set; }
        [DisplayName("Назва")]
        public string Name { get; set; }
        [DisplayName("Опис")]
        public string Discription { get; set; }
        [DisplayName("Продукти")]
        public List<ProductsItemsView> Products { get; set; }
    }
}