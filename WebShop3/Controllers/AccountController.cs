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
        public async Task<ActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var el = _userProvider.RegisterUser(model);
                if (el == null)
                {
                    ModelState.AddModelError("", "Email is already taken");
                    return View();
                }
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = el.Id, token = el.EmailConfirmToken }, Request.Url.Scheme);
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(el.Email, "Confirm your account", $"Confirm the registration by clicking on the link: <a href='{callbackUrl}'>link</a>");
                return View("UserSuccess");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var el = _userProvider.GetUserByEmail(model.Email);
                if (el == null)
                {
                    ModelState.AddModelError("", "User is not found");
                    return View();
                }
                el = _userProvider.GenerateForgotPasswordToken(el);
                var callbackUrl = Url.Action("ChangePassword", "Account", new { userId = el.Id, token = el.ForgotToken }, Request.Url.Scheme);
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(el.Email, "Password recovery", $"You can change your password by clicking on the link: <a href='{callbackUrl}'>link</a>");
                return View("PassworsEmailSuccess");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult ChangePassword(int userId, string token)
        {
            if (!_userProvider.CheckForgotToken(userId, token))
                return HttpNotFound();
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = userId };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var el = _userProvider.ChangePassword(model.Id, model.Password);
                if (el == null)
                    return HttpNotFound();
                return View("PasswordSuccess");
            }
            else
                return View();
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail(int userId, string token)
        {
            if (!_userProvider.EmailConfirm(userId, token))
                return HttpNotFound();
            return View();
        }
    }
}