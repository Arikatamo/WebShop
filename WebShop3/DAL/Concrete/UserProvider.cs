using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
            using (TransactionScope scope = new TransactionScope())
            {
                var el = _context.Users.SingleOrDefault(m => m.Email == user.Email);
                if (el != null)
                    return null;

                ICryptoService cryptoService = new PBKDF2();
                string passwordSalt = cryptoService.GenerateSalt();
                string hashedPassword = cryptoService.Compute(user.Password);
                Role userRole = _context.Roles.SingleOrDefault(m => m.Name == "User");
                User newUser = new User { FullName = user.FullName, Email = user.Email, Password = hashedPassword, PasswordSalt = passwordSalt, Roles = new List<Role>() };
                if (userRole != null)
                {
                    newUser.Roles.Add(userRole);
                }
                _context.Users.Add(newUser);
                _context.SaveChanges();
                scope.Complete();
                return newUser;
            }
        }
    }
}