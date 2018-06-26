using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop3.DAL.Abstract;
using WebShop3.DAL.Entities;
using WebShop3.Models;

namespace WebShop3.DAL.Concrete
{
    public class UserProvider : IUserProvider
    {
        private EFContext _context;
        public UserProvider(EFContext context)
        {
            _context = context;
        }
        public User RegisterUser(RegisterUserViewModel user)
        {
            var el = _context.Users.SingleOrDefault(m => m.Email == user.Email);
            if (el != null)
                return null;

            return _context.Users.Add(new User { FullName = user.FullName });
        }
    }
}