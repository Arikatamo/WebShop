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

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(m => m.Id == id);
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(m => m.Email == email);
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
                User newUser = new User
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = hashedPassword,
                    PasswordSalt = passwordSalt,
                    Roles = new List<Role>(),
                    EmailConfirmed = false,
                    EmailConfirmToken = Guid.NewGuid().ToString()
                };

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
        public bool EmailConfirm(int userId, string token)
        {
            var el = _context.Users.FirstOrDefault(m => m.Id == userId);
            if (el == null || el.EmailConfirmToken != token)
            {
                return false;
            }
            using (TransactionScope scope = new TransactionScope())
            {
                el.EmailConfirmed = true;
                _context.SaveChanges();
                scope.Complete();
                return true;
            }
        }
        public User GenerateForgotPasswordToken(User user)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                user.ForgotToken = Guid.NewGuid().ToString();
                _context.SaveChanges();
                scope.Complete();
                return user;
            }
        }
        public bool CheckForgotToken(int userId, string token)
        {
            var el = _context.Users.SingleOrDefault(m => m.Id == userId);
            if (el == null || el.ForgotToken != token)
                return false;
            else
                return true;
        }
        public User ChangePassword(int userId, string password)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = _context.Users.SingleOrDefault(m => m.Id == userId);
                if(user == null)
                {
                    return null;
                }
                ICryptoService cryptoService = new PBKDF2();
                string passwordSalt = cryptoService.GenerateSalt();
                string hashedPassword = cryptoService.Compute(password);
                user.Password = hashedPassword;
                user.PasswordSalt = passwordSalt;
                _context.SaveChanges();
                scope.Complete();
                return user;
            }
        }

        public bool Login(string email, string password)
        {
            return false;
        }
    }
}