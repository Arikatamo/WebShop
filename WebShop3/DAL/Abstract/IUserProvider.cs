using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop3.DAL.Entities;
using WebShop3.Models;

namespace WebShop3.DAL.Abstract
{
    public interface IUserProvider
    {
        User RegisterUser(RegisterUserViewModel user);
    }
}
