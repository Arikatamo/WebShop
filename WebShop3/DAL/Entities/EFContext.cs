using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop3.DAL.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DefaultConnection") {}
    }
}