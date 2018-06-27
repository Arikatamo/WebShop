using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public virtual IList<EVitamins> Vitamins { get; set; }
        public virtual ECategoryProduct Categories { get; set; }
    }
}