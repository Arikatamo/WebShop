using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebShop3.DAL.Abstract;
using WebShop3.DAL.Concrete;
using WebShop3.DAL.Entities;
using WebShop3.Models;
using WebShop3.Services;

namespace WebShop3.Controllers
{
    public class AccountController : Controller
    {
        private IUserProvider _userProvider;
        public AccountController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterUserViewModel user)
        {
            var el = _userProvider.RegisterUser(user);
            if(el==null)
            {
                ModelState.AddModelError("","Email is already taken");
                return View();
            }

            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = el.Id, token = el.EmailConfirmToken}, Request.Url.Scheme);
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(el.Email, "Confirm your account", $"Confirm the registration by clicking on the link: <a href='{callbackUrl}'>link</a>");

            return View("UserSuccess");
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail(int userId, string token)
        {
            var el =_userProvider.GetUser(userId);
            
            return View();
        }
    }
}