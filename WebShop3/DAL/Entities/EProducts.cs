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
        /// <summary>
        /// CreateDate - Встанослюэться Автоматично При створенні Товару
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;  /// CreateDate - Встанослюэться Автоматично При створенні Товару
        public virtual IList<EVitamins> Vitamins { get; set; }
        public virtual ECategoryProduct Categories { get; set; }

    }
}