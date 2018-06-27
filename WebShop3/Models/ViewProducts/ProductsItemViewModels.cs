using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebShop3.Models.ViewProducts
{
    public class ProductsItemsView
    {
        public int Id { get; set; }
        [DisplayName("Назва")]
        public string Name { get; set; }
        [DisplayName("Опис")]
        public string Discription { get; set; }
        [DisplayName("Ціна")]
        public double Price { get; set; }
        [DisplayName("Дата додавання")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Категорія")]
        public CategoriesItemViewModel Category { get; set; }
    }
}