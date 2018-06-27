using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop3.Entity.Products
{
    [Table("tblVitamins")]
    public class EVitamins
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 20)]
        public string Name { get; set; } = "Not Set";
        [Required, StringLength(maximumLength: 200)]
        public string Discription { get; set; } = "Not Set";
        public virtual IList<EProducts> Products { get; set; }
    }
}