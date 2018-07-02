using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebShop3.Models.ViewProducts;

namespace WebShop3.Entity.Products
{
    [Table("tblProducts")]
    public class EProducts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "Not Set";
        [Required]
        public string Discription { get; set; } = "Not Set";
        [Required]
        public double Price { get; set; } = 0;
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;  /// CreateDate - Встанослюэться Автоматично При створенні Товару
        [Required]
        public DateTime LastChange { get; set; } = DateTime.Now;
        [Required]
        public int Count { get; set; } = 0;
        public string Image { get; set; }
        public virtual ICollection<EVitamins> Vitamins { get; set; }
        public virtual IList<ECategoryProduct> Categories { get; set; }

    }
}