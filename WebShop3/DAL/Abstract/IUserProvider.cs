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
        User GetUserById(int id);
        User GetUserByEmail(string email);
        User RegisterUser(RegisterUserViewModel user);
        bool EmailConfirm(int userId, string token);
        User GenerateForgotPasswordToken(User user);
        bool CheckForgotToken(int userId, string token);
        User ChangePassword(int userId, string password);
        bool Login(string email, string password);
    }
}
