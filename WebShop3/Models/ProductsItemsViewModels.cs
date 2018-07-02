using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop3.Models.ViewProducts
{
    public class SelectItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductsItemsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Назва"), Required]
        public string Name { get; set; }
        [DisplayName("Опис"), StringLength(maximumLength:100, ErrorMessage = "Мінімум 10 та Максимум 100 символів ", MinimumLength = 10),Required]
        public string Discription { get; set; }
        [DisplayName("Ціна"), Required]
        public double Price { get; set; }
        [DisplayName("Дата додавання")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Останні Зміни")]
        public DateTime LastChange { get; set; }
        [DisplayName("Категорія")]
        public List<CategoriesItemViewModel> Category { get; set; }
        public List<SelectItemViewModel> CategoryList { get; set; }
        public IEnumerable<int> CategoryId { get; set; }
        [DisplayName("Фото")]
        public string ImagePath { get; set; }

    }

    public class ProductsItemsAddViewModel
    {
        public int Id { get; set; }
        [DisplayName("Назва"), Required]
        public string Name { get; set; }
        [DisplayName("Опис"), StringLength(maximumLength: 100, ErrorMessage = "Мінімум 10 та Максимум 100 символів ", MinimumLength = 10), Required]
        public string Discription { get; set; }
        [DisplayName("Ціна"), Required]
        public double Price { get; set; }
        public List<SelectItemViewModel> CategoryList { get; set; }
        [DisplayName("Категорія")]
        public  IEnumerable<int> CategoryId { get; set; }
        [DisplayName("Фото")]
        public string ImagePath { get; set; }

    }
}